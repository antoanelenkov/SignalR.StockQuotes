using Microsoft.AspNet.SignalR;
using StockQuotes.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StockQuotes.ConsoleHost.Hubs
{
    public class StockQuoteHub : Hub<IStockClient>
    {
        private static IStockQuotesService _stockQuotesService = new StockQoutesService(new YahooProvider());

        public void SendToAll(string symbol, decimal? ask)
        {
            Clients.All.UpdateStock(symbol, ask);
        }

        public void SendToCaller(string symbol, decimal? ask)
        {
            Clients.Caller.UpdateStock(symbol, ask);
        }

        public async Task GetUpdate(string symbol)
        {
            await UpdateCallerStockQuote(symbol);
        }

        private void UpdateStockQuotes()
        {
            var quotes = _stockQuotesService.GetAllQuotes();
            var first = quotes.FirstOrDefault();
            SendToAll(first?.Symbol, first?.Ask);
        }

        private async Task UpdateCallerStockQuote(string symbol)
        {
            var quote = await _stockQuotesService.GetAsync(symbol);
            SendToCaller(quote?.Symbol, quote?.Ask);
        }
    }
}
