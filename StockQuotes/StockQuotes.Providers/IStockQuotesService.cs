using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockQuotes.Providers
{
    public interface IStockQuotesService
    {
        IEnumerable<QuoteDTO> GetAllQuotes();

        IEnumerable<QuoteDTO> GetAllQuotes(IEnumerable<string> symbols);

        QuoteDTO Get(string symbol);

        Task<QuoteDTO> GetAsync(string symbol);
    }
}
