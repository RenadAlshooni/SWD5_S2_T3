using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechXpress.Models;
using TechXpress_BLL.Dtos;

namespace TechXpress_BLL.Contract
{
   public interface IproductSevice
    {
        public List<ProductDto> GetAllProducts();
        public List<BrandDto> GetAllBrands();
        public List<ProductDto> GetProductsByBrandIds(List<int> brands);
        public List<categoriesDto> GetAllCategories();

    }
}
