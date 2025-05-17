using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechXpress.Models;

namespace TechXpress_BLL.Services.Contract
{
    public interface ICartService
    {
        Task<IEnumerable<Cart>> GetUserCartItemsAsync(string userId);
        Task<int> GetCartCountAsync(string userId);
        Task<bool> AddToCartAsync(Cart cart);
        Task<bool> RemoveFromCartAsync(Cart cart);
        Task<bool> UpdateCartAsync(Cart cart);
        Task<bool> ClearCartAsync(string userId);
     
    }
}
