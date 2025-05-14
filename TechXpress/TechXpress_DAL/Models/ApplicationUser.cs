
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using TechXpress_DAL.Models;

namespace TechXpress.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? Address { get; set; }
        public EnUserType UserType { get; set; }
        public int UserTypeID { get; set; } // Foreign key for User
        public int? OrderID { get; set; }
        [ForeignKey("OrderID")]
        public List<Order>? Orders { get; set; }
        public int? WishlistID { get; set; }
        [ForeignKey("WishlistID")]
        public List<Wishlist>? Wishlists { get; set; }
    }
    public enum EnUserType
    {
        Admin = 1,
        Customer = 2,
    }
}
