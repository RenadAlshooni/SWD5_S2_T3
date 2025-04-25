using Microsoft.AspNetCore.Mvc;
using TechXpress.Models;

namespace TechXpress.Controllers
{
    public class CategoriesController : Controller
    {

      
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Laptops()
        {
            return View();
        } 
        public IActionResult Smartphones()
        {
            return View();
        }
        public IActionResult Cameras()
        {
            return View();
        }
        public IActionResult Accessories()
        {
            return View();
        }
    }
}
