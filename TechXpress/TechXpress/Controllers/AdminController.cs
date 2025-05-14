using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using TechXpress.Models;
using TechXpress.ViewModels;
using TechXpress_BLL.Dtos;
using TechXpress_BLL.Services.Contract;
using TechXpress_PL.ViewModels;

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


            ViewBag.Categories = _productService.GetAllCategories().Select(c => new CategoryVm
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Status,
            }).ToList();
            ViewBag.Brands = _productService.GetAllBrands().Select(b => new Brand
            {
                Id = b.Id,
                Name = b.Name,
                Description = b.Description,
            }).ToList(); 

            return View(products);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(AddProductVm product)
        {
            if (!ModelState.IsValid)
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
                ViewBag.Brands = _productService.GetAllBrands();

                return View("Index", products);
            }
            // processing the image file
            if (product.ImageFile != null)
            {
                string uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img");
                string filePath = Path.Combine(uploadsFolder, product.ImageFile.FileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await product.ImageFile.CopyToAsync(fileStream);
                }
            }

            var Product = new ProductDto()
            {
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
                Image = product.ImageFile.FileName,
                CategoryId = product.CategoryId,
                BrandId = product.BrandId,
                Quantity = product.Quantity,

            };
            // Save the product to the database

            if (_productService.AddProduct(Product) > 0)
            {
                return RedirectToAction("Index");
            }
            return Content("Error , Contact the support");
        }
        [HttpPost]
        public async Task<IActionResult> EditProduct(EditProductVm model)
        {
     
            // Get the existing product
            var existingProduct = _productService.GetAllProducts().Where(p => p.Id == model.Id).First();
            if (existingProduct == null)
            {
                TempData["ErrorMessage"] = "Product not found.";
                return RedirectToAction("Index");
            }

            // Process the image file if a new one was uploaded
            string imageFileName = model.CurrentImage; // Default  current image
            if (model.ImageFile != null && model.ImageFile.Length > 0)
            {
                
                string uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img");
                imageFileName = model.ImageFile.FileName;
                string filePath = Path.Combine(uploadsFolder, imageFileName);

                // Save the file
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await model.ImageFile.CopyToAsync(fileStream);
                }
            }
            // mapping to a product Dto
            existingProduct.Name = model.Name;
            existingProduct.Price = model.Price;
            existingProduct.Description = model.Description;
            existingProduct.Image = imageFileName;
            existingProduct.CategoryId = model.CategoryId;
            existingProduct.BrandId = model.BrandId;
            existingProduct.Quantity = model.Quantity;

            // Save the updated product
            if(_productService.UpdateProduct(existingProduct) > 0)
                return RedirectToAction("Index");
            return Content("Error , Contact the support");
        }



        [HttpPost]
        public IActionResult Deleteproduct(int id)
        {
            var product = _productService.GetAllProducts().Where(p => p.Id == id).FirstOrDefault();
            if (product == null)
            {
                TempData["ErrorMessage"] = "Product not found.";
                return RedirectToAction("Index");
            }
            // Delete the product from the database
            if(_productService.DeleteProduct(id) > 0)
                return RedirectToAction("Index");

            return Content("Error , Contact the support");

        }

    }
}
