using System.Collections.Generic;
using System.Threading.Tasks;

namespace Reader
{
    public interface ITradeService
    {
        Task<IEnumerable<Trade>> GetTrades(params string[] files);
    }
}