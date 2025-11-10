using KartverketProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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


    // POST: /Obstacle/DataForm
    // blir kalt etter at vi trykker på "Submit Data" knapp i DataForm viewet
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DataForm(Obstacle obstacledata)
    {
        if (!ModelState.IsValid) return View(obstacledata);
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var saved = await _service.AddObstacleAsync(obstacledata, userId);
        return RedirectToAction("Overview", new { id = saved.ObstacleId });
    }


    // GET: /Obstacle/Overview/{id}
    // hent hindre med id
    [HttpGet]
    public async Task<IActionResult> Overview(int id)
    {
        var obstacle = await _service.GetObstacleByIdAsync(id);
        if (obstacle == null) return NotFound();

        return View(obstacle);
    }
}
