public class BlockFloor
{
    public BlockFloor(ushort sizeX, ushort sizeZ)
    {
        SizeX = sizeX;
        SizeZ = sizeZ;
        blocks = new BlockType[sizeX, sizeZ];
        blockList = new List<(int x, int z, BlockType block)>();
        Fill(BlockType.None);
    }
    private BlockType[,] blocks;
    public List<(int x, int z, BlockType block)> blockList;
    public ushort SizeX, SizeZ;
    public void Fill(BlockType block)
    {
        blockList = new List<(int x, int z, BlockType block)>();
        for (int x = 0; x < SizeX; x++)
            for (int z = 0; z < SizeZ; z++)
                blocks[x, z] = block;
    }
    public BlockType this[int x, int z]
    {
        get => blocks[x, z];
        set
        {
            blocks[x, z] = value;
            if (value == BlockType.None)
            {
                int index = blockList.FindIndex(c => c.x == x && c.z == z);
                if (index != -1)
                    blockList.RemoveAt(index);
            }
            else
            {
                int index = blockList.FindIndex(c => c.x == x && c.z == z);
                if (index == -1)
                    blockList.Add((x, z, value));
                else
                    blockList[index] = (x, z, value);
            }
        }
    }
}