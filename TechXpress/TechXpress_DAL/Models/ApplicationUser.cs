
using Microsoft.AspNetCore.Identity;

namespace TechXpress.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? Address { get; set; }
        public EnUserType UserType { get; set; }
        public int UserTypeID { get; set; } // Foreign key for User
        public List<Order>? Orders { get; set; }
    }
    public enum EnUserType
    {
        Admin = 1,
        Client = 2,
      
    }
}
