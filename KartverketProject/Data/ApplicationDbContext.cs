using KartverketProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

public class ApplicationDbContext : IdentityDbContext<IdentityUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<ObstacleData> Obstacles => Set<ObstacleData>();
    public DbSet<Data> DataEntries => Set<Data>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Oppretter Identity-tabellene 
        base.OnModelCreating(modelBuilder);

        // Egne tabeller og relasjoner
        modelBuilder.Entity<ObstacleData>()
            .HasKey(o => o.ObstacleId);

        modelBuilder.Entity<Data>()
            .HasOne(d => d.Obstacle)
            .WithMany(o => o.DataEntries)
            .HasForeignKey(d => d.ObstacleId);
    }
}
