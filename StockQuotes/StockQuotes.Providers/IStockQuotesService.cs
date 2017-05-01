using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockQuotes.Providers
{
    public interface IStockQuotesService
    {
        Task<IEnumerable<QuoteDTO>> GetAllQuotesAsync();

        Task<IEnumerable<QuoteDTO>> GetSpecificQuotesAsync(IEnumerable<string> symbols);
        

        Task<QuoteDTO> GetAsync(string symbol);
    }
}
