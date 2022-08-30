public class BedrockPattern
{
    public BedrockPattern(ushort sizeX, ushort sizeZ, params sbyte[] floorYs)
    {
        SizeX = sizeX;
        SizeZ = sizeZ;
        foreach (byte y in floorYs)
            if (y > 0 && y < 5)
                floors[y - 1] = new BlockFloor(sizeX, sizeZ);
        ExistedFloors = floorYs;
    }
    public BedrockPattern(ushort sizeX, ushort sizeZ) : this(sizeX, sizeZ, 1, 2, 3, 4) { }
    private BlockFloor[] floors = new BlockFloor[4];
    public ushort SizeX, SizeZ;
    public sbyte[] ExistedFloors;
    public BlockFloor this[byte y]
    {
        get => floors[y - 1];
        set => floors[y - 1] = value;
    }
    public BedrockPattern AsSame => new BedrockPattern(SizeX, SizeZ, ExistedFloors);
    public BlockFloor NewFloor => new BlockFloor(SizeX, SizeZ);
    public long CalculateScore()
    {
        long score = 0;
        foreach (int i in ExistedFloors)
            floors[i - 1].blockList.ForEach(x => score += CalculateBlockScore(i, x.block == BlockType.Bedrock));
        return score;
    }
    private long CalculateBlockScore(int y, bool isBedrock) => isBedrock ? y : (5 - y);
    public decimal CalculateFindPercent()
    {
        decimal score = 1;
        foreach(int i in ExistedFloors)
            floors[i - 1].blockList.ForEach(x => score *= CalculateBlockFindPercent(i, x.block == BlockType.Bedrock));
        return score;
    }
    private decimal CalculateBlockFindPercent(int y, bool isBedrock) => ((isBedrock ? (5 - y) : y) * .2m);
}