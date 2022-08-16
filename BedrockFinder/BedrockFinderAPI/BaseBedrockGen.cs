using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BedrockFinder.BedrockFinderAPI;
public abstract class BedrockGen
{
    public BedrockGen(string version, string context, bool forCPU, bool forKernel)
    {
        Version = version;
        Context = context;
        ForCPU = forCPU;
        ForKernel = forKernel;
    }
    public string Version { get; }
    public string Context { get; }
    public bool ForCPU { get; }
    public bool ForKernel { get; }
    public abstract long GetChunk(in int x, in int z);
    public abstract bool GetBlock(in int x, in byte y, in int z, in long cs);
    public static string[] Versions =
    {
        "1.12", "1.13", "1.14", "1.15", "1.16", "1.17", "1.18", "1.19"
    };
    public static string[] Contexts =
    {
        "Overworld", "Lower Nether", "Higher Nether"
    };
}