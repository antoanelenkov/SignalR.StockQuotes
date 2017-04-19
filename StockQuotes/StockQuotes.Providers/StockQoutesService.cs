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

        private List<string> _quoteSymbols = new List<string>() { "AAPL", "MSFT" };

        public StockQoutesService(IProvider provider)
        {
            this._provider = provider;
        }

        public QuoteDTO Get(string symbol)
        {
            return this._provider.Fetch(new List<string>() { symbol }).FirstOrDefault();
        }

        public IEnumerable<QuoteDTO> GetAllQuotes()
        {
            return this._provider.Fetch(_quoteSymbols);
        }

        public IEnumerable<QuoteDTO> GetAllQuotes(IEnumerable<string> symbols)
        {
            return this._provider.Fetch(symbols);
        }
    }
}
