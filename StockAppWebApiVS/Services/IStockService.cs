using StockAppWebApiVS.Models;

namespace StockAppWebApiVS.Services
{
    public interface IStockService
    {
        Task<Stock?> GetStockById(int stockId);
    }
}
