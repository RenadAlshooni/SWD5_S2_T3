using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechXpress.Context;
using TechXpress_DAL.Contract;
using TechXpress_DAL.Models;

namespace TechXpress_DAL.Implementation
{
    public class WishlistRepository : IWishlistRepository
    {
        private readonly ApplicationDbContext _context;
        public WishlistRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Wishlist>> GetUserWishlistItemsAsync(string userId)
        {
            return await _context.Wishlists
                .Include(w => w.Product)
                .Where(w => w.UserId == userId)
                .ToListAsync();
        }

        public async Task<Wishlist> GetWishlistItemAsync(string userId, int productId)
        {
            return await _context.Wishlists
                .FirstOrDefaultAsync(w => w.UserId == userId && w.ProductId== productId);
        }

        public async Task<int> GetWishlistCountAsync(string userId)
        {
            return await _context.Wishlists.CountAsync(w => w.UserId == userId);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> AddToWishlistAsync(Wishlist wishlist)
        {
            await _context.Wishlists.AddAsync(wishlist);
            return await SaveChangesAsync();
        }

        public async Task<bool> RemoveFromWishlistAsync(Wishlist wishlist)
        {
            _context.Wishlists.Remove(wishlist);
            return await SaveChangesAsync();
        }
        public async Task<Wishlist> GetByIdAsync(int id)
        {
            return await _context.Wishlists.FindAsync(id);
        }




    }
    
}

