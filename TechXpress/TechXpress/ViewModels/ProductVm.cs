using TechXpress.Models;

namespace TechXpress.ViewModels
{
    public class ProductsVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } 
        public string? Image { get; set; } 
        public int Rating { get; set; }
        public int Sold { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal OldPrice { get; set; }
        public bool HasDiscount { get; set; }
        public int Discount { get; set; }
        public string State { get; set; }
        public Category Category { get; set; }
        public Brand Brand { get; set; }
    }
}
