namespace TechExpress.Models
{
    public class Product
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int price { get; set; }
        public int UnitInStock { get; set; }

        public bool HasDiscount { get; set; }
        public int Discount { get; set; } 

        public DateTime CreatedAt { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public int BrandId { get; set; }
       // public Brand Brand { get; set; }

       // public List<ProductColor> ProductColors { get; set; }





    }
}
