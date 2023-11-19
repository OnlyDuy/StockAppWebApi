using StockAppWebApiVS.Models;

namespace StockAppWebApiVS.Services
{
    public interface ICWService
    {
        Task<List<CoveredWarrant>> GetCoveredWarrantsByStockId(int stockId);
    }
}
