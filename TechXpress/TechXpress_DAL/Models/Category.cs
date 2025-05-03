namespace TechXpress.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Status { get; set; }
        public List<Product>? Products { get; set; } 
    }
}
