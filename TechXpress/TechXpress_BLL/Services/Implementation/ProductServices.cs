using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechXpress.Models;
using TechXpress_BLL.Dtos;
using TechXpress_BLL.Services.Contract;
using TechXpress_DAL.Repositories.Implementation;
using TechXpress_DAL.Repositories.Contract;

namespace TechXpress_BLL.Services.Implementation
{
    public class ProductServices : IproductSevice
    {
        private readonly IProductsRepository _ProductRepo;

        public ProductServices(IProductsRepository productRepo)
        {
            _ProductRepo = productRepo;
        }

        public List<ProductDto> GetAllProducts()
        {
            var products = _ProductRepo.GetAllProducts().Select( P => 
            new ProductDto
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
            return products;
        }
        public List<BrandDto> GetAllBrands()
        {
            var Brands =  _ProductRepo.GetAllBrands().Select(b => new BrandDto
            {
                Id = b.Id,
                Name = b.Name,
                Description = b.Description
            }).ToList();
        return Brands;
        }
        public List<categoriesDto> GetAllCategories()
        {
            var categories = _ProductRepo.GetAllCategories().Select(c => new categoriesDto 
            {
                Id = c.Id,
                Name = c.Name,
                Status = c.Status
            }).ToList();
            return categories;
        }
        public List<ProductDto> GetProductsByBrandIds(List<int> brands)
        {
            var products = _ProductRepo.GetProductsByBrandID(brands).Select(P => new ProductDto
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
            }).ToList();

            return products;
        }
        
        }
}
