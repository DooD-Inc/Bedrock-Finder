public class SearchRange
{  
    public SearchRange(Vec2i start, Vec2i end)
    {
        Start = start; 
        End = end;
    }
    public Vec2i Start, End;
    public int ChunkCount => ChunkRange * 4;
    public int ChunkRange => Math.Abs(Start.X - End.X) * Math.Abs(Start.Z - End.Z);
    public int BlockCount => ChunkCount * 256;
    public int BlockRange => ChunkRange * 256;
}