using KartverketProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

// API controller for Obstacle

namespace KartverketProject.Controllers
{
    [Authorize(Policy = "AuthenticatedHigh")] // Kun for admin, reviwer
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
        public async Task<ActionResult<List<Obstacle>>> GetObstacles()
        {
            var obstacles = await _service.GetAllObstaclesAsync();
            return Ok(obstacles);
        }

        // GET: /api/Kartverket/{id}
        // hent hindre med id
        [HttpGet("{id}")]
        public async Task<ActionResult<Obstacle>> GetObstacleById(int id)
        {
            var obstacle = await _service.GetObstacleByIdAsync(id);
            if (obstacle == null) return NotFound();

            return Ok(obstacle);
        }

        // POST: /api/Kartverket
        // legg til hindre
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<Obstacle>> AddObstacle(Obstacle newObstacle)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var obstacle = await _service.AddObstacleAsync(newObstacle, userId);
            return CreatedAtAction(nameof(GetObstacleById), new { id = obstacle.ObstacleId }, obstacle);
        }

        // PUT: /api/Kartverket/{id}
        // endre hindre
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateObstacleStatus(int id, string newStatus)
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
}