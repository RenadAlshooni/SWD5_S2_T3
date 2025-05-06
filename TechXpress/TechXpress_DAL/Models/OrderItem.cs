

namespace TechXpress.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int ProductQuantity { get; set; }
        public float PriceAtPurchase { get; set; }
        public Order? Order { get; set; }
        public Product? Product { get; set; }

        #region ProductDetails For caching
        public string? Name { get; set; }
        public string? Description { get; set; }
        public float Price { get; set; }
        //public int CategoryId { get; set; }
        //public Category? Category { get; set; }

        #endregion
    }
}
