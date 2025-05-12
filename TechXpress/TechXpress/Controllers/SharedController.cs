using Microsoft.AspNetCore.Mvc;
using TechXpress.Models;
using TechXpress_BLL.Services.Contract;

namespace TechXpress.Controllers
{
    public class SharedController : Controller
    {
        private readonly IproductSevice _ProductService;

        public SharedController(IproductSevice productService)
        {
            _ProductService = productService;
        }

        public IActionResult _layout()
        {   

            return PartialView();
        }
    }
}
