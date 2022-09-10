using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BedrockFinder.BedrockFinderAPI.GPU;
public class GPUChunkCalc
{
    public GPUChunkCalc(Type kernel, WorldContext context, params MinecraftVersion[] versions)
    {
        Kernel = kernel;
        Versions = versions;
        Context = context;
    }
    public Type Kernel;
    public readonly MinecraftVersion[] Versions;
    public readonly WorldContext Context;
    public long[] A, B;
}