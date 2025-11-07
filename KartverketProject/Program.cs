using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using KartverketProject.Models;
using KartverketProject.Data;

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

            //  Add database context

            builder.Services.AddDbContext<AuthenticationDbContext>(options =>
                options.UseMySql(
                    builder.Configuration.GetConnectionString("DefaultConnection"),
                    new MySqlServerVersion(new Version(11, 8, 3))
                ));

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseMySql(
                    builder.Configuration.GetConnectionString("DefaultConnection"),
                    new MySqlServerVersion(new Version(11, 8, 3))
                ));

            builder.Services.AddIdentity<User, IdentityRole>()
            .AddEntityFrameworkStores<AuthenticationDbContext>()
            .AddDefaultTokenProviders();

            // MVC & other services
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<ObstacleService>();
            builder.Services.AddScoped<UserService>();

            builder.Services.AddOpenApi();

            var app = builder.Build();

            app.MapOpenApi();
            app.MapScalarApiReference();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
                //app.ApplyMigrations(); // ukommenter dette til å migrere automatisk
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