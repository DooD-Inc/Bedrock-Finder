using BedrockFinder.BedrockFinderAPI;

public class OW_1_12 : BaseBedrockGen
{
    public override long GetChunk(in int x, in int z) => (x * 0x4F9939F508 + z * 0x1EF1565BD5) ^ 0x5DEECE66D;
    public override bool GetBlock(in int x, in byte y, in int z, in long cs)
    {
        int cpos = (((z & 0xF) << 0x4) + (x & 0xF) << 0x2) + y;
        return ((((cs * ChunkСache.OW_112_A[cpos] + ChunkСache.OW_112_B[cpos]) & 0xFFFFFFFFFFFF) >> 0x11) % 0x5) >= y;
    }
}
public class NL_1_12 : BaseBedrockGen
{
    public override long GetChunk(in int x, in int z) => default;
    public override bool GetBlock(in int x, in byte y, in int z, in long cs) => default;
}
public class NH_1_12 : BaseBedrockGen
{
    public override long GetChunk(in int x, in int z) => default;
    public override bool GetBlock(in int x, in byte y, in int z, in long cs) => default;
}