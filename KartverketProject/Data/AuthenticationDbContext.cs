using KartverketProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace KartverketProject.Data
{
    public class AuthenticationDbContext : IdentityDbContext<User, IdentityRole, string>
    {
        public AuthenticationDbContext(DbContextOptions<AuthenticationDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // fjerner hardkodet ID for roller
            var adminRoleId = "1";
            var reviewerRoleId = "2";
            var userRoleId = "3";

            // lager ny admin
            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Name = "Administrator",
                    NormalizedName = "admin",
                    Id = adminRoleId,
                    ConcurrencyStamp = adminRoleId
                }
            };

            // setter opp rapport siden kan ikke seede collection
            var adminId = "1";

            var adminUser = new User
            {
                Id = adminId,
                UserName = "admin@gorm.no",
                NormalizedUserName = "ADMIN@GORM.NO",
                Email = "admin@gorm.no",
                NormalizedEmail = "ADMIN@GORM.NO",
                FullName = "Administrator",
                Department = "IT",
                PhoneNumber = "12345678"
            };

            // seed role
            modelBuilder.Entity<IdentityRole>().HasData(roles);

            // lager ny passord hash til admin
            adminUser.PasswordHash = new PasswordHasher<User>
                ().HashPassword(adminUser, "admin"); // very secure password

            // bruker egen model for admin brukeren
            modelBuilder.Entity<User>().HasData(adminUser);

            // legg til roller
            var adminRoles = new List<IdentityUserRole<string>>
            {
                new IdentityUserRole<string>
                {
                    RoleId = adminRoleId,
                    UserId = adminId
                },
            };

            // seed role
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(adminRoles);
        }
    }
}
