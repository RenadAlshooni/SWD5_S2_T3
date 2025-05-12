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
        private readonly IConfiguration _configuration;
        public PaymentService(IConfiguration configuration)
        {
            _configuration = configuration;
            StripeConfiguration.ApiKey = _configuration["Stripe:SecretKey"];
        }
        public async Task<string> CreatePaymentAsync(OrderDto order)
        {
            var options = new SessionCreateOptions
            {
                PaymentMethodTypes = new List<string> { "card" },
                LineItems = new List<SessionLineItemOptions>
                {
                    new SessionLineItemOptions
                    {
                        PriceData = new SessionLineItemPriceDataOptions
                        {
                            UnitAmount = order.Amount * 100,
                            Currency = order.Currency,
                            ProductData = new SessionLineItemPriceDataProductDataOptions
                            {
                                Name = $"Order {order.Id}"
                            }
                        },
                        Quantity = 1
                    }
                },
                Mode = "payment",
                SuccessUrl = _configuration["Stripe:SuccessUrl"],
                CancelUrl = _configuration["Stripe:CancelUrl"]
            };
            var service = new SessionService();
            Session session = await service.CreateAsync(options);
            return session.Id;

        }
        public Task<bool> ExecutePaymentAsync(string paymentId, string payerId)
        {
            // This method is not typically used with Stripe Checkout, as the payment is automatically captured
            // when the session is completed. However, if you need to handle post-payment actions, you can do so here.
            // For example, you might want to update your order status in your database.
            // In this case, we will just return true to indicate that the payment was successful.
            return Task.FromResult(true);
        }
       
    }
}
