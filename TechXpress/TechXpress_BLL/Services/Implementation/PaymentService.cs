using Microsoft.Extensions.Configuration;
using Stripe;
using Stripe.Checkout;
using Stripe.Climate;
using TechXpress_BLL.Dtos;
using TechXpress_BLL.Services.Contract;

namespace TechXpress_BLL.Services.Implementation
{
    public class PaymentService : IPaymentService
    {
        public PaymentService(IConfiguration configuration)
        {
            StripeConfiguration.ApiKey = configuration["Stripe:SecretKey"];
        }

        public string ChargeCard(string stripeToken, decimal amount, string currency)
        {
            var options = new ChargeCreateOptions
            {
                Amount = (long)(amount * 100),
                Currency = currency,
                Description = "Order payment",
                Source = stripeToken
            };

            var service = new ChargeService();
            var charge = service.Create(options);

            if (charge.Status == "succeeded")
            {
                return charge.Id;
            }

            throw new Exception("Payment failed.");
        }
    }
}
