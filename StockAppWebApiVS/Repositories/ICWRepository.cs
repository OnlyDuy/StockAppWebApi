using StockAppWebApiVS.Models;

namespace StockAppWebApiVS.Repositories
{
    public interface ICWRepository
    {
        Task<List<CoveredWarrant>> GetCoveredWarrantsByStockId(int stockId);
    }
}
