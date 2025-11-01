using KartverketProject.Models;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    // bruker -> rapport -> data -> hindre
    public DbSet<User> Users => Set<User>();
    public DbSet<Report> Report => Set<Report>();
    public DbSet<Data> DataEntries => Set<Data>();
    public DbSet<Obstacle> Obstacles => Set<Obstacle>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        // primaer nokler
        modelBuilder.Entity<User>()
            .HasKey(o => o.UserId);

        modelBuilder.Entity<Report>()
            .HasKey(o => o.ReportId);

        modelBuilder.Entity<Data>()
            .HasKey(o => o.DataId);

        modelBuilder.Entity<Obstacle>()
            .HasKey(o => o.ObstacleId);

        // bygger relasjoner

        modelBuilder.Entity<Report>()
            .HasOne(u => u.User)
            .WithMany(o => o.ReportEntries)
            .HasForeignKey(d => d.UserId); // fremmed nokler

        modelBuilder.Entity<Data>()
            .HasOne(d => d.Obstacle)
            .WithMany(o => o.DataEntries)
            .HasForeignKey(d => d.ObstacleId); // fremmed nokler

        // seed data

        modelBuilder.Entity<User>().HasData(
            new User
            {
                UserId = 1,
                Username = "testuser",
                Password = "password123",
                Email = "test@test.com"
            }
        );

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

        modelBuilder.Entity<Data>().HasData(
            new Data
            {
                ObstacleId = 1,
                ObstacleJSON = "{\"type\":\"FeatureCollection\",\"features\":[]}",
                DataId = 1
            }
         );

        modelBuilder.Entity<Report>().HasData(
            new Report
            {
                ReportId = 1,
                UserId = 1,
                ObstacleId = 1
            }
         );
    }
}