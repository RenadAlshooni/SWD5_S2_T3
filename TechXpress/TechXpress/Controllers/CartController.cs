using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            var totalPrice = userCart.Sum(c => c.Price * c.Quantity);
            ViewBag.TotalPrice = totalPrice;
            var carts = _context.Carts.ToList();
            int cartCount = carts.Count(c => c.UserId == userId && !c.IsDeleted);
            var Wishlists = _context.Wishlists.ToList();
            int wishlistCount = Wishlists.Count(c => c.UserId == userId);
            ViewBag.Carts = cartCount;
            ViewBag.Wishlists = wishlistCount;
            return View(userCart);
        }
        public IActionResult Update(int productId,int Quantity)
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            var cartItem = _context.Carts.Where(c => c.ProductId == productId && userId == c.UserId).First();
            cartItem.Quantity = Quantity;
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        public IActionResult AddToCart(int productId ,int quantity = 1)
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            var cart = _context.Carts.Include(c => c.Products).Where(c => c.UserId == userId && c.IsDeleted == false).ToList();
                var product = _context.Products.FirstOrDefault(p => p.Id == productId);
            var existingCartItem = cart.FirstOrDefault(c => c.ProductId == productId && c.UserId == userId);
            if (existingCartItem != null)
            {
                existingCartItem.Quantity++;
            }
            else
            {
                _context.Add(new Cart {
                    ProductId = productId,
                    ProductName = product.Name,
                    UserId = userId,
                    Quantity = quantity,
                    IsDeleted = false,
                    CreatedAt = DateTime.UtcNow,
                    Price = product.Price,
                    Image = product.Image
                });
            }
            _context.SaveChanges();
            
            return RedirectToAction("Index");
        }

        public IActionResult RemoveFromCart(int productId)
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            var cartItem = _context.Carts.Include(c => c.Products ).Where(c => c.ProductId == productId && userId == c.UserId).First();
            if (cartItem != null)
            {
                _context.Remove(cartItem);
                _context.SaveChanges();
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
