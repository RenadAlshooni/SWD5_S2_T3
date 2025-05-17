using System.ComponentModel.DataAnnotations;
using TechXpress.Models;
using TechXpress_DAL.Models;

namespace TechXpress_PL.ViewModels
{
    public class CheckoutViewModel
    {
        public string UserId { get; set; }
        public string FullName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public string PhoneNumber { get; set; }
        public decimal TotalAmount { get; set; }
        public string StripeToken { get; set; }
        [Required(ErrorMessage = "Please select a payment method.")]
        public string PaymentMethod { get; set; } // Stripe or Cash
        public string ErrorMessage { get; set; }

        public List<CartItemViewModel> CartItems { get; set; } = new List<CartItemViewModel>();
    }
}
