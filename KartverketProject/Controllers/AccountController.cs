using KartverketProject.Dtos;
using KartverketProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

// Site logic for login and register

namespace KartverketProject.Controllers
{
    // Use UserService to handle user authentication and registration logic
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ApplicationDbContext _context;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        // GET: /Account/Register
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        // POST: /Account/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterRequest model)
        {
            if (ModelState.IsValid)
            {
                var user = new User { UserName = model.Email, Email = model.Email };
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "user"); // bruk same som NormalizedName
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", "The password must have an uppercase character, " +
                    "lowercase character, a digit, and a non-alphanumeric character and be at least six characters long.");
                return View(model);
            }
            ModelState.AddModelError("", "Please fill out all forms");
            return View(model);
        }

        // GET: /Account/Login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginRequest model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);
                int attempts = TempData["LoginAttempts"] as int? ?? 0;

                if (result.Succeeded)
                {
                    TempData.Remove("LoginAttempts");
                    return RedirectToAction("DataForm", "Obstacle");
                }
                attempts++;
                TempData["LoginAttempts"] = attempts;
                ModelState.AddModelError("", $"Invalid login attempt {attempts}");
                return View(model);
            }
            ModelState.AddModelError("", "Please fill out all forms");
            return View(model);
        }

        // GET: /Account/Logout
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }

        // GET: /Account/Reports
        [HttpGet]
        public async Task<IActionResult> Reports()
        {
            var user = await _userManager.GetUserAsync(User);
            var reports = await _context.Report
                .Include(r => r.Obstacle)
                .Include(r => r.User)
                .Where(r => r.UserId == user.Id)
                .ToListAsync();

            return View(reports);
        }

        [HttpGet("EditReport/{id}")]
        public async Task<IActionResult> EditReport(int id)
        {
            var user = await _userManager.GetUserAsync(User);

            var report = await _context.Report
                .Include(r => r.Obstacle)
                .FirstOrDefaultAsync(r => r.ReportId == id && r.UserId == user.Id);

            if (report == null)
                return NotFound();

            return View("~/Views/Account/EditReport.cshtml", report.Obstacle);
        }

        [HttpPost("EditReport/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditReport(int id, Obstacle obstacle)
        {
            if (!ModelState.IsValid)
                return View("~/Views/Account/EditReport.cshtml", obstacle);

            var existing = await _context.Obstacle.FindAsync(obstacle.ObstacleId);
            if (existing == null)
                return NotFound();

            // Update obstacle fields
            existing.ObstacleName = obstacle.ObstacleName;
            existing.ObstacleHeight = obstacle.ObstacleHeight;
            existing.ObstacleDescription = obstacle.ObstacleDescription;
            existing.ObstacleJSON = obstacle.ObstacleJSON;
            existing.ObstacleSubmittedDate = DateTime.UtcNow;

            _context.Update(existing);
            await _context.SaveChangesAsync();

            return RedirectToAction("Reports");
        }

        // GET: /Account/DeleteReport/{id}
        [HttpGet("DeleteReport/{id}")]
        public async Task<IActionResult> DeleteReport(int id)
        {
            var user = await _userManager.GetUserAsync(User);
            var report = await _context.Report
                .Include(r => r.Obstacle)
                .FirstOrDefaultAsync(r => r.ReportId == id && r.UserId == user.Id);

            if (report == null) return NotFound();

            return View(report);
        }

        // POST: /Account/DeleteReportConfirmed
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteReportConfirmed(int reportId)
        {
            var user = await _userManager.GetUserAsync(User);
            var report = await _context.Report
                .FirstOrDefaultAsync(r => r.ReportId == reportId && r.UserId == user.Id);

            if (report == null) return NotFound();

            _context.Report.Remove(report);
            await _context.SaveChangesAsync();

            return RedirectToAction("Reports");
        }
    }
}