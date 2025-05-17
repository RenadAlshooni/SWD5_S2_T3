

namespace TechXpress_BLL.Dtos
{
    public class CheckoutDto
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public string PhoneNumber { get; set; }
        public int TotalAmount { get; set; }
        public string StripeToken { get; set; }
        public string PaymentMethod { get; set; } // Stripe or Cash

        public List<CartItemDto> CartItems { get; set; } = new List<CartItemDto>();
    }
}
