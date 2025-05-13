using TechXpress.ViewModels;

namespace TechXpress_PL.ViewModels
{
    public class HomePageVm
    {
        public List<ProductsVm> NewProducts { get; set; } = new List<ProductsVm>();
        public List<ProductsVm> TopSelling { get; set; } = new List<ProductsVm>();
    }
}
