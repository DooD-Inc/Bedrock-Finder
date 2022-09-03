public class MultiThreading
{
    public MultiThreading(int countCore, int addition = 0)
    {
        CountCore = countCore;
        AdditionThreads = addition;
        ParallelOptions = new ParallelOptions()
        {
            MaxDegreeOfParallelism = CountCore * 2 + AdditionThreads
        };
    }
    public int AdditionThreads;
    public int CountCore;
    public ParallelOptions ParallelOptions { get; set; }
}