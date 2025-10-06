using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using KartverketProject.Models;
using KartverketProject.Controllers;

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
            return View("Overview", obstacledata);
        }
        return View();
    }

}
