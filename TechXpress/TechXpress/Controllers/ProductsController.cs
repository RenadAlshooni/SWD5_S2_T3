using Microsoft.AspNetCore.Mvc;
using TechXpress_BLL.Dtos;
using TechXpress_BLL.Services.Contract;
using System.Linq;
using TechXpress_PL.ViewModels;

namespace TechXpress.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IproductSevice _productService;
        public ProductsController(IproductSevice productService)
        {
            _productService = productService;
        }

        public IActionResult Index(int id, ProductDto productRatings)
        {
            
            var product = _productService.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
    }
}
