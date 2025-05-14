using TechXpress.Models;

namespace TechXpress.ViewModels
{
    public class ProductsVm
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Description { get; set; } = ""; 
        public string? Image { get; set; } =""; 
        public int Rating { get; set; } = 0;  
        public int Sold { get; set; } = 0;
        public int Quantity { get; set; } = 0;
        public decimal Price { get; set; } = 0;
        public decimal OldPrice { get; set; } = 0; 
        public bool HasDiscount { get; set; }  = false;
        public int Discount { get; set; } = 0;
        public string State { get; set; } = "";
        public Category Category { get; set; }
        public Brand Brand { get; set; }
    }
}
