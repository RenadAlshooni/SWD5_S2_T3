using System;

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
        public User? User { get; set; }
        public List<OrderItem>? OrderItems { get; set; }
    }
}
