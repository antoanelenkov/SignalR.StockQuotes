using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockQuotes.Providers.Providers
{
    public interface IProvider
    {
        IEnumerable<QuoteDTO> Fetch(IEnumerable<string> quoteSymbolsToFetch);
    }
}
