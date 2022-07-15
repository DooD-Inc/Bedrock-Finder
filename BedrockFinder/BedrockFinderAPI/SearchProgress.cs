public class SearchProgress
{
    public SearchProgress(int startX, int endX)
    {
        X = startX;
        StartX = startX;
        EndX = endX;
    }
    public int X, StartX, EndX;
    public double GetPercent()
    {
        long lStart = (long)StartX + int.MaxValue;
        long lEnd = (long)EndX + int.MaxValue;
        long lX = (long)X + int.MaxValue;
        lEnd = lEnd - lStart;
        lX = lX - lStart;
        lStart = 0;
        return Math.Round((double)lX / (lEnd - lStart), 2, MidpointRounding.AwayFromZero);
    }
}