using KartverketProject.Dtos;
using KartverketProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// Site logic for login and register

namespace KartverketProject.Controllers
{
    public class AccountController : Controller
    {
        // registrert identity
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        // registrer obstacle og user context
        private readonly ApplicationDbContext _context;
        private readonly ObstacleService _service;

        public AccountController(
            UserManager<User> userManager, 
            SignInManager<User> signInManager, 
            ApplicationDbContext context, 
            ObstacleService service)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
            _service = service;
        }

         // ULOGGET

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
            var user = new User { UserName = model.UserName, Email = model.Email, LockoutEnabled = true};
            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "user");
                await _signInManager.SignInAsync(user, isPersistent: false);
                return RedirectToAction("DataForm", "Obstacle");
            }

            // Check if duplicate user/email
            if (result.Errors.Any(e => e.Code.Contains("DuplicateUserName") || e.Code.Contains("DuplicateEmail")))
            {
                ModelState.AddModelError(string.Empty, "User already taken");
            }
            // Otherwise, password failed
            else
            {
                ModelState.AddModelError(string.Empty, 
                    "Password must have at least 6 characters, including an uppercase letter, a lowercase letter, a number, and a symbol.");
            }

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
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Please fill out all forms");
                return View(model);
            }

            var result = await _signInManager.PasswordSignInAsync(
                model.UserName,
                model.Password,
                isPersistent: false,
                lockoutOnFailure: true);

            if (result.Succeeded)
                return RedirectToAction("DataForm", "Obstacle");

            if (result.IsLockedOut)
            {
                ModelState.AddModelError("", "Account locked due to too many failed attempts. Try again later.");
                return View(model);
            }

            ModelState.AddModelError("", "Invalid login attempt");
            return View(model);
        }


        // GET: /Account/Logout
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }

        // BRUKER LOGGET INN

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

        // REVIEWER DEL

        // GET: /Account/OverviewAll
        [HttpGet]
        public async Task<IActionResult> OverviewAll(string statusFilter, string sortOrder)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            var userDepartment = currentUser?.Department;
            var userId = currentUser?.Id;

            var obstacles = await _context.Obstacle
                .Include(o => o.ReportEntries)
                    .ThenInclude(r => r.User) // nesting med thenInclude
                .Include(o => o.ReportEntries)
                    .ThenInclude(r => r.SharedWith)
                        .ThenInclude(rs => rs.SharedWithUser)
                .ToListAsync();

            obstacles = obstacles
                .Where(o => o.ReportEntries.Any(r =>
                        r.User.Department == userDepartment || // tilhorer org eller delt med
                        r.SharedWith.Any(rs => rs.SharedWithUserId == userId)
                ))
                .ToList(); // allerede i memory

            // sorter stigende og synkende
            obstacles = sortOrder switch
            {
                "name_asc" => obstacles.OrderBy(o => o.ObstacleName).ToList(),
                "name_desc" => obstacles.OrderByDescending(o => o.ObstacleName).ToList(),
                "department_asc" => obstacles.OrderBy(o => o.ReportEntries.FirstOrDefault()?.User.Department).ToList(),
                "department_desc" => obstacles.OrderByDescending(o => o.ReportEntries.FirstOrDefault()?.User.Department).ToList(),
                "username_asc" => obstacles.OrderBy(o => o.ReportEntries.FirstOrDefault()?.User.UserName).ToList(),
                "username_desc" => obstacles.OrderByDescending(o => o.ReportEntries.FirstOrDefault()?.User.UserName).ToList(),
                "date_asc" => obstacles.OrderBy(o => o.ObstacleSubmittedDate).ToList(),
                "date_desc" => obstacles.OrderByDescending(o => o.ObstacleSubmittedDate).ToList(),
                "status_asc" => obstacles.OrderBy(o => o.ObstacleStatus).ToList(),
                "status_desc" => obstacles.OrderByDescending(o => o.ObstacleStatus).ToList(),
                _ => obstacles.OrderByDescending(o => o.ObstacleSubmittedDate).ToList(),
            };

            // sorter statusFilter
            if (!string.IsNullOrEmpty(statusFilter) && statusFilter != "All")
            {
                obstacles = obstacles
                    .Where(o => o.ObstacleStatus == statusFilter)
                    .ToList();
            }

            // et respons kun med ViewData
            ViewData["SelectedStatus"] = statusFilter;
            ViewData["SortOrder"] = sortOrder;

            return View(obstacles);
        }

        // GET: /Account/UpdateStatus/newStatus=Approved
        // endre til post for reportreason men dette brekker det. finn annen losning?
        [HttpGet]
        public async Task<IActionResult> UpdateStatus(int id, string newStatus)
        {
            await _service.UpdateObstacleStatusAsync(id, newStatus);
            return RedirectToAction("OverviewAll");
        }

        // GET: /Account/GetReviewersForSharing
        [HttpGet]
        public async Task<IActionResult> GetReviewersForSharing(int obstacleId)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            var currentDepartment = currentUser?.Department;

            var reviewers = await _context.Users
                .Where(u => u.Department != currentDepartment)
                .Select(u => new { u.Id, u.Email })
                .ToListAsync();

            return Json(reviewers);
        }

        // POST: /Account/ShareReport
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ShareReport(int reportId, List<string> selectedUserIds)
        {
            foreach (var userId in selectedUserIds)
            {
                var exists = await _context.ReportShare
                    .AnyAsync(rs => rs.ReportId == reportId && rs.SharedWithUserId == userId);
                if (!exists)
                {
                    _context.ReportShare.Add(new ReportShare
                    {
                        ReportId = reportId,
                        SharedWithUserId = userId
                    });
                }
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("OverviewAll");
        }
        // POST: /Account/StopSharing
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> StopSharing(int reportId)
        {
            var currentUserId = _userManager.GetUserId(User);

            var report = await _context.Report
                .Include(r => r.SharedWith)
                .FirstOrDefaultAsync(r => r.ReportId == reportId);

            if (report == null)
                return NotFound();

            // Only the report owner can stop sharing
            if (report.UserId != currentUserId)
                return Forbid();

            // Remove all shares
            _context.ReportShare.RemoveRange(report.SharedWith);
            await _context.SaveChangesAsync();

            // Redirect back to OverviewAll
            return RedirectToAction("OverviewAll");
        }

        // GET: /Account/GetObstacleDetails
        [HttpGet]
        public async Task<IActionResult> GetObstacleDetails(int obstacleId)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            var userId = currentUser?.Id;

            var obstacle = await _context.Obstacle
                .Include(o => o.ReportEntries)
                    .ThenInclude(r => r.User)
                .Include(o => o.ReportEntries)
                    .ThenInclude(r => r.SharedWith)
                        .ThenInclude(rs => rs.SharedWithUser)
                .FirstOrDefaultAsync(o => o.ObstacleId == obstacleId);

            if (obstacle == null) return NotFound();

            var report = obstacle.ReportEntries.FirstOrDefault();

            return Json(new
            {
                obstacleName = obstacle.ObstacleName,
                department = report?.User?.Department ?? "—",
                email = report?.User?.Email ?? "—",
                date = obstacle.ObstacleSubmittedDate.ToString("yyyy-MM-dd"),
                status = obstacle.ObstacleStatus,
                description = obstacle.ObstacleDescription,
                obstacleJSON = obstacle.ObstacleJSON,
                sharedWith = report?.SharedWith.Select(s => s.SharedWithUser.Email).ToList() ?? new List<string>()
            });
        }
    }
}