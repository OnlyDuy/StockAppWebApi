using StockAppWebApiVS.Models;

namespace StockAppWebApiVS.Repositories
{
    public interface IStockRepository
    {
        Task<Stock?> GetStockById(int stockId);
    }
}
