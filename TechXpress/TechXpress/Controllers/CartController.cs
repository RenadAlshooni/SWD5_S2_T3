using Microsoft.AspNetCore.Mvc;

namespace TechXpress.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
