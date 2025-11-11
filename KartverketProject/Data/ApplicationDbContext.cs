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
    public DbSet<ReportShare> ReportShare => Set<ReportShare>();

    // skap rolle
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
    // skap bruker
    private static User CreateUser(string id, string email, string username, string password, string department)
    {
        var user = new User
        {
            Id = id,
            UserName = username,
            NormalizedUserName = username.ToUpper(),
            Email = email,
            NormalizedEmail = email.ToUpper(),
            Department = department,
            LockoutEnabled = true // brute force
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
            .OnDelete(DeleteBehavior.SetNull); // ha rapport selv om bruker er slettet

        modelBuilder.Entity<Report>()
            .HasOne(r => r.Obstacle) // holder kolleksjonen
            .WithMany(o => o.ReportEntries) // holder navigering egenskapene
            .HasForeignKey(r => r.ObstacleId)
            .OnDelete(DeleteBehavior.Cascade); // slett hver nest

        modelBuilder.Entity<ReportShare>()
            .HasKey(rs => rs.ReportShareId);

        modelBuilder.Entity<ReportShare>()
            .HasOne(rs => rs.Report)
            .WithMany(r => r.SharedWith)
            .HasForeignKey(rs => rs.ReportId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<ReportShare>()
            .HasOne(rs => rs.SharedWithUser)
            .WithMany()
            .HasForeignKey(rs => rs.SharedWithUserId)
            .OnDelete(DeleteBehavior.Restrict); // kan ikke slette bruker hvis reportshareid


        modelBuilder.Entity<User>().ToTable("AspNetUsers");

        // fjerner hardkodet ID for roller
        var adminRoleId = "11111111-1111-1111-1111-111111111111";
        var reviewerRoleId = "22222222-2222-2222-2222-222222222222";
        var userRoleId = "33333333-3333-3333-3333-333333333333";

        // fjerner hardkodet ID for brukere
        // NLA
        var adminIdNla = "33333333-3333-3333-3333-333333333333";
        var reviewerIdNla = "44444444-4444-4444-4444-444444444444";
        var userIdNla = "66666666-6666-6666-6666-666666666666";

        // Luftsforsvaret
        var reviewerIdLuft = "77777777-7777-7777-7777-777777777777";

        // roleId, name
        var roles = new List<IdentityRole>
            {
                CreateRole(adminRoleId, "admin"),
                CreateRole(reviewerRoleId, "reviewer"),
                CreateRole(userRoleId, "user")
            };

        // string id, string email, string username, string password, string department

        // NLA
        var adminUserNrl = CreateUser(adminIdNla, "admin@nla.no", "johnd", "admin", "NLA");
        var reviewerUserNrl = CreateUser(reviewerIdNla, "reviewer@nla.no", "janed", "admin", "NLA");
        var userUserNrl = CreateUser(userIdNla, "user@nla.no", "bobs", "admin", "NLA");

        // Luftsforsvaret
        var reviewerUserLuft = CreateUser(reviewerIdLuft, "reviewer@luftsforsvaret.no", "janiced", "admin", "Luftsforsvaret");

        // seed data for rollene
        modelBuilder.Entity<IdentityRole>().HasData(roles);

        // bruker egen model for admin brukeren
        modelBuilder.Entity<User>().HasData(
            adminUserNrl, 
            reviewerUserNrl, 
            userUserNrl, 
            reviewerUserLuft
            );

        // legg til roller
        var mapRoles = new List<IdentityUserRole<string>>
            {
                new IdentityUserRole<string>
                {
                    RoleId = adminRoleId,
                    UserId = adminIdNla
                },
                new IdentityUserRole<string>
                {
                    RoleId = reviewerRoleId,
                    UserId = reviewerIdNla
                },
                new IdentityUserRole<string>
                {
                    RoleId = userRoleId,
                    UserId = userIdNla
                },
                new IdentityUserRole<string>
                {
                    RoleId = reviewerRoleId,
                    UserId = reviewerIdLuft
                },
            };

        // seed rolle
        modelBuilder.Entity<IdentityUserRole<string>>().HasData(mapRoles);

        // lag et hindre
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

        // lag et rapport med luftsforsvaret
        modelBuilder.Entity<Report>().HasData(new Report
        {
            ReportId = 1,
            ObstacleId = 1,
            UserId = reviewerIdLuft, // links to seeded user
            ReportReason = "This is the reason."
        });
    }
}
