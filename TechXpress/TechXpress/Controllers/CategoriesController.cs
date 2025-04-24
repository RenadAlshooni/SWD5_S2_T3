using Microsoft.AspNetCore.Mvc;
using TechXpress.Models;

namespace TechXpress.Controllers
{
    public class CategoriesController : Controller
    {

        List<Product> products = new List<Product>
        {
             new Product { Id = 1, Name = "Laptop 1", Price = 999.99, Description = "High performance laptop", ImageUrl = "~/img/product01.png", categorId = 1 },
             new Product { Id = 2, Name = "Smartphone X", Price = 699.50, Description = "Latest model with amazing features", ImageUrl = "~/img/product02.png", categorId = 2 },
             new Product { Id = 3, Name = "Wireless Headphones", Price = 149.99, Description = "Noise cancelling, over-ear headphones", ImageUrl = "~/img/product03.png", categorId = 3 },
             new Product { Id = 4, Name = "Gaming Mouse", Price = 59.99, Description = "Ergonomic design with RGB lighting", ImageUrl = "~/img/product04.png", categorId = 4 },
             new Product { Id = 5, Name = "4K Monitor", Price = 299.99, Description = "Ultra HD 27-inch monitor", ImageUrl = "~/img/product05.png", categorId = 1 },
             new Product { Id = 6, Name = "Bluetooth Speaker", Price = 89.99, Description = "Portable speaker with deep bass", ImageUrl = "~/img/product06.png", categorId = 3 }
        };
       
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
