using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechXpress_DAL.Models;

namespace TechXpress_DAL.Contract
{
    public interface IWishlistRepository
    {

        Task<IEnumerable<Wishlist>> GetUserWishlistItemsAsync(string userId);
        Task<Wishlist> GetWishlistItemAsync(string userId, int productId);
        Task<int> GetWishlistCountAsync(string userId);
        Task<Wishlist> GetByIdAsync(int id);
        Task<bool> AddToWishlistAsync(Wishlist wishlist);
        Task<bool> RemoveFromWishlistAsync(Wishlist wishlist);
        Task<bool> SaveChangesAsync();

    }
}
