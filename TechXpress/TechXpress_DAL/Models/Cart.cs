using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechXpress.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public string? UserId { get; set; }
        public int Quantity { get; set; } = 0;
        public string? ImageUrl { get; set; }
        public string? ProductName { get; set; }
        public decimal Price { get; set; } = 0;
        public bool IsDeleted { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public List<Product>? Products { get; set; }
    }
}
