
using Microsoft.AspNetCore.Identity;

namespace TechXpress.Models
{
    public class User : IdentityUser
    {
        public List<Order>? Orders { get; set; }
    }
}
