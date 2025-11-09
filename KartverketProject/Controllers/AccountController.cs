using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using KartverketProject.Models;
using KartverketProject.Dtos;

// Site logic for login and register

namespace KartverketProject.Controllers
{
    // Use UserService to handle user authentication and registration logic
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
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
                    return RedirectToAction("Index", "Home");
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
            return RedirectToAction("Index", "Home");
        }
    }
}
