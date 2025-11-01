using KartverketProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// This is the CRUD service for Obstacles.
// Edit the controller if you wish to make changes.

// KC = KartverketController
// OC = ObstacleController

public class ObstacleService
{
    private readonly ApplicationDbContext _context;

    // registrer db kontekst
    public ObstacleService(ApplicationDbContext context)
    {
        _context = context;
    }

    // gi alle hindre som liste
    // KC: OverviewAll
    // OC: GetObstacles
    public async Task<List<Obstacle>> GetAllObstaclesAsync()
    {
        return await _context.Obstacles
            .Include(o => o.DataEntries) // inkluder relasjon
            .ToListAsync();
    }

    // finn hindre etter id som gir data eller default data
    // KC: Overview
    // OC: GetObstacleById
    public async Task<Obstacle?> GetObstacleByIdAsync(int id)
    {
        return await _context.Obstacles
            .Include(o => o.DataEntries) // inkluder relasjon
            .FirstOrDefaultAsync(o => o.ObstacleId == id);
    }

    // returner hindre -> DataForm
    // KC: AddObstacle
    public async Task<Obstacle> AddObstacleAsync(Obstacle obstacle)
    {
        _context.Obstacles.Add(obstacle); // lag hindre forst foor data
        await _context.SaveChangesAsync();

        var data = new Data // lag ny data
        {
            ObstacleJSON = obstacle.ObstacleJSON,
            ObstacleId = obstacle.ObstacleId
        };

        _context.DataEntries.Add(data); // legg til data
        await _context.SaveChangesAsync();

        return obstacle;
    }

    // oppdater hindre gjennom dto
    // OC: UpdateStatus
    public async Task UpdateObstacleAsync(Obstacle updatedObstacle)
    {
        var obstacle = await _context.Obstacles.FindAsync(updatedObstacle.ObstacleId);
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

    // oppdater statusen til hindre gjennom dto -> UpdateStatus
    // OC: UpdateStatus
    // KC: UpdateObstacleStatus
    public async Task UpdateObstacleStatusAsync(int id, string newStatus)
    {
        var obstacle = await _context.Obstacles.FindAsync(id);
        if (obstacle != null)
        {
            obstacle.ObstacleStatus = newStatus;
            await _context.SaveChangesAsync();
        }
    }

    // slett hindre
    // KC: RemoveObstacle
    public async Task DeleteObstacleAsync(int id)
    {
        var obstacle = await _context.Obstacles.FindAsync(id);
        if (obstacle != null)
        {
            _context.Obstacles.Remove(obstacle);
            await _context.SaveChangesAsync();
        }
    }
}
