using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Infrastructure;
using StockQuotes.ConsoleHost.Hubs;
using StockQuotes.Providers;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace StockQuotes.ConsoleHost
{
    class PushService
    {
        private readonly IHubContext _hub;
        private readonly IStockQuotesService _stockQuotesService;
        private Timer _taskTimer;

        public PushService()
        {
            _hub = GlobalHost.ConnectionManager.GetHubContext<StockQuoteHub>();
            _stockQuotesService = new StockQoutesService(new YahooProvider());
        }

        private async void OnTimerElapsed(object sender)
        {
            var allQuotes = await _stockQuotesService.GetAllQuotesAsync();
            _hub.Clients.All.UpdateStocks(allQuotes);
            var userSpecificCollection = new ConcurrentDictionary<string, List<string>>(StockQuoteHub.userSpecificQoutes);

            foreach (var connectionInfo in userSpecificCollection)
            {
                var quotes = await _stockQuotesService.GetSpecificQuotesAsync(connectionInfo.Value);
                _hub.Clients.Client(connectionInfo.Key).UpdateStocks(quotes);
            }       
        }

        public void Start()
        {
            _taskTimer = new Timer(OnTimerElapsed, null, TimeSpan.FromMilliseconds(1000), TimeSpan.FromSeconds(1));
        }

        public void Stop()
        {
            _taskTimer.Dispose();
        }
    }
}
