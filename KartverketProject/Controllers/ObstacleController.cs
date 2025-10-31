using Microsoft.AspNetCore.Mvc;

public class ObstacleController : Controller
{
    // registrer service som gir loos kobling
    private readonly ObstacleService _service;

    public ObstacleController(ObstacleService service)
    {
        _service = service;
    }

    // blir kalt etter at vi trykker på "Register Obstacle" lenken i Index viewet
    [HttpGet]
    public ActionResult DataForm() => View();


    // blir kalt etter at vi trykker på "Submit Data" knapp i DataForm viewet
    [HttpPost]
    public async Task<IActionResult> DataForm(ObstacleData obstacledata)
    {
        if (!ModelState.IsValid) return View();

        // MVC logic: save obstacle and redirect to Overview page
        await _service.AddObstacleAsync(obstacledata);
        return RedirectToAction("Overview", new { id = obstacledata.ObstacleId });
    }

    // GET: /Obstacle/Overview/{id}
    [HttpGet]
    public async Task<IActionResult> Overview(int id)
    {
        var obstacle = await _service.GetObstacleByIdAsync(id);
        if (obstacle == null) return NotFound();

        // MVC logic: return a View
        return View(obstacle);
    }

    // GET: /Obstacle/OverviewAll
    [HttpGet]
    public async Task<IActionResult> OverviewAll(string statusFilter)
    {
        var obstacles = await _service.GetAllObstaclesAsync();
        if (!string.IsNullOrEmpty(statusFilter) && statusFilter != "All")
        {
            obstacles = obstacles.Where(o => o.Status == statusFilter).ToList();
        }

        ViewData["SelectedStatus"] = statusFilter;
        return View(obstacles);
    }

    // GET: /Obstacle/UpdateStatus/newStatus=Approved
    [HttpGet]
    public async Task<IActionResult> UpdateStatus(int id, string newStatus)
    {
        await _service.UpdateObstacleStatusAsync(id, newStatus);
        return RedirectToAction("OverviewAll");
    }
}
