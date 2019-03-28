using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

public class PipeDelimitedRecordReader : BaseRecordReader
{
    public override Task<IEnumerable<Trade>> GetRecords(string filePath)
    {
        if (filePath.EndsWith(".txt"))
        {
            var fileRows = File.ReadAllLines(filePath);

            return Task.FromResult(GetTrades(fileRows));
        }

        return base.GetRecords(filePath);
    }

    private IEnumerable<Trade> GetTrades(string[] rawTrades)
    {
        foreach (var rawRowData in rawTrades)
        {
            var dataElements = rawRowData.Split('|');
            yield return new Trade
            {
                Fruit = dataElements[0],
                Number = Convert.ToInt32(dataElements[1]),
                ModeOfTransport = dataElements[2]
            };
        }
    }
}


