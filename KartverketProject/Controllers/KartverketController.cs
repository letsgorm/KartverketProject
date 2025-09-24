using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using KartverketProject.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace KartverketProject.Controllers;

[Route("api/[controller]")] // Automatisk modell validering
[ApiController] // Automatisk binding og gjor API mer clean
public class KartverketController(ApplicationDbContext context) : ControllerBase // Dependency injection i dbcontext
{
    private readonly ApplicationDbContext _context = context;

    [HttpGet]
    public async Task<ActionResult<List<ObstacleData>>> GetObstacles()
    {
        return Ok(await _context.Obstacles.ToListAsync()); // Asynkron henting av alle hindre
    }


    [HttpGet("{id}")]
    public async Task<ActionResult<ObstacleData>> GetObstaclesById(int id)
    {
        var obstacle = await _context.Obstacles.FindAsync(id); // Asynkron henting av hinder basert p� id
        if (obstacle is null)
        {
            return NotFound();
        }
        else
        {
            return Ok(obstacle);
        }
    }

    [HttpPost]
    public async Task <ActionResult<ObstacleData>> AddObstacle(ObstacleData newObstacle)
    {
        if (newObstacle is null)
        {
            return NotFound();
        }
        _context.Obstacles.Add(newObstacle); // Legger til ny hinder
        await _context.SaveChangesAsync(); // Lagrer endringer asynkront, viktig!
        return CreatedAtAction(nameof(AddObstacle), new { id = newObstacle.ObstacleId }, newObstacle);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateObstacle(int id, ObstacleData updatedObstacle)
    {
        var obstacle = await _context.Obstacles.FindAsync(id);
        if (obstacle is null)
        {
            return NotFound();
        }

        obstacle.ObstacleId = updatedObstacle.ObstacleId;
        obstacle.ObstacleName = updatedObstacle.ObstacleName;
        obstacle.ObstacleHeight = updatedObstacle.ObstacleHeight;
        obstacle.ObstacleDescription = updatedObstacle.ObstacleDescription;
        obstacle.ObstacleJSON = updatedObstacle.ObstacleJSON;

        await _context.SaveChangesAsync(); // Lagrer endringer asynkront, viktig!

        return NoContent();
    }

    [HttpDelete]
    public async Task<IActionResult> RemoveObstacle(int id)
    {
        var obstacle = await _context.Obstacles.FindAsync(id);
        if (obstacle is null)
        {
            return NotFound();
        }
        _context.Obstacles.Remove(obstacle); // Fjerner hinder
        await _context.SaveChangesAsync();  // Lagrer endringer asynkront, viktig!
        return NoContent();
    }
}
