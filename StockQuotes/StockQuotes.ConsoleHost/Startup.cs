namespace StockQuotes.ConsoleHost
{
    using Microsoft.Owin.Cors;
    using Owin;

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(CorsOptions.AllowAll);
            app.MapSignalR();
            new PushService().Start();
        }
    }
}
