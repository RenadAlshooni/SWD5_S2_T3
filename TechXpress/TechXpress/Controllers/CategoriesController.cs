using Microsoft.AspNetCore.Mvc;
using System.Numerics;
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

        public IActionResult Index(int Id, int DisplayNumber = 10, int PageNumber = 0)
        {
            // Get all products and map to view model
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
            );

            // Category filter
            if (Id != 0)   // 0 for all Products
            {
                products = products.Where(p => p.Category.Id == Id);
            }

            var TopSelling = products.OrderByDescending(p => p.Sold).Take(3);

            var brands = _productService.GetAllBrands().Select(
                b => new Brand
                {
                    Id = b.Id,
                    Name = b.Name,
                    Description = b.Description
                }
            );

            // Calculate total products BEFORE pagination
            int totalProducts = products.Count();

            // Calculate total pages based on total products
            int Totalpages = (int)Math.Ceiling((double)totalProducts / DisplayNumber);

            // Min and max prices for the price filter - calculate from all products before pagination
            decimal minPrice = products.Any() ? products.Min(p => p.Price) : 0;
            decimal maxPrice = products.Any() ? products.Max(p => p.Price) : 5000;

            // Apply pagination AFTER counting total products
            products = products
                    .Skip(PageNumber * DisplayNumber)
                    .Take(DisplayNumber);

            ALLProductsVm allProductsVm = new ALLProductsVm
            {
                Products = products.ToList(),
                Brands = brands.ToList(),
                TopSellingProducts = TopSelling.ToList(),
                SelectedBrands = new List<int>(),
                Min_Price = minPrice,
                Max_Price = maxPrice,
                CategoryId = Id,
                DisplayNumber = DisplayNumber,
                PageNumber = PageNumber,
                TotalProducts = totalProducts, 
                TotalPages = Totalpages,
            };

            return View(allProductsVm);
        }

        [HttpPost]
        public IActionResult FilterProducts(List<int> selectedBrands, decimal minPrice, decimal maxPrice, int categoryId, int DisplayNumber = 10, int PageNumber = 0, string SortBy = "popular")
        {
            // Get all products
            var allProducts = _productService.GetAllProducts();

            // Apply brand filter
            var filteredProducts = allProducts;
            if (selectedBrands != null && selectedBrands.Any())
            {
                filteredProducts = _productService.GetProductsByBrandIds(selectedBrands);
            }

            // Apply category filter
            if (categoryId != 0)   // 0 for all Products
            {
                filteredProducts = filteredProducts.Where(p => p.Category.Id == categoryId).ToList();
            }

            // Apply price filter
            var productsWithPriceFilter = filteredProducts.Where(p => p.Price >= minPrice && p.Price <= maxPrice);

            // Sort the products
            if (SortBy == "popular")
                productsWithPriceFilter = productsWithPriceFilter.OrderByDescending(P => P.Sold);
            else   // sortBy == "rating"
                productsWithPriceFilter = productsWithPriceFilter.OrderByDescending(P => P.Rating);

            // Map to view model
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
            );

            
            int totalProducts = products.Count();

            // total pages based on filtered products
            int Totalpages = (int)Math.Ceiling((double)totalProducts / DisplayNumber);

            
            var paginatedProducts = products
                    .Skip(PageNumber * DisplayNumber)
                    .Take(DisplayNumber);

            // map to the page view model
            var productsVm = new ALLProductsVm
            {
                Products = paginatedProducts.ToList(),
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
                Max_Price = maxPrice,
                CategoryId = categoryId,
                DisplayNumber = DisplayNumber,
                PageNumber = PageNumber,
                TotalProducts = totalProducts, //  the count before pagination
                TotalPages = Totalpages,
            };

            return PartialView("_FilteredProducts", productsVm);
        }
    }
}