using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechXpress.Models;

namespace TechXpress_DAL.Models
{
    public class Wishlist
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public string UserId { get; set; }
        public DateTime DateAdded { get; set; } = DateTime.Now;
        // Navigation properties
        [ForeignKey("ProductId")]
        public  Product Product { get; set; }
        public  ApplicationUser User { get; set; }
    }
}
