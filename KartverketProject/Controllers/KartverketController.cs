using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class KartverketController : ControllerBase
{
    // registrer service som gir loos kobling
    private readonly ObstacleService _service;

    public KartverketController(ObstacleService service)
    {
        _service = service;
    }

    // GET: /api/Kartverket
    // hent hindre
    [HttpGet]
    public async Task<ActionResult<List<ObstacleData>>> GetObstacles()
    {
        var obstacles = await _service.GetAllObstaclesAsync();
        return Ok(obstacles);
    }

    // GET: /api/Kartverket/{id}
    // hent hindre med id
    [HttpGet("{id}")]
    public async Task<ActionResult<ObstacleData>> GetObstacleById(int id)
    {
        var obstacle = await _service.GetObstacleByIdAsync(id);
        if (obstacle == null) return NotFound();

        return Ok(obstacle);
    }

    // POST: /api/Kartverket
    // legg til hindre
    [HttpPost]
    // frombody med ? trengs eller saa kommer det validering error...
    public async Task<ActionResult<ObstacleData>> AddObstacle([FromBody] ObstacleData? newObstacle)
    {
        var obstacle = await _service.AddObstacleAsync(newObstacle);
        return CreatedAtAction(nameof(GetObstacleById), new { id = obstacle.ObstacleId }, obstacle);
    }

    // PUT: /api/Kartverket/{id}
    // endre hindre
    [HttpPut("{id}")]
    // frombody med ? trengs eller saa kommer det validering error...
    public async Task<IActionResult> UpdateObstacleStatus(int id, [FromBody] string? newStatus)
    {
        await _service.UpdateObstacleStatusAsync(id, newStatus);
        return NoContent();
    }

    // DEL: /api/Kartverket/{id}
    // slett en hindre i db
    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoveObstacle(int id)
    {
        await _service.DeleteObstacleAsync(id);
        return NoContent();
    }
}
