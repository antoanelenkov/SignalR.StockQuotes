namespace StockQuotes.Providers
{
    public class QuoteDTO
    {
        public string Symbol { get; set; }

        public decimal? Ask { get; set; }

        public decimal? AverageDailyVolume { get; set; }

        public decimal? Bid { get; set; }
    }
}