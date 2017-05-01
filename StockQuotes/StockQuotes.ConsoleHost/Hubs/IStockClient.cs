namespace StockQuotes.ConsoleHost.Hubs
{
    public interface IStockClient
    {
        void UpdateStock(string symbol, decimal? ask);
    }
}