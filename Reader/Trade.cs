using System;

public class Trade
{
    public string Fruit { get; set; }
    public int Number { get; set; }
    public string ModeOfTransport { get; set; }

    private Object lockObj = new Object();

    public void Add(int number)
    {
        lock (lockObj)
        {
            Number += number;
        }
    }
}