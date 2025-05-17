using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechXpress.Models;

namespace TechXpress_DAL.Repositories.Contract
{
   public interface ICartRepository
   {
        public IEnumerable<Cart> GetUserCartItems(string userId);
        int GetCartCountAsync(string userId);
        bool AddToCartAsync(Cart cart);
        bool RemoveFromCartAsync(Cart cart);
        bool UpdateCartAsync(Cart cart);
        bool ClearCartAsync(string userId);
        bool SaveChangesAsync();


    }
}
