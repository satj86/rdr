using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class BaseRecordReader : IRecordReader<Trade>
{
    public IRecordReader<Trade> NextReader { get; set; }

    public virtual Task<IEnumerable<Trade>> GetRecords(string filePath)
    {
        if (NextReader != null)
            return NextReader.GetRecords(filePath);

        return Task.FromResult(Enumerable.Empty<Trade>());
    }
}


