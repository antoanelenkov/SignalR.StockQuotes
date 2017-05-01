using StockQuotes.Providers.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockQuotes.Providers
{
    public class StockQoutesService : IStockQuotesService
    {
        private readonly IProvider _provider;

        private List<string> _quoteSymbols = new List<string>() { "AAPL", "MSFT", "BP", "AMD", "PFE", "GILD", "CHTR", "MA", "MRK" };

        public StockQoutesService(IProvider provider)
        {
            this._provider = provider;
        }

        public async Task<IEnumerable<QuoteDTO>> GetAllQuotesAsync()
        {
            return await Task.Run(() => { return this._provider.Fetch(_quoteSymbols); });
        }

        public async Task<IEnumerable<QuoteDTO>> GetSpecificQuotesAsync(IEnumerable<string> symbols)
        {
            return await Task.Run(() => { return this._provider.Fetch(symbols); });
        }

        public async Task<QuoteDTO> GetAsync(string symbol)
        {
            return await Task.Run(() =>
             { return this._provider.Fetch(new List<string>() { symbol }).FirstOrDefault(); });
        }
    }
}
