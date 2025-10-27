using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KartverketProject.Controllers;

public class ObstacleController(ApplicationDbContext context) : Controller
{
    private readonly ApplicationDbContext _context = context;
    // blir kalt etter at vi trykker på "Register Obstacle" lenken i Index viewet
    [HttpGet]
    public ActionResult DataForm()
    {
        return View();
    }


    // blir kalt etter at vi trykker på "Submit Data" knapp i DataForm viewet
    [HttpPost]
    public async Task<ActionResult<ObstacleData>> DataForm(ObstacleData obstacledata)
    {
        if (ModelState.IsValid)
        {
            // send til db
            _context.Obstacles.Add(obstacledata);
            await _context.SaveChangesAsync();
            return RedirectToAction("Overview", new { id = obstacledata.ObstacleId });
        }
        return View();
    }


    // GET: /Obstacle/Overview/{id}
    [HttpGet]
    public async Task<IActionResult> Overview(int id)
    {
        var obstacle = await _context.Obstacles.FirstOrDefaultAsync(o => o.ObstacleId == id);
        if (obstacle == null)
        {
            return NotFound();
        }

        return View(obstacle); // viser Views/Obstacle/Overview.cshtml (ett hinder)
    }


    // GET: /Obstacle/OverviewAll
    [HttpGet]
    public async Task<IActionResult> OverviewAll(string statusFilter)
    {
        var query = _context.Obstacles.AsQueryable();

        if (!string.IsNullOrEmpty(statusFilter) && statusFilter != "All")
        {
            query = query.Where(o => o.Status == statusFilter);
        }

        var obstacles = await query.ToListAsync();

        ViewData["SelectedStatus"] = statusFilter;
        return View(obstacles); // viser "Views/Obstacle/OverviewAll.cshtml"
    }


    // GET: /Obstacle/UpdateStatus/newStatus=Approved
    [HttpGet]
    public async Task<IActionResult> UpdateStatus(int id, string newStatus)
    {
        var obstacle = await _context.Obstacles.FindAsync(id);
        if (obstacle == null)
        {
            return NotFound();
        }

        obstacle.Status = newStatus;
        await _context.SaveChangesAsync();

        return RedirectToAction("OverviewAll");
    }


}