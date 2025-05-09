﻿using TechXpress.Models;

namespace TechXpress_DAL.Contract
{
    public interface IProductsRepository
    {
       public List<Product> GetAllProducts();
       public List<Product> GetProductsByCategoryId(int id);
        public List<Brand> GetAllBrands();
        public List<Category> GetAllCategories();
        public List<Product> GetProductsByBrandID(List<int> brandIds);


     }
}