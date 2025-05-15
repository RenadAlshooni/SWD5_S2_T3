using TechXpress.Models;
using TechXpress_DAL.Models;

namespace TechXpress_PL.ViewModels
{
    public class CheckoutVm
    {
        public BillingInfo BillingInfo { get; set; }

        public List<OrderItem> OrderItems { get; set; }

        public decimal? TotalAmount { get; set; }

        public List<string> PaymentMethods { get; set; }

        public string SelectedPaymentMethod { get; set; }
    }
}
