using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechXpress.Models;
using TechXpress_BLL.Contract;
using TechXpress_BLL.Dtos;
using TechXpress_DAL.Contract;
using TechXpress_DAL.Implementation;

namespace TechXpress_BLL.Implementation
{
    public class ProductService : IproductSevice
    {
        private readonly IProductsRepository _ProductRepo;
        private object model;

        public ProductService(IProductsRepository productRepo)
        {
            _ProductRepo = productRepo;
        }
        void UpdateProduct(ProductDto existingProduct)
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

            _ProductRepo.UpdateProduct(product, id);
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

        void IproductSevice.UpdateProduct(ProductDto existingProduct)
        {
            UpdateProduct(existingProduct);
        }

        public int DeleteProduct(int id)
        {
           return _ProductRepo.DeleteProduct(id);
        }
    }
}
