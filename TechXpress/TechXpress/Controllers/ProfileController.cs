using Microsoft.AspNetCore.Mvc;

namespace TechXpress.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
