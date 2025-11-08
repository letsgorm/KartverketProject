using KartverketProject.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

// This is the CRUD service for Obstacle.
// KartverketController
// ObstacleController

public class ObstacleService
{
    private readonly ApplicationDbContext _context;

    // registrer db kontekst
    public ObstacleService(ApplicationDbContext context)
    {
        _context = context;
    }

    // gi alle hindre som liste
    public async Task<List<Obstacle>> GetAllObstaclesAsync()
    {
        return await _context.Obstacle
            .Include(o => o.ReportEntries)
                .ThenInclude(r => r.User)
            .ToListAsync();
    }

    // finn hindre etter id som gir data eller default data
    public async Task<Obstacle?> GetObstacleByIdAsync(int id)
    {
        return await _context.Obstacle
            .Include(o => o.ReportEntries)
                .ThenInclude(r => r.User)
            .FirstOrDefaultAsync(o => o.ObstacleId == id);
    }

    // returner hindre -> DataForm
    public async Task<Obstacle> AddObstacleAsync(Obstacle obstacle, string userId)
    {
        _context.Obstacle.Add(obstacle);
        await _context.SaveChangesAsync();

        var report = new Report
        {
            ObstacleId = obstacle.ObstacleId,
            UserId = userId
        };
        _context.Report.Add(report);
        await _context.SaveChangesAsync();
        
        return obstacle;
    }

    // oppdater hindre
    public async Task UpdateObstacleAsync(Obstacle updatedObstacle)
    {
        var obstacle = await _context.Obstacle.FindAsync(updatedObstacle.ObstacleId);
        if (obstacle != null)
        {
            obstacle.ObstacleName = updatedObstacle.ObstacleName;
            obstacle.ObstacleHeight = updatedObstacle.ObstacleHeight;
            obstacle.ObstacleDescription = updatedObstacle.ObstacleDescription;
            obstacle.ObstacleSubmittedDate = updatedObstacle.ObstacleSubmittedDate;
            obstacle.ObstacleJSON = updatedObstacle.ObstacleJSON;
            obstacle.ObstacleStatus = updatedObstacle.ObstacleStatus;
            await _context.SaveChangesAsync();
        }
    }

    // oppdater statusen til hindre -> UpdateStatus
    public async Task UpdateObstacleStatusAsync(int id, string newStatus)
    {
        var obstacle = await _context.Obstacle.FindAsync(id);
        if (obstacle != null)
        {
            obstacle.ObstacleStatus = newStatus;
            await _context.SaveChangesAsync();
        }
    }

    // slett hindre
    public async Task DeleteObstacleAsync(int id)
    {
        var obstacle = await _context.Obstacle.FindAsync(id);
        if (obstacle != null)
        {
            _context.Obstacle.Remove(obstacle);
            await _context.SaveChangesAsync();
        }
    }
}
