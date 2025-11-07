using KartverketProject.Models;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    // Dine egne tabeller (Identity-tabeller legges til automatisk)
    public DbSet<Report> Report => Set<Report>();
    public DbSet<Obstacle> Obstacle => Set<Obstacle>();

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
            .WithMany(u => u.ReportEntries)
            .HasForeignKey(r => r.UserId)
            .IsRequired(false); // valgfritt, siden noen rapporter kanskje ikke har bruker

        modelBuilder.Entity<Report>()
            .HasOne(r => r.Obstacle)
            .WithMany()
            .HasForeignKey(r => r.ObstacleId);

        // Fjern manuell seeding av Identity-brukere (Identity håndterer det selv)
        // Du kan fortsatt seede testdata for Obstacle og Report om du vil:

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

        modelBuilder.Entity<Report>().HasData(
            new Report
            {
                ReportId = 1,
                ObstacleId = 1,
                UserId = null // Ingen koblet bruker i seed, Identity lager det selv
            }
        );
    }
}
