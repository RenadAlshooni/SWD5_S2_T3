

using TechXpress.Models;

namespace TechXpress_DAL.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string? Comment { get; set; }
       // public int Rating { get; set; } = 0;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public bool IsDeleted { get; set; } = false;
        public int ProductId { get; set; }
        public Product? Product { get; set; }
        public int UserId { get; set; }
        public ApplicationUser? User { get; set; }
    }
}
