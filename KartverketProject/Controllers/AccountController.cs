using Microsoft.AspNetCore.Mvc;

namespace KartverketProject.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
