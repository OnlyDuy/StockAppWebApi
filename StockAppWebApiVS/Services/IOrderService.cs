using StockAppWebApiVS.Models;
using StockAppWebApiVS.ViewModels;

namespace StockAppWebApiVS.Services
{
    public interface IOrderService
    {
        Task<Order> PlaceOrder(OrderViewModel orderViewModel);
        Task<List<Order>> GetOrderHistory(int userId);//select * from orders where user_id=??
        //Hãy viết thử hàm này, coi như là bài tập
    }
}
