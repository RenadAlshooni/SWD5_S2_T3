using System.Collections.Generic;

namespace TechXpress.Models
{
    public class Cart
    {

        public int Id { get; set; }
        public string? UserId { get; set; }
        public int Quantity { get; set; } = 0;
        public string ProductName { get; set; }
        public bool IsDeleted { get; set; } = false;
        public List<Product>? Products { get; set; }
        public int ProductId { get; set; }
        public DateTime CreatedAt { get; set; }
        public decimal Price { get; set; }
    }
}
