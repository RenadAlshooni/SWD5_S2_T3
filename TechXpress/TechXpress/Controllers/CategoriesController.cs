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

        public IActionResult Index(int Id , int DisplayNumber = 5)
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
            //  Category filter
            if (Id != 0)   // 0 for all Products
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


            products = products.Take(DisplayNumber).ToList();
            
            
            //  min and max prices for the price filter
            decimal minPrice = products.Any() ? products.Min(p => p.Price) : 0;
            decimal maxPrice = products.Any() ? products.Max(p => p.Price) : 5000;

            ALLProductsVm allProductsVm = new ALLProductsVm
            {
                Products = products,
                Brands = brands,
                TopSellingProducts = TopSelling,
                SelectedBrands = new List<int>(),
                Min_Price = minPrice,
                Max_Price = maxPrice,
                CategoryId = Id
            };
          

            return View(allProductsVm);
        }

        [HttpPost]
        public IActionResult FilterProducts(List<int> selectedBrands ,decimal minPrice, decimal maxPrice , int categoryId ,int DisplayNumber = 5 ,string SortBy = "popular" )
        {
            //  all products 
            var allProducts = _productService.GetAllProducts();

            // brand filter 
            var filteredProducts = allProducts;

            if (selectedBrands != null && selectedBrands.Any())
            {
                filteredProducts = _productService.GetProductsByBrandIds(selectedBrands);
            }
            //  Category filter
            if (categoryId != 0)   // 0 for all Products
            {
                filteredProducts = filteredProducts.Where(p => p.Category.Id == categoryId).ToList();
            }
            //  price filter
            var productsWithPriceFilter = filteredProducts.Where(p => p.Price >= minPrice && p.Price <= maxPrice);

            //sort the products
            if(SortBy == "popular")

                productsWithPriceFilter = productsWithPriceFilter.OrderByDescending(P=>P.Sold).ToList();
            else   /// sortBy == "rating"
                productsWithPriceFilter = productsWithPriceFilter.OrderByDescending(P => P.Rating).ToList();

            //  display number filter

            if (DisplayNumber != 0)
            {
                productsWithPriceFilter = productsWithPriceFilter.Take(DisplayNumber).ToList();
            }
            //mapping the products to the view model
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
