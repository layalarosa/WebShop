using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace WebShop.Models
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly ShoppingCart _shoppingCart;
        private readonly ILogger<OrderRepository> _logger;

        public OrderRepository(AppDbContext appDbContext, ShoppingCart shoppingCart, ILogger<OrderRepository> logger)
        {
            _appDbContext = appDbContext;
            _shoppingCart = shoppingCart;
            _logger = logger;
        }

        public async Task CreateOrderAsync(Order order)
        {
            order.OrderPlaced = DateTime.Now;

            var shoppingCartItems = _shoppingCart.ShoppingCartItems;
            order.OrderTotal = _shoppingCart.GetShoppingCartTotal();

            order.OrderDetails = new List<OrderDetail>();
            //adding the order with its details

            foreach (var shoppingCartItem in shoppingCartItems)
            {
                var orderDetail = new OrderDetail
                {
                    Amount = shoppingCartItem.Amount,
                    GameId = shoppingCartItem.Game.GameId,
                    Price = shoppingCartItem.Game.Price
                };

                order.OrderDetails.Add(orderDetail);
            }

            _appDbContext.Orders.Add(order);

            await _appDbContext.SaveChangesAsync();

            _logger.LogInformation("Order {OrderId} created with {Count} items and total {Total}.", order.OrderId, order.OrderDetails?.Count ?? 0, order.OrderTotal);
        }
    }
}
