using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using KartverketProject.Models;

namespace KartverketProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Disable Kestrel's "Server" response header entirely
            builder.WebHost.ConfigureKestrel(options =>
            {
                options.AddServerHeader = false;
            });

            //  Add database context, use same connection string due to nested ReportEntries
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseMySql(
                    builder.Configuration.GetConnectionString("DefaultConnection"),
                    new MySqlServerVersion(new Version(11, 8, 3))
            ));


            // Core Identity
            builder.Services.AddIdentity<User, IdentityRole>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;

            })
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Account/Login";          // hvis ikke logget inn
                options.AccessDeniedPath = "/Account/AccessDenied"; // hvis logget inn men mangler rolle
                options.LogoutPath = "/Account/Logout";
            });

            // Configure Identity options
            builder.Services.Configure<IdentityOptions>(options =>
            {
                // User settings
                options.User.RequireUniqueEmail = true;

                // Lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;
            });

            // MVC & other services
            builder.Services.AddControllersWithViews();
            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("AuthenticatedAll", policy =>
                    policy.RequireRole("admin", "reviewer", "user"));
                options.AddPolicy("AuthenticatedHigh", policy =>
                    policy.RequireRole("admin", "reviewer"));
            });

            var app = builder.Build();

            app.MapOpenApi();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error"); // stack trace fix
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            // Security headers
            app.Use(async (context, next) =>
            {
                context.Response.Headers["X-Frame-Options"] = "DENY";
                context.Response.Headers["X-Content-Type-Options"] = "nosniff";
                context.Response.Headers["Referrer-Policy"] = "strict-origin-when-cross-origin";
                context.Response.Headers["Strict-Transport-Security"] = "max-age=31536000; includeSubDomains; preload";

                // CSP - allow Tailwind, Leaflet, etc.
                context.Response.Headers["Content-Security-Policy"] =
                    "default-src 'self'; " +
                    "script-src 'self' 'unsafe-inline' 'unsafe-eval' https://cdn.jsdelivr.net https://cdnjs.cloudflare.com https://cdn.tailwindcss.com https://unpkg.com; " +
                    "style-src 'self' 'unsafe-inline' https://cdn.jsdelivr.net https://fonts.googleapis.com https://cdn.tailwindcss.com https://unpkg.com; " +
                    "img-src 'self' data: blob: https: http://localhost:8080 https://localhost:8080 https://a.tile.openstreetmap.org https://b.tile.openstreetmap.org https://c.tile.openstreetmap.org https://tile.openstreetmap.org https://*.openstreetmap.fr; " +
                    "font-src 'self' https://fonts.gstatic.com; " +
                    "connect-src 'self' https://unpkg.com http://localhost:8080 https://localhost:8080; " +
                    "frame-ancestors 'none'; " +
                    "object-src 'none'; " +
                    "base-uri 'self'; " +
                    "form-action 'self';";

                await next();
            });

            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}