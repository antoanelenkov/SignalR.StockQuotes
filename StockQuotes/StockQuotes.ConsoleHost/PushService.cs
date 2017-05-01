using Microsoft.AspNet.SignalR;
using StockQuotes.ConsoleHost.Hubs;
using StockQuotes.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
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

        private void OnTimerElapsed(object sender)
        {
            var quotes = _stockQuotesService.GetAllQuotes();
            var first = quotes.FirstOrDefault();
            _hub.Clients.All.UpdateStock(first.Symbol, first.Ask);
        }

        public void Start()
        {
            _taskTimer = new Timer(OnTimerElapsed, null, TimeSpan.FromMilliseconds(500), TimeSpan.FromSeconds(1));
        }

        public void Stop()
        {
            _taskTimer.Dispose();
        }
    }
}
