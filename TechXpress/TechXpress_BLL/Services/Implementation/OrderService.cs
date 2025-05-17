

using System;
using TechXpress.Context;
using TechXpress.Models;
using TechXpress_BLL.Dtos;
using TechXpress_BLL.Services.Contract;

namespace TechXpress_BLL.Services.Implementation
{
    public class OrderService:IOrderService
    {
        private readonly ApplicationDbContext _context;

        public OrderService(ApplicationDbContext context)
        {
            _context = context;
        }

        public int CreateOrder(CheckoutDto model)
        {
            var order = new Order
            {
                UserId = model.UserId,
                FullName = model.FullName,
                Email = model.Email,
                Address = model.Address,
                City = model.City,
                Country = model.Country,
                ZipCode = model.ZipCode,
                PhoneNumber = model.PhoneNumber,
                CreationDate = DateTime.UtcNow,
                Amount = model.TotalAmount,
                OrderStatus = "Pending",
                OrderItems = new List<OrderItem>()
            };

            foreach (var item in model.CartItems)
            {
                order.OrderItems.Add(new OrderItem
                {
                    ProductId = item.ProductId,
                    ProductQuantity = item.Quantity,
                    PriceAtPurchase = item.Price
                });
            }

            _context.Orders.Add(order);
            _context.SaveChanges();

            return order.Id;
        }
    }
}
