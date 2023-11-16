using StockAppWebApiVS.Models;

namespace StockAppWebApiVS.Services
{
    public interface IQuoteService
    {
        // ? nghĩa là có thể trả về 1 list rỗng (optional)
        Task<List<RealtimeQuote>?> GetRealtimeQuotes(
            int page,
            int limit,
            string sector,
            string industry);
        Task<List<Quote>> GetHistoricalQuotes(int days, int stockId);
    }
}
