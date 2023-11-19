using StockAppWebApiVS.Models;
using StockAppWebApiVS.ViewModels;

namespace StockAppWebApiVS.Repositories
{
    public interface IOrderRepository
    {
        Task<Order> CreateOrder(OrderViewModel orderViewModel);
    }
}
