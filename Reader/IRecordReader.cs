using System.Collections.Generic;
using System.Threading.Tasks;

public interface IRecordReader<T>
{
    Task<IEnumerable<T>> GetRecords(string filePath);

    IRecordReader<T> NextReader { get; }
}


