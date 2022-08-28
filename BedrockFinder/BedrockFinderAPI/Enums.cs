global using static BedrockFinder.BedrockFinderAPI.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BedrockFinder.BedrockFinderAPI;
public static class Enums
{
    public enum SearchDeviceType : byte
    {
        CPU,
        Kernel
    }
    public enum SearchStatus
    {
        PatternEdit,
        Search,
        Finish,
        Pause,
    }
    public static Dictionary<MinecraftVersion, string> MinecraftVersions = new Dictionary<MinecraftVersion, string>()
    {
        { MinecraftVersion.v12, "1.12" },
        { MinecraftVersion.v13, "1.13" },
        { MinecraftVersion.v14, "1.14" },
        { MinecraftVersion.v15, "1.15" },
    };
    public enum MinecraftVersion : byte
    {
        v12,
        v13,
        v14,
        v15,
    }
    public static Dictionary<WorldContext, string> WorldContexts = new Dictionary<WorldContext, string>()
    {
        { WorldContext.Overworld, "Overworld" },
        { WorldContext.Lower_Nether, "Lower Nether" },
        { WorldContext.Higher_Nether, "Higher Nether" },
    };  
    public enum WorldContext : byte
    {
        Overworld,
        Lower_Nether,
        Higher_Nether
    }
}