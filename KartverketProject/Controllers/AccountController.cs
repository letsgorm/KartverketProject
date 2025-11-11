using KartverketProject.Dtos;
using KartverketProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

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
            var user = new User { UserName = model.UserName, Email = model.Email, LockoutEnabled = true };
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

        // GET: /Account/Login
        [Authorize(Policy = "AuthenticatedAll")]
        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            var user = await _userManager.GetUserAsync(User);
            return View(user);
        }

        // GET: /Account/Reports
        [Authorize(Policy = "AuthenticatedAll")]
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

        [Authorize(Policy = "AuthenticatedAll")]
        [HttpGet("EditReport/{id}")]
        public async Task<IActionResult> EditReport(int id)
        {
            var currentUser = await _userManager.GetUserAsync(User);

            var report = await _context.Report
                .Include(r => r.User)
                .Include(r => r.Obstacle)
                .FirstOrDefaultAsync(r => r.ReportId == id);

            if (report == null)
            {
                return NotFound();
            }

            if (report.UserId != currentUser?.Id)
            {
                return Forbid();
            }

            return View("~/Views/Account/EditReport.cshtml", report.Obstacle);
        }

        // POST: /Account/EditReport/{id}
        [Authorize(Policy = "AuthenticatedAll")]
        [HttpPost("EditReport/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditReport(int id, Obstacle obstacle)
        {
            if (!ModelState.IsValid)
                return View("~/Views/Account/EditReport.cshtml", obstacle);

            var currentUser = await _userManager.GetUserAsync(User);

            // sjekk om rapport eksisterer
            var report = await _context.Report
                .Include(r => r.User)
                .FirstOrDefaultAsync(r => r.ReportId == id);

            if (report == null)
            {
                return NotFound();
            }

            // sjekk om bruker eier rapport
            if (report.UserId != currentUser?.Id)
            {
                return Forbid();
            }

            var existing = await _context.Obstacle.FindAsync(obstacle.ObstacleId);

            // sjekk om hindre eksisterer
            if (existing == null)
            {
                return NotFound();
            }

            // oppdater hindre
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
        [Authorize(Policy = "AuthenticatedAll")]
        [HttpGet("DeleteReport/{id}")]
        public async Task<IActionResult> DeleteReport(int id)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            var report = await _context.Report
                .Include(r => r.User)
                .Include(r => r.Obstacle)
                .FirstOrDefaultAsync(r => r.ReportId == id);

            if (report == null)
            {
                return NotFound();
            }

            // sjekk om bruker eier rapport
            if (report.UserId != currentUser?.Id)
            {
                return Forbid();
            }

            return View(report);
        }

        // POST: /Account/DeleteReportConfirmed
        [Authorize(Policy = "AuthenticatedAll")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteReportConfirmed(int reportId)
        {
            var currentUser = await _userManager.GetUserAsync(User);

            var report = await _context.Report
                .Include(r => r.User)
                .FirstOrDefaultAsync(r => r.ReportId == reportId);

            if (report == null) 
                return NotFound();

            if (report.UserId != currentUser?.Id)
            {
                return Forbid();
            }

            _context.Report.Remove(report);
            await _context.SaveChangesAsync();

            return RedirectToAction("Reports");
        }

        // REVIEWER DEL

        // GET: /Account/OverviewAll
        [Authorize(Policy = "AuthenticatedHigh")]
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

        //Access Denied page
        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }

        // POST: /Account/UpdateStatus
        [Authorize(Policy = "AuthenticatedHigh")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateStatus(int reportId, string newStatus, string reportReason)
        {
            var currentUserId = _userManager.GetUserId(User);

            var report = await _context.Report
                .Include(r => r.User)
                .Include(r => r.SharedWith)
                    .ThenInclude(rs => rs.SharedWithUser)
                .FirstOrDefaultAsync(r => r.ReportId == reportId);

            if (report == null)
                return NotFound();

            // Eier av rapport, delt med eller same org kan kun oppdatere status
            var currentUser = await _userManager.GetUserAsync(User);
            var isOwner = report.UserId == currentUserId;
            var isShared = report.SharedWith.Any(rs => rs.SharedWithUserId == currentUserId);
            var isSameDepartment = report.User.Department == currentUser?.Department;

            // Vis 403
            if (!isOwner && !isShared && !isSameDepartment)
                return Forbid();

            // Save the status and reason
            await _service.UpdateObstacleStatusAsync(report.ObstacleId, newStatus);

            // Save the reason to the report
            report.ReportReason = reportReason;
            _context.Update(report);
            await _context.SaveChangesAsync();

            return RedirectToAction("OverviewAll");
        }

        // GET: /Account/GetReviewersForSharing
        [Authorize(Policy = "AuthenticatedHigh")]
        [HttpGet]
        public async Task<IActionResult> GetReviewersForSharing(int obstacleId)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            var currentDepartment = currentUser?.Department;

            // Hent ut rapport
            var report = await _context.Report
                .Include(r => r.Obstacle)
                .FirstOrDefaultAsync(r => r.Obstacle.ObstacleId == obstacleId);

            if (report == null)
                return NotFound();

            // Hent alle som IKKE er i org
            var otherUsers = await _context.Users
                .Where(u => u.Department != currentDepartment)
                .ToListAsync();

            var reviewers = new List<object>();

            foreach (var user in otherUsers)
            {
                var roles = await _userManager.GetRolesAsync(user);
                // Vis kun admin eller reviewer, ikke brukere
                if (roles.Contains("reviewer") || roles.Contains("admin")) 
                {
                    reviewers.Add(new { user.Id, user.Email });
                }
            }

            return Json(reviewers);
        }



        // POST: /Account/ShareReport
        [Authorize(Policy = "AuthenticatedHigh")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ShareReport(int reportId, List<string> selectedUserIds)
        {
            var currentUserId = _userManager.GetUserId(User);

            var report = await _context.Report
                .Include(r => r.User)
                .FirstOrDefaultAsync(r => r.ReportId == reportId);
            if (report == null) return NotFound();

            // Kun eier eller org kan dele
            var currentUser = await _userManager.GetUserAsync(User);
            var isOwner = report.UserId == currentUserId;
            var isSameDepartment = report.User.Department == currentUser?.Department;

            // Vis 403
            if (!isOwner && !isSameDepartment) 
                return Forbid();

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
        [Authorize(Policy = "AuthenticatedHigh")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> StopSharing(int reportId)
        {
            var currentUserId = _userManager.GetUserId(User);

            // Hent ut rapport
            var report = await _context.Report
                .Include(r => r.User)
                .Include(r => r.SharedWith)
                .FirstOrDefaultAsync(r => r.ReportId == reportId);

            if (report == null)
                return NotFound();

            // Kun eier eller org kan dele
            var currentUser = await _userManager.GetUserAsync(User);
            var isOwner = report.UserId == currentUserId;
            var isSameDepartment = report.User.Department == currentUser?.Department;

            // Vis 403
            if (!isOwner && !isSameDepartment) 
                return Forbid();

            // Remove all shares
            _context.ReportShare.RemoveRange(report.SharedWith);
            await _context.SaveChangesAsync();

            // Redirect back to OverviewAll
            return RedirectToAction("OverviewAll");
        }

        // GET: /Account/GetObstacleDetails
        [Authorize(Policy = "AuthenticatedHigh")]
        [HttpGet]
        public async Task<IActionResult> GetObstacleDetails(int obstacleId)
        {
            var currentUserId = _userManager.GetUserId(User);

            var obstacle = await _context.Obstacle
                .Include(o => o.ReportEntries)
                    .ThenInclude(r => r.User)
                .Include(o => o.ReportEntries)
                    .ThenInclude(r => r.SharedWith)
                        .ThenInclude(rs => rs.SharedWithUser)
                .FirstOrDefaultAsync(o => o.ObstacleId == obstacleId);

            if (obstacle == null) return NotFound();

            var report = obstacle.ReportEntries.FirstOrDefault();

            if (report == null) return NotFound();

            // Kun bruker, delt med eller org kan hente detaljer
            var currentUser = await _userManager.GetUserAsync(User);
            var isOwner = report.UserId == currentUserId;
            var isShared = report.SharedWith.Any(rs => rs.SharedWithUserId == currentUserId);
            var isSameDepartment = report.User.Department == currentUser?.Department;

            // Vis 403
            if (!isOwner && !isShared && !isSameDepartment) 
                return Forbid();

            var sharedWith = report.SharedWith
                .Where(s => s.SharedWithUser != null)
                .Select(s => s.SharedWithUser.Email)
                .ToList();

            return Json(new
            {
                obstacleName = obstacle.ObstacleName,
                department = report.User?.Department ?? "—",
                email = report.User?.Email ?? "—",
                date = obstacle.ObstacleSubmittedDate.ToString("yyyy-MM-dd"),
                status = obstacle.ObstacleStatus,
                description = obstacle.ObstacleDescription,
                obstacleJSON = obstacle.ObstacleJSON,
                sharedWith = sharedWith
            });
        }
    }
}