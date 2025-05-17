
using TechXpress_BLL.Dtos;
using Stripe.Climate;

namespace TechXpress_BLL.Services.Contract
{
    public interface IPaymentService
    {
        string ChargeCard(string stripeToken, decimal amount, string currency);
    }
}
