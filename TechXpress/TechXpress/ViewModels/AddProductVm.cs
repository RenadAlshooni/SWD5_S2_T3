using System.ComponentModel.DataAnnotations;

namespace TechXpress_PL.ViewModels
{
    public class AddProductVm
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [Range(0.00, double.MaxValue, ErrorMessage = "Price must be greater than 0")]
        public decimal Price { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1")]
        public int Quantity { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        public int BrandId { get; set; }

        public IFormFile ImageFile { get; set; }

        public string Description { get; set; }
    }
}
