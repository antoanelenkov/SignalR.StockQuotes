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
    class StockQuoteHub : Hub
    {
        private IStockQuotesService _stockQuotesService;

        public StockQuoteHub(IStockQuotesService stockQuotesService)
        {
            this._stockQuotesService = stockQuotesService;
        }

        public StockQuoteHub()
        {
            this._stockQuotesService = new StockQoutesService(new YahooProvider());
            new Timer(
                e => UpdateStockQuotes(),
                null,
                TimeSpan.Zero,
                TimeSpan.FromMilliseconds(1000));
        }

        public void Send(string symbol, decimal? ask)
        {
            Clients.All.UpdateStock(symbol, ask);
        }

        private void UpdateStockQuotes()
        {
           var quotes =  this._stockQuotesService.GetAllQuotes();
            var first = quotes.FirstOrDefault();
            Send(first?.Symbol,first?.Ask);
        }
    }
}
