using BedrockFinder.BedrockFinderAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class OW_113 : BedrockGen
{
	public OW_113() : base("1.13", "Overworld", true, true) { }
	public override long GetChunk(in int x, in int z) => (x * 0x4F9939F508 + z * 0x1EF1565BD5) ^ 0x5DEECE66D;
	public override bool GetBlock(in int x, in byte y, in int z, in long cs)
	{
		bool found = false;
		foreach ((long a, long b) abobus in ChunkСache.OW_113_114[(((z & 0xF) << 0x4) + (x & 0xF) << 0x2) + y])
			found = found || (((cs * abobus.a + abobus.b) & 0xFFFFFFFFFFFF) >> 0x11) % 0x5 >= y;
		return found;
	}
}
/*
public class NL_113 : BedrockGen
{
    public override long GetChunk(in int x, in int z) => default;
    public override bool GetBlock(in int x, in byte y, in int z, in long cs) => default;
}
public class NH_113 : BedrockGen
{
    public override long GetChunk(in int x, in int z) => default;
    public override bool GetBlock(in int x, in byte y, in int z, in long cs) => default;
}
*/