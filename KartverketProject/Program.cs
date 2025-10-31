using KartverketProject.Data;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

namespace KartverketProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
            new MySqlServerVersion(new Version(11, 8, 3))));

            builder.Services.AddScoped<ObstacleService>();

            builder.Services.AddOpenApi();

            var app = builder.Build();

            app.MapOpenApi();

            app.MapScalarApiReference();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
                //app.ApplyMigrations(); // ukommenter dette til å migrere automatisk
            }

            app.UseHttpsRedirection();
            
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
