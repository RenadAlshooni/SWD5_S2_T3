using Microsoft.AspNetCore.Mvc;

namespace TechXpress.Controllers
{
    public class CheckoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
