using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reader
{
    public class TradeService : ITradeService
    {
        private readonly IRecordReader<Trade> _tradeRecordReader;

        public TradeService(IRecordReaderFactory<Trade> recordReaderFactory)
        {
            _tradeRecordReader = recordReaderFactory.CreateRecordReader();
        }

        public async Task<IEnumerable<Trade>> GetTrades(params string[] files)
        {
            var tradeReadingTasks = files.Select(file => _tradeRecordReader.GetRecords(file));

            var trades = (await Task.WhenAll(tradeReadingTasks)).SelectMany(x => x);

            return trades;
        }
    }
}
