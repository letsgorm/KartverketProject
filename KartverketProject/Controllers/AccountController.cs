using Microsoft.AspNetCore.Mvc;

namespace KartverketProject.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View(); // viser Views/Account/Login.cshtml
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View(); // viser Views/Account/Register.cshtml
        }
    }
}

