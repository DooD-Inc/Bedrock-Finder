using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BedrockFinder.BedrockFinderAPI.BedrockGens;
public class OW_1_13 : BaseBedrockGen
{
    public override long GetChunk(in int x, in int z) => default;
    public override bool GetBlock(in int x, in byte y, in int z, in long cs) => default;
}
public class NL_1_13 : BaseBedrockGen
{
    public override long GetChunk(in int x, in int z) => default;
    public override bool GetBlock(in int x, in byte y, in int z, in long cs) => default;
}
public class NH_1_13 : BaseBedrockGen
{
    public override long GetChunk(in int x, in int z) => default;
    public override bool GetBlock(in int x, in byte y, in int z, in long cs) => default;
}