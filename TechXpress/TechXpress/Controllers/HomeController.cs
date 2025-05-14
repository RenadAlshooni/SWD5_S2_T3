using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TechXpress.Models;
using TechXpress_BLL.Contract;

namespace TechXpress.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IproductSevice _ProductService;
        public HomeController(IproductSevice productSevice,ILogger<HomeController> logger)
        {
            _logger = logger;
            _ProductService = productSevice;
        }

        public IActionResult Index()
        {
            var categories = _ProductService.GetAllCategories().ToList();

            return View();
        }
       

    }

}
