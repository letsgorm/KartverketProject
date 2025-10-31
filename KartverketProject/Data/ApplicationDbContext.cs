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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ObstacleData>()
            .HasKey(o => o.ObstacleId);
    }
    public DbSet<User> Users { get; set; } 

}