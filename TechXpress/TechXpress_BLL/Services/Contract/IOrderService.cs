

using TechXpress_BLL.Dtos;

namespace TechXpress_BLL.Services.Contract
{
    public interface IOrderService
    {
        int CreateOrder(CheckoutDto model); // يرجع الـ OrderId
    }
}
