using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechXpress_BLL.Contract;
using TechXpress_DAL.Contract;
using TechXpress_DAL.Implementation;
using TechXpress_DAL.Models;
using TechXpress_DAL.Repositories.Contract;
using TechXpress_PL.ViewModels;

namespace TechXpress_BLL.Implementation
{
    public class WishlistService : IWishlistService
    {

        private readonly IWishlistRepository _wishlistRepository;
        private readonly IProductsRepository _productRepository;

        public WishlistService(IWishlistRepository wishlistRepository, IProductsRepository productRepository)
        {
            _wishlistRepository = wishlistRepository;
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Wishlist>> GetUserWishlistAsync(string userId)
        {
            return await _wishlistRepository.GetUserWishlistItemsAsync(userId);
        }

        public async Task<WishlistOperationResult> AddToWishlistAsync(string userId, int productId)
        {
            // Check if item already exists in wishlist
            var existingItem = await _wishlistRepository.GetWishlistItemAsync(userId, productId);

            if (existingItem != null)
            {
                return new WishlistOperationResult
                {
                    Success = false,
                    Message = "Item already in wishlist"
                };
            }

            // Get product details
            var product = await _productRepository.GetByIdAsync(productId);
            if (product == null)
            {
                return new WishlistOperationResult
                {
                    Success = false,
                    Message = "Product not found"
                };
            }

            // Add new item to wishlist
            var wishlistItem = new Wishlist
            {
                UserId = userId,
                ProductId = productId,
                DateAdded = DateTime.Now
            };

            await _wishlistRepository.AddToWishlistAsync(wishlistItem);
            await _wishlistRepository.SaveChangesAsync();

            return new WishlistOperationResult
            {
                Success = true,
                Message = "Item added to wishlist",
                Item = new WishlistVm
                {
                    Id = wishlistItem.Id,
                    ProductId = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    ImageUrl = product.Image
                }
            };
        }

        public async Task<WishlistOperationResult> RemoveFromWishlistAsync(string userId, int wishlistItemId)
        {
            var wishlistItem = await _wishlistRepository.GetByIdAsync(wishlistItemId);

            if (wishlistItem == null || wishlistItem.UserId != userId)
            {
                return new WishlistOperationResult
                {
                    Success = false,
                    Message = "Item not found"
                };
            }

            await _wishlistRepository.RemoveFromWishlistAsync(wishlistItem);
            await _wishlistRepository.SaveChangesAsync();

            return new WishlistOperationResult
            {
                Success = true,
                Message = "Item removed from wishlist"
            };
        }

        public async Task<int> GetWishlistCountAsync(string userId)
        {
            return await _wishlistRepository.GetWishlistCountAsync(userId);
        }
    }
}
    

