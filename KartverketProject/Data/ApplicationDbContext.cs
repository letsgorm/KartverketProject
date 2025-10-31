using KartverketProject.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;


public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<ObstacleData> Obstacles => Set<ObstacleData>();
    public DbSet<Data> DataEntries => Set<Data>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ObstacleData>()
            .HasKey(o => o.ObstacleId);

        // en til mange, hindre kan ha mange JSON data
        modelBuilder.Entity<Data>()
            .HasOne(d => d.Obstacle)
            .WithMany(o => o.DataEntries)
            .HasForeignKey(d => d.ObstacleId);

        // legg til brukere senere
    }
    public DbSet<User> Users { get; set; } 

}