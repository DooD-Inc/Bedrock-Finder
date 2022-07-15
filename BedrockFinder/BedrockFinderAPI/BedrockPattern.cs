public class BedrockPattern
{
    public BedrockPattern(ushort sizeX, ushort sizeZ, params sbyte[] floorYs)
    {
        foreach (sbyte y in floorYs)
            if (y > 0 && y < 5)
                floors[y-1] = new BlockFloor(sizeX, sizeZ);
        ExistedFloors = floorYs.ToList();
    }
    private BlockFloor[] floors = new BlockFloor[4];
    public List<sbyte> ExistedFloors;
    public BlockFloor GetFloor(sbyte y) => floors[y - 1];
    public void SetBlock(ushort x, sbyte y, ushort z, BlockType block) => floors[y - 1].Set(x, z, block);
    public BlockFloor this[sbyte y]
    {
        get => floors[y - 1];
        set => floors[y - 1] = value;
    }
}