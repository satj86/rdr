using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Reader
{
    class Program
    {
        static void Main(string[] args)
        {
            var recordReaderFactory = CreateRecordReaderFactory();
            var tradeService = CreateTradeService(recordReaderFactory);

            var trades = tradeService.GetTrades(Directory.EnumerateFiles(Environment.CurrentDirectory, "*-trade.*").ToArray()).GetAwaiter().GetResult();

            WriteTrades(trades);
        }

        static void WriteTrades(IEnumerable<Trade> trades)
        {
            foreach (var trade in trades)
            {
                Console.WriteLine($"{trade.Fruit} {trade.Number} {trade.ModeOfTransport}");
            }
        }

        static ITradeService CreateTradeService(IRecordReaderFactory<Trade> recordReaderFactory)
        {
            return new TradeService(recordReaderFactory);
        }

        static IRecordReaderFactory<Trade> CreateRecordReaderFactory()
        {
            return new TradeRecordReaderFactory();
        }
    }
}
