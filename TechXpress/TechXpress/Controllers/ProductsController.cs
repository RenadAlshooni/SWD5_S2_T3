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

        public IActionResult Index(int id)
        {
            
            var product = _productService.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            var relatedProducts = _productService.GetAllProducts()
                .Where(p => p.CategoryId == product.CategoryId && p.Id != product.Id)
                .Take(4)
                .ToList();
            var productDetailsVm = new ProductDetailsVm()
            {
                Product = product,
                RelatedProducts = _productService.GetAllProducts()
            };


            return View(productDetailsVm);
        }
    }
}
