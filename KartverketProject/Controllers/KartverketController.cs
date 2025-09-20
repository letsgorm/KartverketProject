using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using KartverketProject.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace KartverketProject.Controllers;

[Route("api/[controller]")]
[ApiController]
public class KartverketController(ApplicationDbContext context) : ControllerBase
{
    private readonly ApplicationDbContext _context = context;

    [HttpGet]
    public async Task<ActionResult<List<ObstacleData>>> GetObstacles()
    {
        return Ok(await _context.Obstacles.ToListAsync());
    }


    [HttpGet("{id}")]
    public async Task<ActionResult<ObstacleData>> GetObstaclesById(int id)
    {
        var obstacle = await _context.Obstacles.FindAsync(id);
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
        _context.Obstacles.Add(newObstacle);
        await _context.SaveChangesAsync();
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

        await _context.SaveChangesAsync();

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
        _context.Obstacles.Remove(obstacle);
        await _context.SaveChangesAsync();  
        return NoContent();
    }
}
