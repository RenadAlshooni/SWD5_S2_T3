using Microsoft.AspNetCore.Mvc;

namespace TechXpress.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
