using StockQuotes.Providers;
using System.Collections.Generic;

namespace StockQuotes.ConsoleHost.Hubs
{
    public interface IStockClient
    {
        void UpdateStock(IEnumerable<QuoteDTO> qoutes);
    }
}