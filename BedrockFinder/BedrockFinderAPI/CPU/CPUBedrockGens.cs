using static ChunkСache;
using static BedrockFinder.BedrockFinderAPI.Structs.Enums.WorldContext;
using System.Runtime.InteropServices;

namespace BedrockFinder.BedrockFinderAPI.CPU;
public static unsafe class CPUBedrockGens
{
    public static class v12
    {
        public class OW : BedrockGen
        {
            public OW() : base(Overworld, MinecraftVersion.v12) { }
            public static long* a, b;
            public override bool GetBlock(in int x, in byte y, in int z)
            {
                int cpos = (((z & 0xF) << 0x4) + (x & 0xF) << 0x2) + y;
                return ((((x >> 4) * 0x4F9939F508 + (z >> 4) * 0x1EF1565BD5 ^ 0x5DEECE66D) * a[cpos] + b[cpos] & 0xFFFFFFFFFFFF) >> 0x11) % 0x5 >= y;
            }
            public override bool GetBlock(in int x, in byte y, in int z, in long cs)
            {
                int cpos = (((z & 0xF) << 0x4) + (x & 0xF) << 0x2) + y;
                return ((cs * a[cpos] + b[cpos] & 0xFFFFFFFFFFFF) >> 0x11) % 0x5 >= y;
            }
        }
    }
    public static class v13
    {
        public class OW : BedrockGen
        {
            public OW() : base(Overworld, MinecraftVersion.v13) { }
            public override bool GetBlock(in int x, in byte y, in int z, in long cs)
            {
                bool found = false;
                foreach ((long a, long b) abobus in OW_13[(((z & 0xF) << 0x4) + (x & 0xF) << 0x2) + y])
                    found = found || ((cs * abobus.a + abobus.b & 0xFFFFFFFFFFFF) >> 0x11) % 0x5 >= y;
                return found;
            }
            public override bool GetBlock(in int x, in byte y, in int z)
            {
                bool found = false;
                long cs = (x >> 4) * 0x4F9939F508 + (z >> 4) * 0x1EF1565BD5 ^ 0x5DEECE66D;
                foreach ((long a, long b) abobus in OW_13[(((z & 0xF) << 0x4) + (x & 0xF) << 0x2) + y])
                    found = found || ((cs * abobus.a + abobus.b & 0xFFFFFFFFFFFF) >> 0x11) % 0x5 >= y;
                return found;
            }
        }
        public class LN : BedrockGen
        {
            public LN() : base(Lower_Nether, MinecraftVersion.v13) { }
            public override bool GetBlock(in int x, in byte y, in int z, in long cs)
            {
                bool found = false;
                foreach ((long a, long b) abobus in LN_13[(((z & 0xF) << 0x4) + (x & 0xF) << 0x2) + y])
                    found = found || ((cs * abobus.a + abobus.b & 0xFFFFFFFFFFFF) >> 0x11) % 0x5 >= y;
                return found;
            }
            public override bool GetBlock(in int x, in byte y, in int z)
            {
                bool found = false;
                long cs = (x >> 4) * 0x4F9939F508 + (z >> 4) * 0x1EF1565BD5 ^ 0x5DEECE66D;
                foreach ((long a, long b) abobus in LN_13[(((z & 0xF) << 0x4) + (x & 0xF) << 0x2) + y])
                    found = found || ((cs * abobus.a + abobus.b & 0xFFFFFFFFFFFF) >> 0x11) % 0x5 >= y;
                return found;
            }
        }
        public class HN : BedrockGen
        {
            public HN() : base(Higher_Nether, MinecraftVersion.v13) { }
            public override bool GetBlock(in int x, in byte y, in int z, in long cs)
            {
                bool found = false;
                foreach ((long a, long b) abobus in HN_13[(((z & 0xF) << 0x4) + (x & 0xF) << 0x2) + 5 - y])
                    found = found || ((cs * abobus.a + abobus.b & 0xFFFFFFFFFFFF) >> 0x11) % 0x5 >= y;
                return found;
            }
            public override bool GetBlock(in int x, in byte y, in int z)
            {
                bool found = false;
                long cs = (x >> 4) * 0x4F9939F508 + (z >> 4) * 0x1EF1565BD5 ^ 0x5DEECE66D;
                foreach ((long a, long b) abobus in HN_13[(((z & 0xF) << 0x4) + (x & 0xF) << 0x2) + 5 - y])
                    found = found || ((cs * abobus.a + abobus.b & 0xFFFFFFFFFFFF) >> 0x11) % 0x5 >= y;
                return found;
            }
        }
    }
    public static class v14v15v16v17
    {
        public class OW : BedrockGen
        {
            public OW() : base(Overworld, MinecraftVersion.v14, MinecraftVersion.v15, MinecraftVersion.v16, MinecraftVersion.v17) { }
            public static long* a, b;
            public override bool GetBlock(in int x, in byte y, in int z)
            {
                int cpos = (((z & 0xF) << 0x4) + (x & 0xF) << 0x2) + y;
                return ((((x >> 4) * 0x4F9939F508 + (z >> 4) * 0x1EF1565BD5 ^ 0x5DEECE66D) * a[cpos] + b[cpos] & 0xFFFFFFFFFFFF) >> 0x11) % 0x5 >= y;
            }
            public override bool GetBlock(in int x, in byte y, in int z, in long cs)
            {
                int cpos = (((z & 0xF) << 0x4) + (x & 0xF) << 0x2) + y;
                return ((cs * a[cpos] + b[cpos] & 0xFFFFFFFFFFFF) >> 0x11) % 0x5 >= y;
            }
        }
        public class LN : BedrockGen
        {
            public LN() : base(Lower_Nether, MinecraftVersion.v14, MinecraftVersion.v15, MinecraftVersion.v16, MinecraftVersion.v17) { }
            public static long* a, b;
            public override bool GetBlock(in int x, in byte y, in int z)
            {
                int cpos = (((z & 0xF) << 0x4) + (x & 0xF) << 0x2) + y;
                return ((((x >> 4) * 0x4F9939F508 + (z >> 4) * 0x1EF1565BD5 ^ 0x5DEECE66D) * a[cpos] + b[cpos] & 0xFFFFFFFFFFFF) >> 0x11) % 0x5 >= y;
            }
            public override bool GetBlock(in int x, in byte y, in int z, in long cs)
            {
                int cpos = (((z & 0xF) << 0x4) + (x & 0xF) << 0x2) + y;
                return ((cs * a[cpos] + b[cpos] & 0xFFFFFFFFFFFF) >> 0x11) % 0x5 >= y;
            }
        }
        public class HN : BedrockGen
        {
            public HN() : base(Higher_Nether, MinecraftVersion.v14, MinecraftVersion.v15, MinecraftVersion.v16, MinecraftVersion.v17) { }
            public static long* a, b;
            public override bool GetBlock(in int x, in byte y, in int z)
            {
                int cpos = (((z & 0xF) << 0x4) + (x & 0xF) << 0x2) + 5 - y;
                return ((((x >> 4) * 0x4F9939F508 + (z >> 4) * 0x1EF1565BD5 ^ 0x5DEECE66D) * a[cpos] + b[cpos] & 0xFFFFFFFFFFFF) >> 0x11) % 0x5 >= y;
            }
            public override bool GetBlock(in int x, in byte y, in int z, in long cs)
            {
                int cpos = (((z & 0xF) << 0x4) + (x & 0xF) << 0x2) + 5 - y;
                return ((cs * a[cpos] + b[cpos] & 0xFFFFFFFFFFFF) >> 0x11) % 0x5 >= y;
            }
        }
    }
}