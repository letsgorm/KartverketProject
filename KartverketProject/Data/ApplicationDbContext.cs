using KartverketProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : IdentityDbContext<User, IdentityRole, string>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    // lag rapport og obstacle, ignorer user pga inheritance IdentityUser
    public DbSet<Report> Report => Set<Report>();
    public DbSet<Obstacle> Obstacle => Set<Obstacle>();

    // skap rolle
    private static IdentityRole CreateRole(string id, string email)
    {
        return new IdentityRole
        {
            Id = id,
            Name = email,
            NormalizedName = email.ToUpper(),
            ConcurrencyStamp = id
        };
    }
    // skap bruker
    private static User CreateUser(string id, string email, string firstname, string lastname, string password)
    {
        var user = new User
        {
            Id = id,
            UserName = email,
            NormalizedUserName = email.ToUpper(),
            Email = email,
            NormalizedEmail = email.ToUpper(),
            FirstName = firstname,
            LastName = lastname
        };
        // skap enkryptert passord
        user.PasswordHash = new PasswordHasher<User>().HashPassword(user, password);
        return user;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // VIKTIG: må være først, ellers krasjer Identity-relasjonene
        base.OnModelCreating(modelBuilder);

        // Primærnøkler
        modelBuilder.Entity<Report>()
            .HasKey(r => r.ReportId);

        modelBuilder.Entity<Obstacle>()
            .HasKey(o => o.ObstacleId);

        // Relasjoner
        modelBuilder.Entity<Report>()
            .HasOne(r => r.User)
            .WithMany()
            .HasForeignKey(r => r.UserId)
            .IsRequired(false); // valgfritt, siden noen rapporter kanskje ikke har bruker

        modelBuilder.Entity<Report>()
            .HasOne(r => r.Obstacle) // holder kolleksjonen
            .WithMany(o => o.ReportEntries) // holder navigering egenskapene
            .HasForeignKey(r => r.ObstacleId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<User>().ToTable("AspNetUsers");

        modelBuilder.Entity<Obstacle>().HasData(
            new Obstacle
            {
                ObstacleId = 1,
                ObstacleName = "Test Obstacle",
                ObstacleHeight = 10.5,
                ObstacleDescription = "This is a test obstacle.",
                ObstacleSubmittedDate = new DateTime(2024, 1, 1),
                ObstacleJSON = "{\"type\":\"FeatureCollection\",\"features\":[]}",
                ObstacleStatus = "Pending"
            }
        );

        // fjerner hardkodet ID for roller
        var adminRoleId = Guid.NewGuid().ToString();
        var reviewerRoleId = Guid.NewGuid().ToString();
        var userRoleId = Guid.NewGuid().ToString();

        // fjerner hardkodet ID for brukere
        var adminId = Guid.NewGuid().ToString();
        var reviewerId = Guid.NewGuid().ToString();
        var userId = Guid.NewGuid().ToString();

        // roleId, name
        var roles = new List<IdentityRole>
            {
                CreateRole(adminRoleId, "admin"),
                CreateRole(reviewerRoleId, "reviewer"),
                CreateRole(userRoleId, "user")
            };

        // id, email, role, firstname, lastname, password
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
