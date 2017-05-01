using Microsoft.AspNet.SignalR;
using StockQuotes.Providers;
using System;
using System.Collections.Concurrent;
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
        public static ConcurrentDictionary<string, List<string>> userSpecificQoutes = new ConcurrentDictionary<string, List<string>>();
        
        public async void UpdateCallerStockQuotes(string symbol)
        {
            if (!userSpecificQoutes.ContainsKey(Context.ConnectionId))
            {
                userSpecificQoutes[Context.ConnectionId] = new List<string>();
            }
            userSpecificQoutes[Context.ConnectionId].Add(symbol);

            var quotes = await _stockQuotesService.GetSpecificQuotesAsync(userSpecificQoutes[Context.ConnectionId]);
            Clients.Caller.UpdateStock(quotes);
        }
    }
}
