using StockQuotes.Providers.Providers;
using StockQuotes.Providers.Providers.YahooProvider.SchemaModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace StockQuotes.Providers
{
    public class YahooProvider : IProvider
    {
        private const string BaseUrl = "http://query.yahooapis.com/v1/public/yql?q=" +
                                       "select%20*%20from%20yahoo.finance.quotes%20where%20symbol%20in%20({0})" +
                                       "&env=store%3A%2F%2Fdatatables.org%2Falltableswithkeys";

        public IEnumerable<QuoteDTO> Fetch(IEnumerable<string> quoteSymbolsToFetch)
        {          
            string symbolList = String.Join("%2C", quoteSymbolsToFetch.Select(w => "%22" + w + "%22").ToArray());
            string url = string.Format(BaseUrl, symbolList);

            XDocument doc = XDocument.Load(url);
            return Parse(quoteSymbolsToFetch, doc);
        }

        private IEnumerable<QuoteDTO> Parse(IEnumerable<string> quoteSymbols, XDocument doc)
        {
            var resultQoutes = new List<QuoteDTO>();
            IEnumerable<XElement> xmlQuoteElements = doc.Root.Element("results").Elements("quote")
                .Where(x => quoteSymbols.Contains(x.Attribute("symbol").Value));

            foreach (XElement q in xmlQuoteElements)
            {
                var quote = new Quote();
                quote.Symbol = q.Attribute("symbol").Value;
                quote.Ask = GetDecimal(q.Element("Ask").Value);
                quote.Bid = GetDecimal(q.Element("Bid").Value);
                quote.AverageDailyVolume = GetDecimal(q.Element("AverageDailyVolume").Value);
                quote.BookValue = GetDecimal(q.Element("BookValue").Value);
                quote.Change = GetDecimal(q.Element("Change").Value);
                quote.DividendShare = GetDecimal(q.Element("DividendShare").Value);
                quote.LastTradeDate = GetDateTime(q.Element("LastTradeDate").Value + " " + q.Element("LastTradeTime").Value);
                quote.EarningsShare = GetDecimal(q.Element("EarningsShare").Value);
                quote.EPSEstimateCurrentYear = GetDecimal(q.Element("EPSEstimateCurrentYear").Value);
                quote.EPSEstimateNextYear = GetDecimal(q.Element("EPSEstimateNextYear").Value);
                quote.EPSEstimateNextQuarter = GetDecimal(q.Element("EPSEstimateNextQuarter").Value);
                quote.DaysLow = GetDecimal(q.Element("DaysLow").Value);
                quote.DaysHigh = GetDecimal(q.Element("DaysHigh").Value);
                quote.YearLow = GetDecimal(q.Element("YearLow").Value);
                quote.YearHigh = GetDecimal(q.Element("YearHigh").Value);
                quote.MarketCapitalization = GetDecimal(q.Element("MarketCapitalization").Value);
                quote.EBITDA = GetDecimal(q.Element("EBITDA").Value);
                quote.ChangeFromYearLow = GetDecimal(q.Element("ChangeFromYearLow").Value);
                quote.PercentChangeFromYearLow = GetDecimal(q.Element("PercentChangeFromYearLow").Value);
                quote.ChangeFromYearHigh = GetDecimal(q.Element("ChangeFromYearHigh").Value);
                quote.LastTradePriceOnly = GetDecimal(q.Element("LastTradePriceOnly").Value);
                quote.PercentChangeFromYearHigh = GetDecimal(q.Element("PercebtChangeFromYearHigh").Value); //missspelling in yahoo for field name
                quote.FiftyDayMovingAverage = GetDecimal(q.Element("FiftydayMovingAverage").Value);
                quote.TwoHundreddayMovingAverage = GetDecimal(q.Element("TwoHundreddayMovingAverage").Value);
                quote.ChangeFromTwoHundreddayMovingAverage = GetDecimal(q.Element("ChangeFromTwoHundreddayMovingAverage").Value);
                quote.PercentChangeFromTwoHundreddayMovingAverage = GetDecimal(q.Element("PercentChangeFromTwoHundreddayMovingAverage").Value);
                quote.PercentChangeFromFiftydayMovingAverage = GetDecimal(q.Element("PercentChangeFromFiftydayMovingAverage").Value);
                quote.Name = q.Element("Name").Value;
                quote.Open = GetDecimal(q.Element("Open").Value);
                quote.PreviousClose = GetDecimal(q.Element("PreviousClose").Value);
                quote.ChangeinPercent = GetDecimal(q.Element("ChangeinPercent").Value);
                quote.PriceSales = GetDecimal(q.Element("PriceSales").Value);
                quote.PriceBook = GetDecimal(q.Element("PriceBook").Value);
                quote.ExDividendDate = GetDateTime(q.Element("ExDividendDate").Value);
                quote.PERatio = GetDecimal(q.Element("PERatio").Value);
                quote.DividendPayDate = GetDateTime(q.Element("DividendPayDate").Value);
                quote.PEGRatio = GetDecimal(q.Element("PEGRatio").Value);
                quote.PriceEPSEstimateCurrentYear = GetDecimal(q.Element("PriceEPSEstimateCurrentYear").Value);
                quote.PriceEPSEstimateNextYear = GetDecimal(q.Element("PriceEPSEstimateNextYear").Value);
                quote.ShortRatio = GetDecimal(q.Element("ShortRatio").Value);
                quote.OneyrTargetPrice = GetDecimal(q.Element("OneyrTargetPrice").Value);
                quote.Volume = GetDecimal(q.Element("Volume").Value);
                quote.StockExchange = q.Element("StockExchange").Value;

                quote.LastUpdate = DateTime.Now;

                resultQoutes.Add(quote.Convert());
            }

            return resultQoutes;
        }

        private static decimal? GetDecimal(string input)
        {
            if (input == null) return null;

            input = input.Replace("%", "");

            decimal value;

            if (Decimal.TryParse(input, out value)) return value;
            return null;
        }

        private static DateTime? GetDateTime(string input)
        {
            if (input == null) return null;

            DateTime value;

            if (DateTime.TryParse(input, out value)) return value;
            return null;
        }

    }
}
