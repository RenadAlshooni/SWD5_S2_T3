using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechXpress.Context;
using TechXpress.Models;
using TechXpress_DAL.Repositories.Contract;

namespace TechXpress_DAL.Repositories.Implementation
{
    public class CartRepository : ICartRepository
    {
        private readonly ApplicationDbContext _context;
        public CartRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Cart> GetUserCartItems(string userId)
        {
            var cartItems = _context.Carts
                .Where(c => c.UserId == userId && c.IsDeleted == false);

            return cartItems;
        }
        public int GetCartCountAsync(string userId)
        {
            var cartCount = _context.Carts
                .Where(c => c.UserId == userId && c.IsDeleted == false)
                .Sum(c => c.Quantity);
            return cartCount;
        }
        public bool AddToCartAsync(Cart cart)
        {

            var existingCartItem = _context.Carts
                .FirstOrDefault(c => c.ProductId == cart.ProductId && c.UserId == cart.UserId && c.IsDeleted == false);
           
               _context.Carts.Add(cart);
           
            return SaveChangesAsync();

        }
        public bool RemoveFromCartAsync(Cart cart)
        {
            var existingCartItem = _context.Carts
                .FirstOrDefault(c => c.ProductId == cart.ProductId && c.UserId == cart.UserId && c.IsDeleted == false);
            if (existingCartItem != null)
            {
                _context.Carts.Remove(existingCartItem);
                //_context.Carts.Update(existingCartItem); if IsDeleted is true 
            }
            return SaveChangesAsync();

        }
        public bool UpdateCartAsync(Cart cart)
        {
            var existingCartItem = _context.Carts
                .FirstOrDefault(c => c.ProductId == cart.ProductId && c.UserId == cart.UserId && c.IsDeleted == false);
           
             _context.Carts.Update(existingCartItem);
            
            return SaveChangesAsync();
        }
        public bool ClearCartAsync(string userId)
        {
            var cartItems = _context.Carts
                .Where(c => c.UserId == userId && c.IsDeleted == false)
                .ToList();
            foreach (var item in cartItems)
            {
                _context.Carts.Remove(item);
                //item.IsDeleted = true;
                //_context.Carts.Update(item);
            }
            return SaveChangesAsync();

        }
        public bool SaveChangesAsync()
        {
            return _context.SaveChanges() > 0;
        }
    }

}
