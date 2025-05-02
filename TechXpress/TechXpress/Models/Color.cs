using System;


namespace TechXpress.Models
{
    public class Color
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<ProductColor>? productColors { get; set; }
    }
}
