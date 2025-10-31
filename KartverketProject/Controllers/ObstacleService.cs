using KartverketProject.Models;
using Microsoft.EntityFrameworkCore;

public class ObstacleService
{
    private readonly ApplicationDbContext _context;

    // registrer db kontekst
    public ObstacleService(ApplicationDbContext context)
    {
        _context = context;
    }

    // returner hindre
    public async Task<ObstacleData> AddObstacleAsync(ObstacleData obstacle)
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

    // finn hindre etter id som gir data eller default data
    public async Task<ObstacleData?> GetObstacleByIdAsync(int id)
    {
        return await _context.Obstacles.FirstOrDefaultAsync(o => o.ObstacleId == id);
    }

    // gi alle hindre som liste
    public async Task<List<ObstacleData>> GetAllObstaclesAsync()
    {
        return await _context.Obstacles
            .Include(o => o.DataEntries) // inkluder relasjon
            .ToListAsync();
    }

    // oppdater hindre
    public async Task UpdateObstacleAsync(ObstacleData updatedObstacle)
    {
        var obstacle = await _context.Obstacles.FindAsync(updatedObstacle.ObstacleId);
        if (obstacle != null)
        {
            obstacle.ObstacleName = updatedObstacle.ObstacleName;
            obstacle.ObstacleHeight = updatedObstacle.ObstacleHeight;
            obstacle.ObstacleDescription = updatedObstacle.ObstacleDescription;
            obstacle.ObstacleSubmittedDate = updatedObstacle.ObstacleSubmittedDate;
            obstacle.ObstacleJSON = updatedObstacle.ObstacleJSON;
            obstacle.Status = updatedObstacle.Status;
            await _context.SaveChangesAsync();
        }
    }

    // oppdater statusen til hindre
    public async Task UpdateObstacleStatusAsync(int id, string newStatus)
    {
        var obstacle = await _context.Obstacles.FindAsync(id);
        if (obstacle != null)
        {
            obstacle.Status = newStatus;
            await _context.SaveChangesAsync();
        }
    }

    // slett hindre
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
