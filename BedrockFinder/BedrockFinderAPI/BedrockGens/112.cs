using BedrockFinder.BedrockFinderAPI;

public unsafe class P_OW_112 : BedrockGen
{    
    public P_OW_112() : base("1.12", "Overworld", true, false)
    {
        fixed (long* ta = ChunkСache.OW_112_A)
            a = ta;
        fixed (long* tb = ChunkСache.OW_112_B)
            b = tb;
    }
    long* a, b;
    public override long GetChunk(in int x, in int z) => (x * 0x4F9939F508 + z * 0x1EF1565BD5) ^ 0x5DEECE66D;
    public override bool GetBlock(in int x, in byte y, in int z, in long cs)
    {
        int cpos = (((z & 0xF) << 0x4) + (x & 0xF) << 0x2) + y;
        return ((((cs * a[cpos] + b[cpos]) & 0xFFFFFFFFFFFF) >> 0x11) % 0x5) >= y;
    }
}
public class OW_112 : BedrockGen
{
    public OW_112() : base("1.12", "Overworld", false, true) { }
    public override long GetChunk(in int x, in int z) => (x * 0x4F9939F508 + z * 0x1EF1565BD5) ^ 0x5DEECE66D;
    public override bool GetBlock(in int x, in byte y, in int z, in long cs)
    {
        int cpos = (((z & 0xF) << 0x4) + (x & 0xF) << 0x2) + y;
        return ((((cs * ChunkСache.OW_112_A[cpos] + ChunkСache.OW_112_B[cpos]) & 0xFFFFFFFFFFFF) >> 0x11) % 0x5) >= y;
    }
}
/*
public class NL_112 : BaseBedrockGen
{
    public override long GetChunk(in int x, in int z) => default;
    public override bool GetBlock(in int x, in byte y, in int z, in long cs) => default;
}
public class NH_112 : BaseBedrockGen
{
    public override long GetChunk(in int x, in int z) => default;
    public override bool GetBlock(in int x, in byte y, in int z, in long cs) => default;
}
*/