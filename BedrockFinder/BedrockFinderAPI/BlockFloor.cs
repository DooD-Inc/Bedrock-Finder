public class BlockFloor
{
    public BlockFloor(ushort sizeX, ushort sizeZ)
    {
        SizeX = sizeX;
        SizeZ = sizeZ;
        blocks = new BlockType[sizeX, sizeZ];
        blockList = new List<(ushort x, ushort z, BlockType block)>();
        Fill(BlockType.None);
    }
    private BlockType[,] blocks;
    public List<(ushort x, ushort z, BlockType block)> blockList;
    public ushort SizeX, SizeZ;
    public void Set(int x, int z, BlockType block) => Set((ushort)x, (ushort)z, block);
    public void Set(ushort x, ushort z, BlockType block)
    {
        blocks[x, z] = block;        ;
        if (block == BlockType.None)
            blockList.Remove((x, z, block));
        else blockList.Add((x, z, block));
    }
    public BlockType Get(ushort x, ushort z) => blocks[x, z];
    public BlockType Get(int x, int z) => blocks[x, z];
    public void Fill(BlockType block)
    {
        for (int x = 0; x < SizeX; x++)
            for (int z = 0; z < SizeZ; z++)
                blocks[x, z] = block;
    }
    public BlockType this[ushort x, ushort z]
    {
        get => blocks[x, z];
        set => blocks[x, z] = value;
    }
}