public class SearchRange
{  
    public SearchRange(Vec2l start, Vec2l end)
    {
        if(start.X > end.X)
        {
            long oldStart = start.X;
            start.X = end.X;
            end.X = oldStart;
        }
        if (start.Z > end.Z)
        {
            long oldStart = start.Z;
            start.Z = end.Z;
            end.Z = oldStart;
        }
        Start = start; 
        End = end;
        CStart = new Vec2l(start.X % 16 == 0 ? (start.X >> 4) : ((start.X >> 4) - 1),
                           start.Z % 16 == 0 ? (start.Z >> 4) : ((start.Z >> 4) - 1));
        CEnd = new Vec2l(end.X % 16 == 0 ? (end.X >> 4) : ((end.X >> 4) + 1),
                         end.Z % 16 == 0 ? (end.Z >> 4) : ((end.Z >> 4) + 1));
    }
    public SearchRange(long sx, long sz, long ex, long ez) : this(new Vec2l(sx, sz), new Vec2l(ex, ez)) { }
    public SearchRange(long radius) : this(-radius, -radius, radius, radius) { }
    public Vec2l Start, End;
    public Vec2l CStart, CEnd;
    public long ChunkCount => ChunkRange * 4;
    public long ChunkRange => XCSize * ZCSize;
    public long BlockCount => ChunkCount * 256;
    public long BlockRange => ChunkRange * 256;
    public Vec2l Size => new Vec2l(XSize, ZSize);
    public long XSize => Math.Abs(Start.X - End.X);
    public long ZSize => Math.Abs(Start.Z - End.Z);
    public long XCSize => Math.Abs(CStart.X - CEnd.X);
    public long ZCSize => Math.Abs(CStart.Z - CEnd.Z);
}