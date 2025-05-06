using TechXpress.Models;

namespace TechXpress.ViewModels
{
    public class ALLProductsVm
    {
        public List<ProductsVm> Products { get; set; } = new List<ProductsVm>();
        public List<Brand> Brands { get; set; } = new List<Brand>();
        public List<ProductsVm> TopSellingProducts { get; set; } = new List<ProductsVm>();
    }
}
