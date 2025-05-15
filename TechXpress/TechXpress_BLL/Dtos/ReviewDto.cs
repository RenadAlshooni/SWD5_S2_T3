

using TechXpress.Models;

namespace TechXpress_BLL.Dtos
{
    public class ReviewDto
    {
        #region For Review
        public int Id { get; set; }
        public int UserId { get; set; }
        public ApplicationUser? User { get; set; }
        public int ReviewId { get; set; }
        public string? Comment { get; set; }
        public DateTime CreatedAtReview { get; set; } = DateTime.UtcNow;
        public string UserName { get; set; }
        public string CommentReview { get; set; }

        #endregion
    }
}
