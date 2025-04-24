using Microsoft.AspNetCore.Mvc;

namespace TechXpress.Controllers
{
    public class WishlistController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
