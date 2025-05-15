
using System.ComponentModel.DataAnnotations.Schema;

namespace TechXpress.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public decimal OldPrice { get; set; }

        public string Image { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public bool IsLiked { get; set; } = false;
        public bool IsInWishlist { get; set; } = false;
        public bool IsInCart { get; set; } = false;
        public int Quantity { get; set; }
        public int Sold { get; set; } = 0;
        public int Rating { get; set; } = 0;     
        public bool HasDiscount { get; set; } = false;
        public int Discount { get; set; } = 0;
        public bool IsDeleted { get; set; } = false;
        public bool InStock { get; set; } = true;
        public string Reviews { get; set; } = string.Empty;
        public string Details { get; set; } = string.Empty;
        public int SalesPercentage { get; set; } = 0;
        public bool IsNew { get; set; } = false;
        public string State { get; set; } = "New";
        public Category? Category { get; set; }
        public int CategoryId { get; set; }

        public int BrandId { get; set; }
        public Brand? Brand { get; set; }

        public List<ProductColor>? productColors { get; set; }
        public List<OrderItem>? OrderItems { get; set; }

    }
}
