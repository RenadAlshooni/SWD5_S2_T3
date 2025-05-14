using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechXpress.Context;
using TechXpress.Models;
using TechXpress_DAL.Repositories.Contract;

namespace TechXpress_DAL.Repositories.Implementation
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly ApplicationDbContext _context;
        public ProductsRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public int AddProduct(Product product)
        {
            _context.Products.Add(product);
            return _context.SaveChanges();
        }
        public async Task<Product> GetByIdAsync(int id)
        {
            return await _context.Products
                .Include(p => p.Category)
                .Include(p => p.Brand)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

=======
        }
>>>>>>> 0cbe2171ac8f25ac83380e1fc7d6a195a19c5146:TechXpress/TechXpress_DAL/Repositories/Implementation/ProductsRepository.cs
=======
        }
>>>>>>> 0cbe2171ac8f25ac83380e1fc7d6a195a19c5146:TechXpress/TechXpress_DAL/Repositories/Implementation/ProductsRepository.cs
=======
        }
>>>>>>> 0cbe2171ac8f25ac83380e1fc7d6a195a19c5146:TechXpress/TechXpress_DAL/Repositories/Implementation/ProductsRepository.cs
        public List<Product> GetAllProducts()
        {
            return _context.Products
                .Include(P => P.Category)
                .Include(P => P.Brand)
                .ToList();
        }
        public List<Category> GetAllCategories()
        {
            return _context.Categories.ToList();
        }
        public List<Product> GetProductsByCategoryId(int id)
        {

            return _context.Products
                .Include(p => p.Category)
                .Include(p => p.Brand)
                .Where(p => p.CategoryId == id)
                .ToList();
        }
        public List<Product> GetProductsByBrandID(List<int> brandIds)
        {

            return _context.Products
                .Include(p => p.Brand)
                .Where(p => brandIds.Contains(p.BrandId))
                .ToList();
        }

        public List<Brand> GetAllBrands()
        {
            return _context.Brands.ToList();
        }

        public int UpdateProduct(Product product, int id)
        {
            var OldProduct = _context.Products.Where(p => p.Id == id).First();

            OldProduct.Name = product.Name;
            OldProduct.Price = product.Price;
            OldProduct.Description = product.Description;
            OldProduct.Image = product.Image;
            OldProduct.CategoryId = product.CategoryId;
            OldProduct.BrandId = product.BrandId;
            OldProduct.Quantity = product.Quantity;
            return _context.SaveChanges();
        }

        public int DeleteProduct(int id)
        {
            var product = _context.Products.Where(p => p.Id == id).FirstOrDefault();
            if (product != null)
            {
                _context.Products.Remove(product);
            }
            else
            {
                throw new Exception("Product not found");
            }

            return _context.SaveChanges();
        }
    }
}