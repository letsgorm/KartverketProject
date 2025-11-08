using KartverketProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace KartverketProject.Data
{
    public class AuthenticationDbContext : IdentityDbContext<User, IdentityRole, string>
    {
        public AuthenticationDbContext(DbContextOptions<AuthenticationDbContext> options) : base(options)
        {

        }
        private static IdentityRole CreateRole(string id, string name)
        {
            return new IdentityRole
            {
                Id = id,
                Name = name,
                NormalizedName = name.ToUpper(),
                ConcurrencyStamp = id
            };
        }
        private static User CreateUser(string id, string email, string firstname, string lastname, string password)
        {
            var user =  new User
            {
                Id = id,
                UserName = email,
                NormalizedUserName = email.ToUpper(),
                Email = email,
                NormalizedEmail = email.ToUpper(),
                FirstName = firstname,
                LastName = lastname
            };
            user.PasswordHash = new PasswordHasher<User>().HashPassword(user, password);
            return user;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ignorer navigeringsenhet for entitetsrelasjon
            modelBuilder.Ignore<Report>();
            modelBuilder.Ignore<Obstacle>();

            // fjerner hardkodet ID for roller
            var adminRoleId = "1";
            var reviewerRoleId = "2";
            var userRoleId = "3";

            // fjerner hardkodet ID for brukere
            var adminId = "1";
            var reviewerId = "2";
            var userId = "3";

            // roleId, name
            var roles = new List<IdentityRole>
            {
                CreateRole(adminRoleId, "admin"),
                CreateRole(reviewerRoleId, "reviewer"),
                CreateRole(userRoleId, "user")
            };

            // id, email, firstname, lastname
            var adminUser = CreateUser(adminId, "admin@gorm.no", "John", "Doe", "admin");
            var reviewerUser = CreateUser(reviewerId, "reviewer@gorm.no", "Jane", "Doe", "admin");
            var userUser = CreateUser(userId, "user@gorm.no", "Bob", "Smith", "admin");

            // seed data for rollene
            modelBuilder.Entity<IdentityRole>().HasData(roles);

            // bruker egen model for admin brukeren
            modelBuilder.Entity<User>().HasData(adminUser, reviewerUser, userUser);

            // legg til roller
            var adminRoles = new List<IdentityUserRole<string>>
            {
                new IdentityUserRole<string>
                {
                    RoleId = adminRoleId,
                    UserId = adminId
                },
                new IdentityUserRole<string>
                {
                    RoleId = reviewerRoleId,
                    UserId = reviewerId
                },
                new IdentityUserRole<string>
                {
                    RoleId = userRoleId,
                    UserId = userId
                },
            };

            // seed rolle
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(adminRoles);
        }
    }
}
