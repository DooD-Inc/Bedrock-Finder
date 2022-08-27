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
    public static Dictionary<MinecraftVersion, string> MinecraftVersions = new Dictionary<MinecraftVersion, string>()
    {
        { MinecraftVersion.v12, "1.12" },
        { MinecraftVersion.v13, "1.13" },
        { MinecraftVersion.v14, "1.14" },
        { MinecraftVersion.v15, "1.15" },
    };
    public static Dictionary<WorldContext, string> WorldContexts = new Dictionary<WorldContext, string>()
    {
        { WorldContext.Overworld, "Overworld" },
        { WorldContext.Lower_Nether, "Lower Nether" },
        { WorldContext.Higher_Nether, "Higher Nether" },
    };
    public enum MinecraftVersion
    {
        v12,
        v13,
        v14,
        v15,
    }
    public enum WorldContext
    {
        Overworld,
        Lower_Nether,
        Higher_Nether
    }
}