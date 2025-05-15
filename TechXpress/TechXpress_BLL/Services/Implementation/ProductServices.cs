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
using TechXpress_DAL.Models;

namespace TechXpress_BLL.Services.Implementation
{
    public class ProductServices : IproductSevice
    {
        private readonly IProductsRepository _ProductRepo;
        private object model;

        public ProductServices(IProductsRepository productRepo)
        {
            _ProductRepo = productRepo;
        }
        public  int UpdateProduct(ProductDto existingProduct)
        {
            var product = new Product()
            {
                Name = existingProduct.Name,
                Price = existingProduct.Price,
                Description = existingProduct.Description,

                Image = existingProduct.Image,
                CategoryId = existingProduct.CategoryId,
                BrandId = existingProduct.BrandId,
                Quantity = existingProduct.Quantity

            };
            int id = existingProduct.Id;

            return _ProductRepo.UpdateProduct(product, id);
        }
        public int AddProduct(ProductDto product)
        {
            Product newProduct = new()
            {
                Name = product.Name,
                Description = product.Description,
                Image = product.Image,
                Price = product.Price,
                Quantity = product.Quantity,
                CategoryId = product.CategoryId,
                BrandId = product.BrandId,

            };
            return _ProductRepo.AddProduct(newProduct);


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
                Quantity = P.Quantity,
                Category = P.Category,
                Brand = P.Brand,
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
        public ProductDto GetProductById(int id)
        {
            var product = _ProductRepo.GetByIdAsync(id).Result;
            if (product == null)
            {
                return null;
            }
            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Image = product.Image,
                Price = product.Price,
                OldPrice = product.OldPrice,
                HasDiscount = product.HasDiscount,
                Discount = product.Discount,
                State = product.State,
                Quantity = product.Quantity,
                CategoryId = product.CategoryId,
                BrandId = product.BrandId,
                Rating = product.Rating,
                Sold = product.Sold,
                CategoryName = product.Category.Name,
                InStock = product.InStock,
                Reviews = product.Reviews,
                Details = product.Details,
                SalesPercentage = product.SalesPercentage,
                IsNew = product.IsNew,
                productColors = product.productColors,
            };
           
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

      

        public int DeleteProduct(int id)
        {
           return _ProductRepo.DeleteProduct(id);
        }

       
    }
}
