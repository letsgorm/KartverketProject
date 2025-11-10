using KartverketProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

// Site logic for submission

[Authorize(Policy = "AuthenticatedAll")]
public class ObstacleController : Controller
{
    // registrer service som gir loos kobling
    private readonly ObstacleService _service;

    public ObstacleController(ObstacleService service)
    {
        _service = service;
    }

    // GET: /Obstacle/DataForm
    // blir kalt etter at vi trykker på "Register Obstacle" lenken i Index viewet
    [HttpGet]
    public ActionResult DataForm() => View();


    // GET: /Obstacle/Overview/{id}
    // hent hindre med id
    [HttpGet]
    public async Task<IActionResult> Overview(int id)
    {
        var obstacle = await _service.GetObstacleByIdAsync(id);
        if (obstacle == null) return NotFound();

        return View(obstacle);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DataForm(Obstacle obstacle, IFormFile? ObstacleImage)
    {
        if (!ModelState.IsValid)
            return View(obstacle);

        // Håndter bildeopplasting
        if (ObstacleImage != null && ObstacleImage.Length > 0)
        {
            var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");
            if (!Directory.Exists(uploadsFolder))
                Directory.CreateDirectory(uploadsFolder);

            var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(ObstacleImage.FileName);
            var filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await ObstacleImage.CopyToAsync(stream);
            }

            obstacle.ImagePath = "/images/" + uniqueFileName;
        }

        // Sett dato
        obstacle.ObstacleSubmittedDate = DateTime.Now;

        // Hent bruker-id
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        // Lagre via service (ikke direkte med _context)
        var saved = await _service.AddObstacleAsync(obstacle, userId);

        // Send brukeren til oversiktssiden for dette obstacle
        return RedirectToAction("Overview", new { id = saved.ObstacleId });
    }


}
