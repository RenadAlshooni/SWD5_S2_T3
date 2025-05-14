using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mono.TextTemplating;
using TechXpress.Models;
using TechXpress.ViewModels;
using TechXpress_BLL.Services.Contract;
using TechXpress_PL.ViewModels;

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

        public IActionResult Index(ApplicationUser user)
        {
            var allProducts = _ProductService.GetAllProducts();
            var newProducts = allProducts.Where( p => p.State == "New").Select( p => new ProductsVm { 
                 Id = p.Id,
                Name = p.Name,
                HasDiscount = p.HasDiscount,
                Discount = p.Discount,
                Image = p.Image,
                OldPrice = p.OldPrice,
                Price = p.Price,
                Rating = p.Rating,
                State = p.State,
                Category = p.Category,

            });
            var topSelling = allProducts.OrderByDescending(p => p.Sold).Take(20).Select(p => new ProductsVm
            {
                Id = p.Id,
                Name = p.Name,
                HasDiscount = p.HasDiscount,
                Discount = p.Discount,
                Image = p.Image,
                OldPrice = p.OldPrice,
                Price = p.Price,
                Rating = p.Rating,
                State = p.State,
                Category = p.Category,
                Sold = p.Sold,
            });
            var homePageVm = new HomePageVm
            {
                NewProducts = newProducts.ToList(),
                TopSelling = topSelling.ToList(),
            };
            return View(homePageVm);
        }
       

    }

}
