
using TechXpress_BLL.Dtos;
using Stripe.Climate;

namespace TechXpress_BLL.Services.Contract
{
    public interface IPaymentService
    {
        Task<string> CreatePaymentAsync(OrderDto order);
        Task<bool> ExecutePaymentAsync(string paymentId, string payerId);
    }
}
