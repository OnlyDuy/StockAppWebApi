using StockAppWebApiVS.Models;
using StockAppWebApiVS.Repositories;

namespace StockAppWebApiVS.Services
{
    public class QuoteService : IQuoteService
    {
        // Interface gọi ra Repository -> Cần Inject
        private readonly IQuoteRepository _quoteRepository;
        public QuoteService(IQuoteRepository quoteRepository)
        {
            _quoteRepository = quoteRepository;
        }

        public async Task<List<Quote>> GetHistoricalQuotes(int days, int stockId)
        {
            return await _quoteRepository.GetHistoricalQuotes(days, stockId);
        }

        public async Task<List<RealtimeQuote>?> GetRealtimeQuotes(
            int page, int limit, string sector, string industry)
        {
            return await _quoteRepository.GetRealtimeQuotes(page, limit, sector, industry);
        }
    }
}
