using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TechXpress_BLL.Contract;

namespace TechXpress.Controllers
{
    public class WishlistController : Controller
    {
        private readonly IWishlistService _wishlistService;
        public WishlistController(IWishlistService wishlistService)
        {
            _wishlistService = wishlistService;
        }

        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var wishlistItems = await _wishlistService.GetUserWishlistAsync(userId);

            return View(wishlistItems);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddItem(int productId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = await _wishlistService.AddToWishlistAsync(userId, productId);

            return View(result);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveItem(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = await _wishlistService.RemoveFromWishlistAsync(userId, id);

            return View(result);
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
