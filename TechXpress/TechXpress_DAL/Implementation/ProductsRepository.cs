using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechXpress.Context;
using TechXpress.Models;
using TechXpress_DAL.Contract;

namespace TechXpress_DAL.Implementation
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly ApplicationDbContext _context;
        public ProductsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Product> GetAllProducts()
        {
            return _context.Products.Include(P=>P.Category) .ToList();
        }
        public List<Product> GetProductsByCategoryId(int id)
        {
            throw new NotImplementedException();
        }
       
        public List<Brand> GetAllBrands()
        {
            return _context.Brands.ToList();
        }
    }
}
