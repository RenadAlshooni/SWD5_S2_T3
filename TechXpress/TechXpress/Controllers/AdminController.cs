using Microsoft.AspNetCore.Mvc;
using TechXpress.ViewModels;
using TechXpress_BLL.Services.Contract;

namespace TechXpress.Controllers
{
    public class AdminController : Controller
    {
        private readonly IproductSevice _productService;
        public AdminController(IproductSevice productService)
        {
            _productService = productService;
        }
        public IActionResult Index()
        {
            var products = _productService.GetAllProducts().Select(p => new ProductsVm
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Description = p.Description,
                Image = p.Image,
                Category = p.Category,
                Brand = p.Brand,
                Quantity = p.Quantity,
            
            }).ToList();
            ViewBag.Categories = _productService.GetAllCategories();
            return View(products);
        }

        //[HttpGet]
        //public IActionResult Addproduct()
        //{
        //    return PartialView("_AddProductModal");
        //}
        //[HttpGet]
        //public IActionResult Editproduct()
        //{
        //    return PartialView("_EditProductModal");
        //}

        //[HttpGet]
        //public IActionResult Deleteproduct()
        //{
        //    return PartialView("_EditProductModal");
        //}

    }
}
