using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechXpress_BLL.Dtos;

namespace TechXpress_BLL.Contract
{
   public interface IproductSevice
    {
        public List<ProductDto> GetAllProducts();
        public List<BrandDto> GetAllBrands();

    }
}
