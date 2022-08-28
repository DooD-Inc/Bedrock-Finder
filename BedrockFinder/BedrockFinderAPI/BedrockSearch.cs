using BedrockFinder;
using BedrockFinder.BedrockFinderAPI;

public class BedrockSearch
{
    public BedrockSearch(SearchRange range, BedrockPattern pattern, SearchProgress progress, List<Vec2i> result, VectorAngle vector)
    {
        Range = range;
        Pattern = pattern;
        Progress = progress;
        Result = result;
        Vector = vector;
        TurnPattern();
        InitTimer();
    }
    public BedrockSearch(ProgressSave save) : this(save.Range, save.Pattern, save.Progress, save.Result, save.Vector) { }
    public BedrockSearch(BedrockPattern pattern, VectorAngle vector, SearchRange range) : this(range, pattern, new SearchProgress((int)range.CStart.X, (int)range.CEnd.X), new List<Vec2i>(), vector) { }
    private void InitTimer()
    {
        timeManager = new Thread(() =>
        {
            TimeSpan once = TimeSpan.FromMilliseconds(100);
            while (true)
            {
                if (Searcher.Working)
                    Progress.ElapsedTime = Progress.ElapsedTime.Add(once);
                Thread.Sleep(100);
            }
        });
        timeManager.Start();
    }
    private void TurnPattern()
    {
        TurnedPattern = Pattern.AsSame;
        foreach (byte y in Pattern.ExistedFloors)
        {
            BlockFloor floor = TurnedPattern.NewFloor;
            Pattern[y].blockList.ForEach(c =>
            {
                (int x, int z) mewCoord = Vector.Translate(c.x, c.z, 31, 31);
                floor[mewCoord.x, mewCoord.z] = c.block;
            });
            TurnedPattern[y] = floor;
        }
    }
    public BedrockSearcher Searcher;
    public SearchRange Range;
    public BedrockPattern Pattern;
    public VectorAngle Vector;
    public SearchProgress Progress;
    public List<Vec2i> Result;
    public BedrockPattern TurnedPattern;
    private Thread timeManager;
    public bool Pause()
    {
        if(Searcher.Working)
        {
            Searcher.Working = false;
            return true;
        }
        return false;
    }
    public bool Resume()
    {
        if (Searcher.CanStart)
        {
            Searcher.Start();
            return true;
        }
        return false;
    }
    public delegate void FoundHandler(Vec2i coords);
    public event FoundHandler? Found;
    public delegate void UpdateProgressHandler(double percent);
    public event UpdateProgressHandler? UpdateProgress;
    public void Stop() => Searcher.Working = false;
    public void InvokeUpdateProgress(double @delegate) => UpdateProgress?.Invoke(@delegate);
    public void InvokeFound(Vec2i @delegate) => Found?.Invoke(@delegate);
}