using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TechXpress.Models;

namespace TechXpress.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Signup()
        {

            return View();
        } 
        public IActionResult Login()
        {

            return View();
        }

    }

}
