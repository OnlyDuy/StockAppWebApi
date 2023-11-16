using StockAppWebApiVS.Models;

namespace StockAppWebApiVS.Repositories
{
    public interface IQuoteRepository
    {
        Task<List<RealtimeQuote>?> GetRealtimeQuotes(
            int page,
            int limit,
            string sector,
            string industry);
    }
}
