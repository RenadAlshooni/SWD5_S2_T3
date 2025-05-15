

using TechXpress.Models;

namespace TechXpress_DAL.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public string PaymentMethod { get; set; }
        public string PaymentStatus { get; set; }
        public double Amount { get; set; }
        public int ApplicationUserId { get; set; }
        public int OrderId { get; set; }

        public ApplicationUser applicationUser;
        public Order order;
    }
}
