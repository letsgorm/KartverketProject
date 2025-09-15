using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using KartverketProject.Models;

namespace KartverketProject.Controllers;

[Route("api/[controller]")]
[ApiController]
public class KartverketController : ControllerBase
{
    static private List<ObstacleData> obstacles = new List<ObstacleData>
    {
        new ObstacleData
        {
            ObstacleId = 1,
            ObstacleName = "Tre",
            ObstacleHeight = 2,
            ObstacleDescription = "Et tre ligger her",
            ObstacleJSON = "{\"type\":\"FeatureCollection\",\"features\":[{\"type\":\"Feature\",\"properties\":{},\"geometry\":{\"type\":\"Point\",\"coordinates\":[7.994013,58.161083]}},{\"type\":\"Feature\",\"properties\":{},\"geometry\":{\"type\":\"Point\",\"coordinates\":[7.999463,58.16114]}},{\"type\":\"Feature\",\"properties\":{},\"geometry\":{\"type\":\"LineString\",\"coordinates\":[[7.994013,58.161083],[7.999463,58.16114]]}}]}"
        }
    };


    [HttpGet]
    public ActionResult<ObstacleData> GetObstacles()
    {
        return Ok(obstacles);
    }


    [HttpGet("{id}")]
    public ActionResult<ObstacleData> GetObstaclesById(int id)
    {
        var obstacle = obstacles.Find(o => o.ObstacleId == id);
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
    public ActionResult<ObstacleData> AddObstacle(ObstacleData newObstacle)
    {
        if (newObstacle is null)
        {
            return NotFound();
        }
        newObstacle.ObstacleId = obstacles.Max(o => o.ObstacleId) + 1;
        obstacles.Add(newObstacle);
        return CreatedAtAction(nameof(AddObstacle), new { id = newObstacle.ObstacleId }, newObstacle); // mulig eksamen sprmsl AHHH
    }

    [HttpPut("{id}")]
    public IActionResult UpdateObstacle(int id, ObstacleData updatedObstacle)
    {
        var obstacle = obstacles.Find(o => o.ObstacleId == id);
        if (obstacle is null)
        {
            return NotFound();
        }

        obstacle.ObstacleId = updatedObstacle.ObstacleId;
        obstacle.ObstacleName = updatedObstacle.ObstacleName;
        obstacle.ObstacleHeight = updatedObstacle.ObstacleHeight;
        obstacle.ObstacleDescription = updatedObstacle.ObstacleDescription;
        obstacle.ObstacleJSON = updatedObstacle.ObstacleJSON;

        return NoContent();
    }

    [HttpDelete]
    public IActionResult RemoveObstacle(int id)
    {
        var obstacle = obstacles.FirstOrDefault(o => o.ObstacleId == id);
        if (obstacle is null)
        {
            return NotFound();
        }
        obstacles.Remove(obstacle);
        return NoContent();
    }
}
