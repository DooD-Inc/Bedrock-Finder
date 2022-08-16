using BedrockFinder;

public class BedrockSearch
{
    public BedrockSearch(ProgressSave save)
    {
        Range = save.Range;
        Pattern = save.Pattern;
        Progress = save.Progress;
        Result = save.Result;
        Vector = save.Vector;
        TurnPattern();
        InitTimer();
    }
    public BedrockSearch(BedrockPattern pattern, VectorAngle vector, SearchRange range)
    {
        Range = range;
        Pattern = pattern;        
        Progress = new SearchProgress((int)range.CStart.X, (int)range.CEnd.X);
        Result = new List<Vec2i>();
        Vector = vector;
        TurnPattern();
        InitTimer();
    }
    private void InitTimer()
    {
        timeManager = new Thread(() =>
        {
            TimeSpan once = TimeSpan.FromMilliseconds(100);
            while (true)
            {
                if (Working)
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
    public MultiThreading MultiThreading = new MultiThreading(Environment.ProcessorCount);
    public SearchRange Range;
    public BedrockPattern Pattern;
    public VectorAngle Vector;
    public SearchProgress Progress;
    public List<Vec2i> Result;
    public bool Working;
    public bool CanStart = true;
    public BedrockPattern TurnedPattern;
    private List<(int bx, byte y, int bz, BlockType block)> queue;
    private Thread timeManager;
    private object @lock = new object();
    public void Start()
    {
        new Thread(() =>
        {
            Working = true;
            CanStart = false;
            queue = GetQueue().Select(z => TurnedPattern[z.y].blockList.Where(x => x.block == z.block).Select(x => (x.x, z.y, x.z, z.block))).Aggregate((a, b) => a.Concat(b)).ToList();
            for (int x = Progress.X; x < Range.CEnd.X; x++)
            {
                Parallel.For((int)Range.CStart.Z, (int)Range.CEnd.Z, MultiThreading.ParallelOptions, z => CalculateChunk(x, z));                
                Progress.X++;
                UpdateProgress?.Invoke(Progress.GetPercent());
                if (!Working)
                {
                    CanStart = true;
                    return;
                }
            }
        }).Start();        
    }
    public bool Pause()
    {
        if(Working)
        {
            Working = false;
            return true;
        }
        return false;
    }
    public bool Resume()
    {
        if (CanStart)
        {
            Start();
            return true;
        }
        return false;
    }
    public delegate void FoundHandler(Vec2i coords);
    public event FoundHandler? Found;
    public delegate void UpdateProgressHandler(double percent);
    public event UpdateProgressHandler? UpdateProgress;
    private void CalculateChunk(in int x, in int z)
    {
        int bX = x << 4, bZ = z << 4;
        for (int incX = 0; incX < 16; incX++)
            for (int incZ = 0; incZ < 16; incZ++)
            {
                int exX = bX + incX,
                    exZ = bZ + incZ;
                foreach ((int bx, byte y, int bz, BlockType block) in queue)
                {
                    int sx = exX + bx, sz = exZ + bz;
                    if (!Equals(block, Program.Gen.GetBlock(sx, y, sz, Program.Gen.GetChunk(sx >> 4, sz >> 4))))
                        goto NextBlock;
                }
                Vec2i found = new Vec2i(Vector.CurrentPoint.x ? exX : (exX + TurnedPattern.SizeX - 1), Vector.CurrentPoint.y ? exZ : (exZ + TurnedPattern.SizeZ - 1));
                lock (@lock)
                {
                    Result.Add(found);
                    Found?.Invoke(found);
                }
                NextBlock: { }
            }
    }
    private bool Equals(BlockType block, bool isBedrock) => block == BlockType.Bedrock && isBedrock || block == BlockType.Stone && !isBedrock;
    private List<(byte y, BlockType block)> GetQueue()
    {
        List<(byte y, BlockType block)> queue = new List<(byte y, BlockType block)>();
        if (TurnedPattern.ExistedFloors.Any(z => z == 1) && TurnedPattern[1].blockList.Any(z => z.block == BlockType.Stone)) queue.Add((1, BlockType.Stone));
        if (TurnedPattern.ExistedFloors.Any(z => z == 4) && TurnedPattern[4].blockList.Any(z => z.block == BlockType.Bedrock)) queue.Add((4, BlockType.Bedrock));
        if (TurnedPattern.ExistedFloors.Any(z => z == 2) && TurnedPattern[2].blockList.Any(z => z.block == BlockType.Stone)) queue.Add((2, BlockType.Stone));
        if (TurnedPattern.ExistedFloors.Any(z => z == 3) && TurnedPattern[3].blockList.Any(z => z.block == BlockType.Bedrock)) queue.Add((3, BlockType.Bedrock));
        if (TurnedPattern.ExistedFloors.Any(z => z == 3) && TurnedPattern[3].blockList.Any(z => z.block == BlockType.Stone)) queue.Add((3, BlockType.Stone));
        if (TurnedPattern.ExistedFloors.Any(z => z == 2) && TurnedPattern[2].blockList.Any(z => z.block == BlockType.Bedrock)) queue.Add((2, BlockType.Bedrock));
        if (TurnedPattern.ExistedFloors.Any(z => z == 4) && TurnedPattern[4].blockList.Any(z => z.block == BlockType.Stone)) queue.Add((4, BlockType.Stone));
        if (TurnedPattern.ExistedFloors.Any(z => z == 1) && TurnedPattern[1].blockList.Any(z => z.block == BlockType.Bedrock)) queue.Add((1, BlockType.Bedrock));
        return queue;
    }
    public void Stop() => Working = false;
    public enum SearchStatus
    {
        PatternEdit,
        Search,
        Finish,
        Pause,
    }
}