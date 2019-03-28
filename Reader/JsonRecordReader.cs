using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

public class JsonRecordReader : BaseRecordReader
{
    public override Task<IEnumerable<Trade>> GetRecords(string filePath)
    {
        if (filePath.EndsWith(".json"))
        {
            return Task.FromResult((IEnumerable<Trade>)JsonConvert.DeserializeObject<List<Trade>>(File.ReadAllText(filePath)));
        }

        return base.GetRecords(filePath);
    }
}


