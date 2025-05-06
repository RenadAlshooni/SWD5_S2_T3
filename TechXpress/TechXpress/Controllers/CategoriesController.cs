using Microsoft.AspNetCore.Mvc;
using TechXpress.Models;
using TechXpress.ViewModels;
using TechXpress_BLL.Contract;
using TechXpress_BLL.Implementation;

namespace TechXpress.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly IproductSevice _productService;

        public CategoriesController(IproductSevice productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            var products = _productService.GetAllProducts().Select(

                P => new ProductsVm
                {
                    Id = P.Id,
                    Name = P.Name,
                    Description = P.Description,
                    Image = P.Image,
                    Price = P.Price,
                    OldPrice = P.OldPrice,
                    HasDiscount = P.HasDiscount,
                    Discount = P.Discount,
                    State = P.State,
                    Category = P.Category,
                    Rating = P.Rating,
                    Sold = P.Sold,
                }
                ).ToList();

            var TopSelling = products.OrderByDescending(p => p.Sold).Take(5).ToList();
            var brands = _productService.GetAllBrands().Select(
                b => new Brand
                {
                    Id = b.Id,
                    Name = b.Name,
                    Description = b.Description
                }
            ).ToList();
            ALLProductsVm allProductsVm = new ALLProductsVm
            {
                Products = products,
                Brands = brands,
                TopSellingProducts = TopSelling
            };



            return View(allProductsVm);
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
