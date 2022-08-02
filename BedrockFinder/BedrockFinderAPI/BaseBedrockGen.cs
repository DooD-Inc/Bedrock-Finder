using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BedrockFinder.BedrockFinderAPI;
public abstract class BaseBedrockGen
{
    public abstract long GetChunk(in int x, in int z);
    public abstract bool GetBlock(in int x, in byte y, in int z, in long cs);
}