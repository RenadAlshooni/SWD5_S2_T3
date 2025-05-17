using System;
using System.ComponentModel.DataAnnotations;

namespace TechXpress.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public string? status { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public DateTime UpdateDate { get; set; } = DateTime.Now;
        public DateTime ShippingDate { get; set; }
        public float ShippingFee { get; set; }
        public int UserId { get; set; }
        public ApplicationUser? User { get; set; }
        public List<OrderItem>? OrderItems { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        [Required]
        public string ZipCode { get; set; }
        public string OrderStatus { get; set; }

    }
}
