using StockAppWebApiVS.Models;
using StockAppWebApiVS.Repositories;
using StockAppWebApiVS.ViewModels;

namespace StockAppWebApiVS.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public Task<List<Order>> GetOrderHistory(int userId)
        {
            throw new NotImplementedException();
        }

        public async Task<Order> PlaceOrder(OrderViewModel orderViewModel)
        {
            if (orderViewModel.Quantity <= 0)
            {
                throw new ArgumentException("Quantity must be greater than 0");
            }
            return await _orderRepository.CreateOrder(orderViewModel);
        }
    }

}
