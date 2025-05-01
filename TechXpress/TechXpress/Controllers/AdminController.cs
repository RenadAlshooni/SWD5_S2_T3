using Microsoft.AspNetCore.Mvc;

namespace TechXpress.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
