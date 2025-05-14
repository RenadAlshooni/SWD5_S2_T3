using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TechXpress.Context;
using TechXpress.Models;

namespace TechXpress.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public CartController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        private const string CartSessionKey = "UserCart";

        private List<Cart> GetCart()
        {
            var sessionData = HttpContext.Session.GetString(CartSessionKey);
            if (string.IsNullOrEmpty(sessionData))
                return new List<Cart>();

            return JsonConvert.DeserializeObject<List<Cart>>(sessionData);
        }

        private void SaveCart(List<Cart> cart)
        {
            HttpContext.Session.SetString(CartSessionKey, JsonConvert.SerializeObject(cart));
        }


        public IActionResult Index()
        {
            //var cart = GetCart();
            var cart = _context.Carts.ToList();
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            var userCart = cart.Where(c => c.UserId == userId && c.IsDeleted == false).ToList();
            return View(userCart);
        }

        public IActionResult AddToCart(int productId ,string ProductName, decimal price, string imageUrl , int quantity = 1)
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            var cart = _context.Carts.Where(c => c.UserId == userId && c.IsDeleted == false).ToList();
            var existingCartItem = cart.FirstOrDefault(c => c.ProductId == productId && c.UserId == userId);
            if (existingCartItem != null)
            {
                existingCartItem.Quantity++;
            }
            else
            {
                _context.Add(new Cart {
                    ProductId = productId,
                    ProductName = ProductName,
                    UserId = userId,
                    Quantity = quantity,
                    IsDeleted = false,
                    CreatedAt = DateTime.UtcNow,
                    Price = price
                });
            }
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult RemoveFromCart(int productId)
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            var cart = GetCart();
            var cartItem = cart.FirstOrDefault(c => c.ProductId == productId && c.UserId == userId);
            if (cartItem != null)
            {
                cartItem.IsDeleted = true;
                SaveCart(cart);
            }
            return RedirectToAction("Index");
        }
        public IActionResult ClearCart()
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            var cart = GetCart();
            cart.RemoveAll(c => c.UserId == userId);
            SaveCart(cart);
            return RedirectToAction("Index");
        }
    }
}
