public class SearchProgress
{
    public SearchProgress(int startX, int endX, TimeSpan elapsedTime = default)
    {
        X = startX;
        StartX = startX;
        EndX = endX;
        ElapsedTime = elapsedTime;
    }
    public int X, StartX, EndX;
    public TimeSpan ElapsedTime;
    public double GetPercent()
    {
        long lStart = (long)StartX + int.MaxValue;
        long lEnd = (long)EndX + int.MaxValue;
        long lX = (long)X + int.MaxValue;
        lEnd = lEnd - lStart;
        lX = lX - lStart;
        lStart = 0;
        return (double)lX / (lEnd - lStart) * 100;
    }
}