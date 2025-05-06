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

        public IActionResult Index(int Id)
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
            // Apply Category filter
            if (Id != 0)
            {
                products = products.Where(p => p.Category.Id == Id).ToList();
            }
            var TopSelling = products.OrderByDescending(p => p.Sold).Take(5).ToList();

            var brands = _productService.GetAllBrands().Select(
                b => new Brand
                {
                    Id = b.Id,
                    Name = b.Name,
                    Description = b.Description
                }
            ).ToList();

            // Calculate min and max prices for the price filter
            decimal minPrice = products.Any() ? products.Min(p => p.Price) : 0;
            decimal maxPrice = products.Any() ? products.Max(p => p.Price) : 1000;

            ALLProductsVm allProductsVm = new ALLProductsVm
            {
                Products = products,
                Brands = brands,
                TopSellingProducts = TopSelling,
                SelectedBrands = new List<int>(),
                Min_Price = minPrice,
                Max_Price = maxPrice
            };

            return View(allProductsVm);
        }

        [HttpPost]
        public IActionResult FilterProducts(List<int> selectedBrands ,decimal minPrice, decimal maxPrice)
        {
            // Get all products first
            var allProducts = _productService.GetAllProducts();

            // Apply brand filter if any brands are selected
            var filteredProducts = allProducts;
            if (selectedBrands != null && selectedBrands.Any())
            {
                filteredProducts = _productService.GetProductsByBrandIds(selectedBrands);
            }
           

            // Apply price filter
            var productsWithPriceFilter = filteredProducts.Where(p => p.Price >= minPrice && p.Price <= maxPrice);

            
            var products = productsWithPriceFilter.Select(
                p => new ProductsVm
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Image = p.Image,
                    Price = p.Price,
                    OldPrice = p.OldPrice,
                    HasDiscount = p.HasDiscount,
                    Discount = p.Discount,
                    State = p.State,
                    Category = p.Category,
                    Rating = p.Rating,
                    Sold = p.Sold
                }
            ).ToList();

            var productsVm = new ALLProductsVm
            {
                Products = products,
                Brands = _productService.GetAllBrands().Select(
                    b => new Brand
                    {
                        Id = b.Id,
                        Name = b.Name,
                        Description = b.Description
                    }
                ).ToList(),
                SelectedBrands = selectedBrands ?? new List<int>(),
                Min_Price = minPrice,
                Max_Price = maxPrice
            };

            return PartialView("_FilteredProducts", productsVm);
        }

       
    }
}
