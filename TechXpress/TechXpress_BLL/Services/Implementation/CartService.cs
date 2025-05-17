using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechXpress.Models;
using TechXpress_BLL.Services.Contract;
using TechXpress_DAL.Repositories.Contract;
using Microsoft.AspNetCore.Identity;


namespace TechXpress_BLL.Services.Implementation
{
    public class CartService: ICartService
    {
        private readonly ICartRepository _cartRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        public CartService(ICartRepository cartRepository, UserManager<ApplicationUser> userManager)
        {
            _cartRepository = cartRepository;
            _userManager = userManager;
        }

        public Task<IEnumerable<Cart>> GetUserCartItemsAsync(string userId)
        {
            var cartItems = _cartRepository.GetUserCartItems(userId);
            if (cartItems == null || !cartItems.Any())
            {
                return Task.FromResult(Enumerable.Empty<Cart>());
            }
            return Task.FromResult(cartItems);

        }
        public Task<int> GetCartCountAsync(string userId)
        {

            var cartCount = _cartRepository.GetCartCountAsync(userId);
            if (cartCount == null)
            {
                return Task.FromResult(0);
            }
            return Task.FromResult(cartCount);

        }
        public Task<bool> AddToCartAsync(Cart cart)
        {

            var existingCartItem = _cartRepository.GetUserCartItems(cart.UserId)
                .FirstOrDefault(c => c.ProductId == cart.ProductId && c.IsDeleted == false);
            if (existingCartItem != null)
            {
                existingCartItem.Quantity += cart.Quantity;
                return Task.FromResult(_cartRepository.UpdateCartAsync(existingCartItem));
            }
            else
            {
                return Task.FromResult(_cartRepository.AddToCartAsync(cart));
            }
        }
        public Task<bool> ClearCartAsync(string userId)
        {

            var cartItems = _cartRepository.GetUserCartItems(userId);
            if (cartItems == null || !cartItems.Any())
            {
                return Task.FromResult(false);
            }
            
            var res = _cartRepository.ClearCartAsync(userId);
            return Task.FromResult(res);
        }
       
       
        public Task<bool> RemoveFromCartAsync(Cart cart)
        {

            var existingCartItem = _cartRepository.GetUserCartItems(cart.UserId)
                .FirstOrDefault(c => c.ProductId == cart.ProductId && c.IsDeleted == false);
            if (existingCartItem != null)
            {
                return Task.FromResult(_cartRepository.RemoveFromCartAsync(existingCartItem));
            }
            return Task.FromResult(false);
        }
        public Task<bool> UpdateCartAsync(Cart cart)
        {

            var existingCartItem = _cartRepository.GetUserCartItems(cart.UserId)
                .FirstOrDefault(c => c.ProductId == cart.ProductId && c.IsDeleted == false);
            if (existingCartItem != null)
            {
                existingCartItem.Quantity = cart.Quantity;
                return Task.FromResult(_cartRepository.UpdateCartAsync(existingCartItem));
            }
            return Task.FromResult(false);
        }
    }
   
}
