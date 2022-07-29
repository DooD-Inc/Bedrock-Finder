public class BedrockSearch
{
    public BedrockSearch(ProgressSave save)
    {
        Range = save.Range;
        Pattern = save.Pattern;
        Progress = save.Progress;
        Result = save.Result;
        PathToSave = save.Path;
        Vector = save.Vector;
        TurnPattern();
        InitTimer();
    }
    public BedrockSearch(BedrockPattern pattern, VectorAngle vector, SearchRange range, string pathToSave)
    {
        Range = range;
        Pattern = pattern;        
        Progress = new SearchProgress(range.Start.X, range.End.X);
        Result = new List<Vec2i>();
        PathToSave = pathToSave;
        Vector = vector;
        TurnPattern();
        InitTimer();
    }
    private void InitTimer()
    {
        TimeManager = new Thread(() =>
        {
            TimeSpan once = TimeSpan.FromMilliseconds(100);
            while (true)
            {
                if (Working)
                    Progress.ElapsedTime = Progress.ElapsedTime.Add(once);
                Thread.Sleep(100);
            }
        });
        TimeManager.Start();
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
    public string PathToSave;
    public bool AutoSave = true;
    public MultiThreading MultiThreading = new MultiThreading(Environment.ProcessorCount);
    public SearchRange Range;
    public BedrockPattern Pattern;
    public VectorAngle Vector;
    public SearchProgress Progress;
    public List<Vec2i> Result;
    public int FoundCount = 0;
    public bool Working;
    public bool CanStart = true;
    public BedrockPattern TurnedPattern;
    private Thread TimeManager;
    private object @lock = new object(), foundCounterLock = new object();
    public void Start()
    {
        new Thread(() =>
        {
            Working = true;
            CanStart = false;
            List<(byte, BlockType)> yQueue = GetQueue();
            for (int x = Progress.X; x < Range.End.X; x++)
            {
                List<Vec2i> founded = new List<Vec2i>();
                Parallel.For(Range.Start.Z, Range.End.Z, MultiThreading.ParallelOptions, z =>
                {
                    List<Vec2i> found = CalculateChunk(yQueue, x, z);
                    if (found.Count > 0)
                    {
                        lock (@lock)
                        {
                            founded.AddRange(found);
                        }
                    }
                });
                Result.AddRange(founded);
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
    private List<Vec2i> CalculateChunk(List<(byte, BlockType)> queue, in int x, in int z)
    {
        List<Vec2i> founded = new List<Vec2i>();
        for (int incX = 0; incX < 16; incX++)
            for (int incZ = 0; incZ < 16; incZ++)
            {
                foreach ((byte y, BlockType type) in queue)
                    foreach ((int bx, int bz, BlockType block) in TurnedPattern[y].blockList.Where(z => z.block == type))
                    {
                        int sx = (x << 4) + bx + incX, sz = (z << 4) + bz + incZ;
                        if (!Equals(type, BedrockGen_1_12_2.GetBlock(sx, y, sz, BedrockGen_1_12_2.GetChunk(sx >> 4, sz >> 4))))
                            goto NextBlock;
                    }
                Vec2i found = new Vec2i(Vector.CurrentPoint.x ? ((x << 4) + incX) : ((x << 4) + incX + TurnedPattern.SizeX - 1), Vector.CurrentPoint.y ? ((z << 4) + incZ) : ((z << 4) + incZ + TurnedPattern.SizeZ - 1));
                lock (foundCounterLock)
                {
                    founded.Add(found);
                    FoundCount++;
                    Found?.Invoke(found);
                }
                NextBlock: { }
            }
        return founded;
    }
    private bool Equals(BlockType block, bool isBedrock) => block == BlockType.Bedrock && isBedrock || block == BlockType.Stone && !isBedrock;
    private List<(byte, BlockType)> GetQueue()
    {
        List<(byte, BlockType)> queue = new List<(byte, BlockType)>();
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
}