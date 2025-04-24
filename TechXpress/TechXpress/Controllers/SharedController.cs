using Microsoft.AspNetCore.Mvc;
using TechXpress.Models;

namespace TechXpress.Controllers
{
    public class SharedController : Controller
    {
        public IActionResult _layout()
        {
            List<Category> categories = new List<Category>
            {
                new Category { Id = 1, Name = "Laptops", SubHeader = " Latest models with cutting-edge technology", Description = "Browse our selection of powerful laptops for work, gaming, and everyday use.", ImageUrl = "~/img/product01.png" },
                new Category { Id = 2, Name = "Accessories",SubHeader = "Enhance your tech experience" , Description = "Find the perfect accessories to complement your devices and enhance your experience.", ImageUrl = "~/imag/product02.png" },
                new Category { Id = 3, Name = "Cameras",  SubHeader = "Capture life's moments in stunning detail " ,Description = "Explore our range of digital cameras, from professional DSLRs to compact point-and-shoots.", ImageUrl = "~/imag/product03.png" } ,
                new Category { Id = 4, Name = "Smartphones",SubHeader = "Stay connected with the latest models" ,  Description = "Discover the newest smartphones with advanced features and cutting-edge technology.", ImageUrl = "~/imag/product04.png" } ,
                new Category { Id = 5, Name = "Headphones",SubHeader = "Immerse yourself in premium sound" ,  Description = "Experience superior sound quality with our selection of headphones and earbuds.", ImageUrl = "~/imag/product05.png" } ,
            };

            return View(categories);
        }
    }
}
