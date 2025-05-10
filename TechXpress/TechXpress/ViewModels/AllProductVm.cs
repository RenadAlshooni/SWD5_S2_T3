using TechXpress.Models;

namespace TechXpress.ViewModels
{
    public class ALLProductsVm
    {
        public List<ProductsVm> Products { get; set; } = new List<ProductsVm>();
        public List<Brand> Brands { get; set; } = new List<Brand>();
        public List<ProductsVm> TopSellingProducts { get; set; } = new List<ProductsVm>();
        public List<int> SelectedBrands { get; set; }
        public decimal Min_Price { get; set; }
        public decimal Max_Price { get; set; }
        public int CategoryId { get; set; }

        // Pagination properties
        public int PageNumber { get; set; } = 1;
        public int DisplayNumber { get; set; } = 5; // Products per page
        public int TotalProducts { get; set; }
        public int TotalPages { get; set; }
    }
}
