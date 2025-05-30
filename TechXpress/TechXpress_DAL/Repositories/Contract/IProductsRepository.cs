﻿using TechXpress.Models;

namespace TechXpress_DAL.Repositories.Contract
{
    public interface IProductsRepository
    {
        public Task<Product> GetByIdAsync(int id);
        public List<Product> GetAllProducts();
        public List<Product> GetProductsByCategoryId(int id);
        public List<Brand> GetAllBrands();
        public List<Category> GetAllCategories();
        public Task<Product> GetProductByIdAsync(int id);
        public List<Product> GetProductsByBrandID(List<int> brandIds);
        public int AddProduct(Product product);
        int UpdateProduct(Product product, int id);
        int DeleteProduct(int id);

    }
}