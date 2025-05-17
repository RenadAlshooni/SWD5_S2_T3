using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using TechXpress.Context;
using TechXpress.Models;
using TechXpress_BLL.Dtos;
using TechXpress_BLL.Services.Contract;
using TechXpress_PL.ViewModels;

namespace TechXpress.Controllers
{
    [Authorize]
    public class CheckoutController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IPaymentService _paymentService;
        private readonly ILogger<CheckoutController> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ApplicationDbContext _db;

        public CheckoutController(IOrderService orderService, IPaymentService paymentService, ILogger<CheckoutController> logger,ApplicationDbContext db, IHttpContextAccessor httpContextAccessor)
        {
            _orderService = orderService;
            _paymentService = paymentService;
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
            _db = db;
        }

        [HttpGet]
        public IActionResult Index()
        {

            // Load cart from session or db
            var model = new CheckoutViewModel
            {
                CartItems = LoadCartItems(),
                TotalAmount = CalculateTotal(LoadCartItems())
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult PlaceOrder(CheckoutDto model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    
                    var errorViewModel = new CheckoutViewModel
                    {
                        CartItems = LoadCartItems(),
                        TotalAmount = model.TotalAmount,

                        
                        FullName = model.FullName,
                        Email = model.Email,
                        Address = model.Address,
                        City = model.City,
                        Country = model.Country,
                        ZipCode = model.ZipCode,
                        PhoneNumber = model.PhoneNumber,
                        PaymentMethod = model.PaymentMethod,
                        ErrorMessage = "Please fill in all required fields."

                    };

                    return View("Index", errorViewModel);
                }

                
                if (model.PaymentMethod == "Stripe")
                {
                    var chargeId = _paymentService.ChargeCard(model.StripeToken, model.TotalAmount, "usd");
                }

                int orderId = _orderService.CreateOrder(model);
                return RedirectToAction("Success", new { id = orderId });
            }
            catch (Exception ex)
            {
                
                _logger.LogError(ex, "Error during order placement");

                
                var errorViewModel = new CheckoutViewModel
                {
                    CartItems = LoadCartItems(),
                    TotalAmount = model.TotalAmount,
                    ErrorMessage = "Error during order placement"
                };

                return View("Index", errorViewModel);
            }
        }
        public IActionResult Success(int id)
        {
            ViewBag.OrderId = id;
            return View();
        }

        private List<CartItemViewModel> LoadCartItems()
        {
            
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            
            if (string.IsNullOrEmpty(userId))
            {
                return new List<CartItemViewModel>();
            }


            var cartItems = _db.Carts
                .Where(c => c.UserId == userId)
                .Select(c => new CartItemViewModel
                {
                    ProductId = c.ProductId,
                    ProductName = c.ProductName,
                    Price = c.Price,
                    Quantity = c.Quantity
                    
                })
                .ToList();

            return cartItems;
        }

        private decimal CalculateTotal(List<CartItemViewModel> items)
        {
            return items.Sum(i => i.Price * i.Quantity);
        }
    }
}
