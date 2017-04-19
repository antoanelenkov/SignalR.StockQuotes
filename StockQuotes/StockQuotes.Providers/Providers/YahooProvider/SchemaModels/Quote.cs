using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace StockQuotes.Providers.Providers.YahooProvider.SchemaModels
{
    [XmlRoot(ElementName = "quote")]
    internal class Quote : IMappable<QuoteDTO>
    {
        [XmlElement(ElementName = "Ask")]
        public decimal? Ask { get; set; }
        [XmlElement(ElementName = "AverageDailyVolume")]
        public decimal? AverageDailyVolume { get; set; }
        [XmlElement(ElementName = "Bid")]
        public decimal? Bid { get; set; }
        [XmlElement(ElementName = "AskRealtime")]
        public decimal? AskRealtime { get; set; }
        [XmlElement(ElementName = "BidRealtime")]
        public decimal? BidRealtime { get; set; }
        [XmlElement(ElementName = "BookValue")]
        public decimal? BookValue { get; set; }
        [XmlElement(ElementName = "Change_PercentChange")]
        public decimal? Change_PercentChange { get; set; }
        [XmlElement(ElementName = "Change")]
        public decimal? Change { get; set; }
        [XmlElement(ElementName = "Commission")]
        public decimal? Commission { get; set; }
        [XmlElement(ElementName = "Currency")]
        public decimal? Currency { get; set; }
        [XmlElement(ElementName = "ChangeRealtime")]
        public decimal? ChangeRealtime { get; set; }
        [XmlElement(ElementName = "AfterHoursChangeRealtime")]
        public decimal? AfterHoursChangeRealtime { get; set; }
        [XmlElement(ElementName = "DividendShare")]
        public decimal? DividendShare { get; set; }
        [XmlElement(ElementName = "LastTradeDate")]
        public DateTime? LastTradeDate { get; set; }
        [XmlElement(ElementName = "TradeDate")]
        public decimal? TradeDate { get; set; }
        [XmlElement(ElementName = "EarningsShare")]
        public decimal? EarningsShare { get; set; }
        [XmlElement(ElementName = "ErrorIndicationreturnedforsymbolchangedinvalid")]
        public decimal? ErrorIndicationreturnedforsymbolchangedinvalid { get; set; }
        [XmlElement(ElementName = "EPSEstimateCurrentYear")]
        public decimal? EPSEstimateCurrentYear { get; set; }
        [XmlElement(ElementName = "EPSEstimateNextYear")]
        public decimal? EPSEstimateNextYear { get; set; }
        [XmlElement(ElementName = "EPSEstimateNextQuarter")]
        public decimal? EPSEstimateNextQuarter { get; set; }
        [XmlElement(ElementName = "DaysLow")]
        public decimal? DaysLow { get; set; }
        [XmlElement(ElementName = "DaysHigh")]
        public decimal? DaysHigh { get; set; }
        [XmlElement(ElementName = "YearLow")]
        public decimal? YearLow { get; set; }
        [XmlElement(ElementName = "YearHigh")]
        public decimal? YearHigh { get; set; }
        [XmlElement(ElementName = "HoldingsGainPercent")]
        public decimal? HoldingsGainPercent { get; set; }
        [XmlElement(ElementName = "AnnualizedGain")]
        public decimal? AnnualizedGain { get; set; }
        [XmlElement(ElementName = "HoldingsGain")]
        public decimal? HoldingsGain { get; set; }
        [XmlElement(ElementName = "HoldingsGainPercentRealtime")]
        public decimal? HoldingsGainPercentRealtime { get; set; }
        [XmlElement(ElementName = "HoldingsGainRealtime")]
        public decimal? HoldingsGainRealtime { get; set; }
        [XmlElement(ElementName = "MoreInfo")]
        public decimal? MoreInfo { get; set; }
        [XmlElement(ElementName = "OrderBookRealtime")]
        public decimal? OrderBookRealtime { get; set; }
        [XmlElement(ElementName = "MarketCapitalization")]
        public decimal? MarketCapitalization { get; set; }
        [XmlElement(ElementName = "MarketCapRealtime")]
        public decimal? MarketCapRealtime { get; set; }
        [XmlElement(ElementName = "EBITDA")]
        public decimal? EBITDA { get; set; }
        [XmlElement(ElementName = "ChangeFromYearLow")]
        public decimal? ChangeFromYearLow { get; set; }
        [XmlElement(ElementName = "PercentChangeFromYearLow")]
        public decimal? PercentChangeFromYearLow { get; set; }
        [XmlElement(ElementName = "LastTradeRealtimeWithTime")]
        public decimal? LastTradeRealtimeWithTime { get; set; }
        [XmlElement(ElementName = "ChangePercentRealtime")]
        public decimal? ChangePercentRealtime { get; set; }
        [XmlElement(ElementName = "ChangeFromYearHigh")]
        public decimal? ChangeFromYearHigh { get; set; }
        [XmlElement(ElementName = "PercebtChangeFromYearHigh")]
        public decimal? PercentChangeFromYearHigh { get; set; }
        [XmlElement(ElementName = "LastTradeWithTime")]
        public LastTradeWithTime LastTradeWithTime { get; set; }
        [XmlElement(ElementName = "LastTradePriceOnly")]
        public decimal? LastTradePriceOnly { get; set; }
        [XmlElement(ElementName = "HighLimit")]
        public decimal? HighLimit { get; set; }
        [XmlElement(ElementName = "LowLimit")]
        public decimal? LowLimit { get; set; }
        [XmlElement(ElementName = "DaysRange")]
        public decimal? DaysRange { get; set; }
        [XmlElement(ElementName = "DaysRangeRealtime")]
        public decimal? DaysRangeRealtime { get; set; }
        [XmlElement(ElementName = "FiftydayMovingAverage")]
        public decimal? FiftyDayMovingAverage { get; set; }
        [XmlElement(ElementName = "TwoHundreddayMovingAverage")]
        public decimal? TwoHundreddayMovingAverage { get; set; }
        [XmlElement(ElementName = "ChangeFromTwoHundreddayMovingAverage")]
        public decimal? ChangeFromTwoHundreddayMovingAverage { get; set; }
        [XmlElement(ElementName = "PercentChangeFromTwoHundreddayMovingAverage")]
        public decimal? PercentChangeFromTwoHundreddayMovingAverage { get; set; }
        [XmlElement(ElementName = "ChangeFromFiftydayMovingAverage")]
        public decimal? ChangeFromFiftydayMovingAverage { get; set; }
        [XmlElement(ElementName = "PercentChangeFromFiftydayMovingAverage")]
        public decimal? PercentChangeFromFiftydayMovingAverage { get; set; }
        [XmlElement(ElementName = "Name")]
        public string Name { get; set; }
        [XmlElement(ElementName = "Notes")]
        public decimal? Notes { get; set; }
        [XmlElement(ElementName = "Open")]
        public decimal? Open { get; set; }
        [XmlElement(ElementName = "PreviousClose")]
        public decimal? PreviousClose { get; set; }
        [XmlElement(ElementName = "PricePaid")]
        public decimal? PricePaid { get; set; }
        [XmlElement(ElementName = "ChangeinPercent")]
        public decimal? ChangeinPercent { get; set; }
        [XmlElement(ElementName = "PriceSales")]
        public decimal? PriceSales { get; set; }
        [XmlElement(ElementName = "PriceBook")]
        public decimal? PriceBook { get; set; }
        [XmlElement(ElementName = "ExDividendDate")]
        public DateTime? ExDividendDate { get; set; }
        [XmlElement(ElementName = "PERatio")]
        public decimal? PERatio { get; set; }
        [XmlElement(ElementName = "DividendPayDate")]
        public DateTime? DividendPayDate { get; set; }
        [XmlElement(ElementName = "PERatioRealtime")]
        public decimal? PERatioRealtime { get; set; }
        [XmlElement(ElementName = "PEGRatio")]
        public decimal? PEGRatio { get; set; }
        [XmlElement(ElementName = "PriceEPSEstimateCurrentYear")]
        public decimal? PriceEPSEstimateCurrentYear { get; set; }
        [XmlElement(ElementName = "PriceEPSEstimateNextYear")]
        public decimal? PriceEPSEstimateNextYear { get; set; }
        [XmlElement(ElementName = "Symbol")]
        public string Symbol { get; set; }
        [XmlAttribute(AttributeName = "symbol")]
        public decimal? _Symbol { get; set; }
        [XmlElement(ElementName = "SharesOwned")]
        public decimal? SharesOwned { get; set; }
        [XmlElement(ElementName = "ShortRatio")]
        public decimal? ShortRatio { get; set; }
        [XmlElement(ElementName = "LastTradeTime")]
        public decimal? LastTradeTime { get; set; }
        [XmlElement(ElementName = "TickerTrend")]
        public decimal? TickerTrend { get; set; }
        [XmlElement(ElementName = "OneyrTargetPrice")]
        public decimal? OneyrTargetPrice { get; set; }
        [XmlElement(ElementName = "Volume")]
        public decimal? Volume { get; set; }
        [XmlElement(ElementName = "HoldingsValue")]
        public decimal? HoldingsValue { get; set; }
        [XmlElement(ElementName = "HoldingsValueRealtime")]
        public decimal? HoldingsValueRealtime { get; set; }
        [XmlElement(ElementName = "YearRange")]
        public decimal? YearRange { get; set; }
        [XmlElement(ElementName = "DaysValueChange")]
        public decimal? DaysValueChange { get; set; }
        [XmlElement(ElementName = "DaysValueChangeRealtime")]
        public decimal? DaysValueChangeRealtime { get; set; }
        [XmlElement(ElementName = "StockExchange")]
        public string StockExchange { get; set; }
        [XmlElement(ElementName = "DividendYield")]
        public decimal? DividendYield { get; set; }
        [XmlElement(ElementName = "PercentChange")]
        public decimal? PercentChange { get; set; }

        public DateTime? LastUpdate { get; set; }

        public QuoteDTO Convert()
        {
            var resultQuote = new QuoteDTO();

            resultQuote.Ask = this.Ask;
            resultQuote.AverageDailyVolume = this.AverageDailyVolume;
            resultQuote.Bid = this.Bid;
            resultQuote.Symbol = this.Symbol;

            return resultQuote;
        }
    }
}
