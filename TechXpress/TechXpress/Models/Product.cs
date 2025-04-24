using System.ComponentModel.DataAnnotations.Schema;

namespace TechXpress.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }
        public byte[] ImageUrl { get; set; }

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
        
        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; }
        public int CategoryId { get; set; }

    }
}
