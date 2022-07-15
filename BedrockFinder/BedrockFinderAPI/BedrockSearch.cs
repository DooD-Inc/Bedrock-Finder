public class BedrockSearch
{
    public BedrockSearch(ProgressSave save)
    {
        Range = save.Range;
        Pattern = save.Pattern;
        Progress = save.Progress;
        Result = save.Result;
        PathToSave = save.Path;
    } 
    public BedrockSearch(BedrockPattern pattern, SearchRange range, string pathToSave)
    {
        Range = range;
        Pattern = pattern;        
        Progress = new SearchProgress(range.Start.X, range.End.X);
        Result = new List<Vec2i>();
        PathToSave = pathToSave;
    }
    public string PathToSave;
    public bool AutoSave = true;
    public MultiThreading MultiThreading = new MultiThreading(Environment.ProcessorCount);
    public SearchRange Range;
    public BedrockPattern Pattern;
    public SearchProgress Progress;
    public List<Vec2i> Result;
    public bool Working;
    private object @lock = new object();
    public void Start()
    {
        Working = true;
        List<(sbyte, BlockType)> yQueue = GetQueue();
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
        }        
    }
    public delegate void UpdateProgressHandler(double percent);
    public event UpdateProgressHandler? UpdateProgress;
    private List<Vec2i> CalculateChunk(List<(sbyte, BlockType)> queue, in int x, in int z)
    {
        List<Vec2i> founded = new List<Vec2i>();
        for (int incX = 0; incX < 16; incX++)
            for (int incZ = 0; incZ < 16; incZ++)
            {
                foreach ((sbyte y, BlockType type) in queue)                   
                    foreach ((ushort bx, ushort bz, BlockType block) in Pattern.GetFloor(y).blockList.Where(z => z.block == type))
                    {
                        bool isBedrock = BedrockGen_1_12_2.GetBlock((x << 4) + bx + incX, y, (z << 4) + bz + incZ, BedrockGen_1_12_2.GetChunk(x, z));
                        if (!Equals(type, isBedrock))
                            goto NextBlock;
                    }
                founded.Add(new Vec2i((x << 4) + incX, (z << 4) + incZ));
                NextBlock: { }
            }
        return founded;
    }
    private bool Equals(BlockType block, bool isBedrock) => block == BlockType.Bedrock && isBedrock || block == BlockType.Stone && !isBedrock;
    private List<(sbyte, BlockType)> GetQueue()
    {
        List<(sbyte, BlockType)> queue = new List<(sbyte, BlockType)>();
        if (Pattern.ExistedFloors.Any(z => z == 1)) queue.Add((1, BlockType.Stone));
        if (Pattern.ExistedFloors.Any(z => z == 4)) queue.Add((4, BlockType.Bedrock));
        if (Pattern.ExistedFloors.Any(z => z == 2)) queue.Add((2, BlockType.Stone));
        if (Pattern.ExistedFloors.Any(z => z == 3)) queue.Add((3, BlockType.Bedrock));
        if (Pattern.ExistedFloors.Any(z => z == 3)) queue.Add((3, BlockType.Stone));
        if (Pattern.ExistedFloors.Any(z => z == 2)) queue.Add((2, BlockType.Bedrock));
        if (Pattern.ExistedFloors.Any(z => z == 4)) queue.Add((4, BlockType.Stone));
        if (Pattern.ExistedFloors.Any(z => z == 1)) queue.Add((1, BlockType.Bedrock));
        return queue;
    }
    public void Stop() => Working = false;
}