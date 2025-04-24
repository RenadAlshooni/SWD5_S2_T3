using System.Collections.Generic;

namespace TechXpress.Models
{
    public class Cart
    {

        public int Id { get; set; }
        public string UserId { get; set; }
        public int Quantity { get; set; } = 0;
        public bool IsDeleted { get; set; } = false;
        public List<Product>? Products { get; set; }
    }
}
