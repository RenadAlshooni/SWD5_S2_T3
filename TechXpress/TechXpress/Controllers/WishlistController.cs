using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TechXpress.Context;
using TechXpress_BLL.Contract;

namespace TechXpress.Controllers
{
    public class WishlistController : Controller
    {
        private readonly IWishlistService _wishlistService;
        private readonly ApplicationDbContext _context;
        public WishlistController(ApplicationDbContext context,IWishlistService wishlistService)
        {
            _wishlistService = wishlistService;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var wishlistItems = await _wishlistService.GetUserWishlistAsync(userId);

            var carts = _context.Carts.ToList();
            int cartCount = carts.Count(c => c.UserId == userId && !c.IsDeleted);
            var Wishlists = _context.Wishlists.ToList();
            int wishlistCount = Wishlists.Count(c => c.UserId == userId);
            ViewBag.Carts = cartCount;
            ViewBag.Wishlists = wishlistCount;
            return View(wishlistItems);
        }

        
        
       
        public async Task<IActionResult> AddItem(int productId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = await _wishlistService.AddToWishlistAsync(userId, productId);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> RemoveItem(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = await _wishlistService.RemoveFromWishlistAsync(userId, id);

            return RedirectToAction("Index");
        }

        
        [HttpGet]
        public async Task<IActionResult> Count()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var count = await _wishlistService.GetWishlistCountAsync(userId);

            return View(new { count });
        }
    }
}
