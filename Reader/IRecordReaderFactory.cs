namespace Reader
{
    public interface IRecordReaderFactory<T> where T : class
    {
        IRecordReader<T> CreateRecordReader();
    }

}
