using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace StockQuotes.Providers.Providers.YahooProvider.SchemaModels
{
    [XmlRoot(ElementName = "LastTradeWithTime")]
    internal class LastTradeWithTime
    {
        [XmlElement(ElementName = "b")]
        public string B { get; set; }
    }
}
