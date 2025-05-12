namespace TechXpress_BLL.Dtos
{
    public class OrderDto
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Currency { get; set; }
        public string Status { get; set; }
        public List<OrderItemDto> OrderItems { get; set; }
    }
}
