namespace StockQuotes.ConsoleHost
{
    using Microsoft.AspNet.SignalR;
    using Microsoft.Owin.Cors;
    using Owin;
    using System;
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(CorsOptions.AllowAll);
            ConfigureGlobalHost();
            app.MapSignalR();
            new PushService().Start();
        }

        private void ConfigureGlobalHost()
        {
            GlobalHost.Configuration.ConnectionTimeout = TimeSpan.FromSeconds(60);
            GlobalHost.Configuration.DisconnectTimeout = TimeSpan.FromSeconds(30);
            GlobalHost.Configuration.TransportConnectTimeout = TimeSpan.FromSeconds(5);
        }
    }
}
