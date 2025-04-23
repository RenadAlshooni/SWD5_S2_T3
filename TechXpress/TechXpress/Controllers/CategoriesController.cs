using Microsoft.AspNetCore.Mvc;

namespace TechXpress.Controllers
{
    public class CategoriesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
