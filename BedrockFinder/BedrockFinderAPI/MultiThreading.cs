public class MultiThreading
{
    public MultiThreading(int countCore, int addition = 0)
    {
        CountCore = countCore;
        AdditionCore = addition;
        ParallelOptions = new ParallelOptions()
        {
            MaxDegreeOfParallelism = CountCore * 2 + AdditionCore
        };
    }
    public int AdditionCore;
    public int CountCore;
    public ParallelOptions ParallelOptions { get; set; }
}