using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BedrockFinder.BedrockFinderAPI;
public abstract class BedrockGen
{
    public BedrockGen(MinecraftVersion version, WorldContext context)
    {
        Version = version;
        Context = context;
    }
    public long GetChunkByBlock(in int x, in int z) => ((x >> 4) * 0x4F9939F508 + (z >> 4) * 0x1EF1565BD5) ^ 0x5DEECE66D;
    public long GetChunk(in int x, in int z) => (x * 0x4F9939F508 + z * 0x1EF1565BD5) ^ 0x5DEECE66D;
    public abstract bool GetBlock(in int x, in byte y, in int z);
    public abstract bool GetBlock(in int x, in byte y, in int z, in long cs);
    public readonly MinecraftVersion Version;
    public readonly WorldContext Context;
}