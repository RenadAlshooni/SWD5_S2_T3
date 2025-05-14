using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechXpress_DAL.Models;
using TechXpress_PL.ViewModels;

namespace TechXpress_BLL.Contract
{
    public interface IWishlistService
    {
        Task<IEnumerable<Wishlist>> GetUserWishlistAsync(string userId);
        Task<WishlistOperationResult> AddToWishlistAsync(string userId, int productId);
        Task<WishlistOperationResult> RemoveFromWishlistAsync(string userId, int wishlistItemId);
        Task<int> GetWishlistCountAsync(string userId);
    }
}
