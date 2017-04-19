using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockQuotes.Providers.Providers.YahooProvider
{
    interface IMappable<T>
        where T: class 
    {
        T Convert();
    }
}
