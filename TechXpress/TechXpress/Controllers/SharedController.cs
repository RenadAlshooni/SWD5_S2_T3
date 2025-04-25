using Microsoft.AspNetCore.Mvc;
using TechXpress.Models;

namespace TechXpress.Controllers
{
    public class SharedController : Controller
    {
        public IActionResult _layout()
        {
            return View();
        }
    }
}
