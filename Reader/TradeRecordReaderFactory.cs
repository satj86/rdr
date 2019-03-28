namespace Reader
{
    public class TradeRecordReaderFactory : IRecordReaderFactory<Trade>
    {
        public IRecordReader<Trade> CreateRecordReader()
        {
            var jsonReader = new JsonRecordReader();
            var pipeReader = new PipeDelimitedRecordReader();
            jsonReader.NextReader = pipeReader;

            return jsonReader;
        }
    }

}
