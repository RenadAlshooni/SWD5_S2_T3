using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using TechXpress.Context;
using TechXpress.Models;
using TechXpress_BLL.Services.Contract;

namespace TechXpress.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
       private readonly ICartService _cartService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IproductSevice _productService;
       
        public CartController(ICartService cartService, UserManager<ApplicationUser> userManager , IproductSevice productService)
        {
            _cartService = cartService;
            _userManager = userManager;
            _productService = productService;


        }
        public async Task<IActionResult> Index()
        {
            var userId = _userManager.GetUserId(User);
            var cartItems = await _cartService.GetUserCartItemsAsync(userId);
            var totalPrice =  cartItems.Sum(c => c.Price * c.Quantity);
            ViewBag.TotalPrice = totalPrice;
            return View(cartItems);
        }
        public async Task<IActionResult> AddToCart(int productId ,int quantity = 1)
        {
            var userId = _userManager.GetUserId(User);
            var product = _productService.GetProductById(productId);
            var cartItem = new Cart
            {
                UserId = userId,
                ProductName = product.Name,
                Price = product.Price,
                Image = product.Image,
                ProductId = productId,
                Quantity = quantity
            };
            await _cartService.AddToCartAsync(cartItem);
            return RedirectToAction("Index");
        }
        
        public async Task<IActionResult> RemoveFromCart(int productId)
        {
            var userId = _userManager.GetUserId(User);
            var cartItem = new Cart
            {
                UserId = userId,
                ProductId = productId
            };
            await _cartService.RemoveFromCartAsync(cartItem);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Update(int productId, int quantity)
        {
            var userId = _userManager.GetUserId(User);
            var cartItem = new Cart
            {
                UserId = userId,
                ProductId = productId,
                Quantity = quantity
            };
            await _cartService.UpdateCartAsync(cartItem);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> ClearCart()
        {
            var userId = _userManager.GetUserId(User);
            await _cartService.ClearCartAsync(userId);
            return RedirectToAction("Index");
        }
    }
}
