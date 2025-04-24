namespace TechXpress.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? SubHeader { get; set; }
        public string? ImageUrl { get; set; }
      
        // Navigation property for related products
        //public List<Product> Products { get; set; } = new List<Product>();
    }
}
