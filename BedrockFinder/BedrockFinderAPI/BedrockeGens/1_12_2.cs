public static class BedrockGen_1_12_2
{
    public static long GetChunk(in int x, in int z) => (x * 0x4F9939F508 + z * 0x1EF1565BD5) ^ 0x5DEECE66D;
    public static bool GetBlock(in int x, in byte y, in int z, in long cs)
    {
        int cpos = (((z & 0xF) << 0x4) + (x & 0xF) << 0x2) + y;
        return ((((cs * ChunkСache.A_OW_112[cpos] + ChunkСache.B_OW_112[cpos]) & 0xFFFFFFFFFFFF) >> 0x11) % 0x5) >= y;
    }
}