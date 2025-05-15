using TechXpress_BLL.Dtos;

namespace TechXpress_PL.ViewModels
{
    public class ProductDetailsVm
    {
        public ProductDto Product { get; set; }
        public IEnumerable<ProductDto> RelatedProducts { get; set; }
    }
}
