using Microsoft.AspNetCore.Mvc;
using Stripe.Checkout;
using TechXpress.Context;
using TechXpress_BLL.Dtos;
using TechXpress_BLL.Services.Contract;

namespace TechXpress_PL.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IPaymentService _paymentService;
        private readonly ApplicationDbContext _context;
        public PaymentController(IPaymentService paymentService, ApplicationDbContext context)
        {
            _paymentService = paymentService;
            _context = context;
        }
        [HttpGet]
        public IActionResult Checkout(int orderId)
        {
            var order = _context.Orders.Find(orderId);
            if (order == null)
            {
                return NotFound();
            }
            var orderDto = new OrderDto
            {
                Id = order.Id,
                Amount = order.Amount,
                Currency = "usd", // Set the currency as needed
                OrderItems = order.OrderItems.Select(oi => new OrderItemDto
                {
                    ProductId = oi.ProductId,
                    Quantity = oi.ProductQuantity
                }).ToList()
            };
            return View(orderDto);
        }
        [HttpPost]
        public async Task<IActionResult> CreateSession(OrderDto orderDto)
        {
            var order = _context.Orders.Find(orderDto.Id);
            if (order == null)
            {
                return NotFound();
            }
            var sessionId = await _paymentService.CreatePaymentAsync(orderDto);
            if (string.IsNullOrEmpty(sessionId))
            {
                return BadRequest("Failed to create payment session.");
            }

            return Json(new { sessionId });
        }
        [HttpGet]
        public IActionResult Success(string sessionId)
        {
            // Here you can retrieve the session details and update your order status in the database
            // For example, you can use the sessionId to get the session details from Stripe
            var service = new SessionService();
            var session = service.Get(sessionId);
            if (session == null)
            {
                return NotFound();
            }
            // Update order status in your database if needed
            return View(session);
        }
        [HttpGet]
        public IActionResult Cancel()
        {
            // Handle the cancellation of the payment
            return View();
        }
    }
}
