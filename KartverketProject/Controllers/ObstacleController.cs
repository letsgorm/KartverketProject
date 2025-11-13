using KartverketProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

// Site logic for obstacle

namespace KartverketProject.Controllers
{
    [Authorize(Policy = "AuthenticatedAll")] // Kun for bruker, reviewer, admin
    public class ObstacleController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        // registrer db kontekst
        public ObstacleController(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
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
            // hvis validering feiler
            if (!ModelState.IsValid) return View(obstacledata);

            // hent brukerens id
            var userId = _userManager.GetUserId(User);

            // legg til og lagre data
             _context.Obstacle.Add(obstacledata);
            await _context.SaveChangesAsync();

            // lag ny rapport med id
            var report = new Report
            {
                ObstacleId = obstacledata.ObstacleId,
                UserId = userId
            };

            // legg til rapport og lagre
            _context.Report.Add(report);
            await _context.SaveChangesAsync();

            // send til overview
            return RedirectToAction("Overview", new { id = obstacledata.ObstacleId });
        }


        // GET: /Obstacle/Overview/{id}
        // hent hindre med id
        [HttpGet]
        public async Task<IActionResult> Overview(int id)
        {
            // hent brukerens id
            var currentUserId = _userManager.GetUserId(User);

            // hent ut rapporter og id, der hindre id er lik id i {id}
            var obstacle =  await _context.Obstacle
                .Include(o => o.ReportEntries)
                    .ThenInclude(r => r.User)
                .FirstOrDefaultAsync(o => o.ObstacleId == id);

            // hvis ikke funnet
            if (obstacle == null) 
                return NotFound();

            // finn i nest der bruker id er lik id
            var userHasReport = obstacle.ReportEntries.Any(r => r.UserId == currentUserId);

            // hvis bruker ikke har rapport
            if (!userHasReport) 
                return Forbid();

            // returner hindre
            return View(obstacle);
        }
    }
}