using static ChunkСache;
using static BedrockFinder.BedrockFinderAPI.BedrockGen.WorldContext;

namespace BedrockFinder.BedrockFinderAPI;
public unsafe class CPUBedrockGens
{
    public class v12
    {
        public class OW : BedrockGen
        {
            public OW() : base(MinecraftVersion.v12, Overworld)
            {
                fixed (long* ta = OW_12_A)
                    a = ta;
                fixed (long* tb = OW_12_B)
                    b = tb;
            }
            private readonly long* a, b;
            public override bool GetBlock(in int x, in byte y, in int z)
            {
                int cpos = (((z & 0xF) << 0x4) + (x & 0xF) << 0x2) + y;
                return (((((((x >> 4) * 0x4F9939F508 + (z >> 4) * 0x1EF1565BD5) ^ 0x5DEECE66D) * a[cpos] + b[cpos]) & 0xFFFFFFFFFFFF) >> 0x11) % 0x5) >= y;
            }
            public override bool GetBlock(in int x, in byte y, in int z, in long cs)
            {
                int cpos = (((z & 0xF) << 0x4) + (x & 0xF) << 0x2) + y;
                return ((((cs * a[cpos] + b[cpos]) & 0xFFFFFFFFFFFF) >> 0x11) % 0x5) >= y;
            }
        }
    }
    public class v13
    {
        public class OW : BedrockGen
        {
            public OW() : base(MinecraftVersion.v13, Overworld) { }
            public override bool GetBlock(in int x, in byte y, in int z, in long cs)
            {
                bool found = false;
                foreach ((long a, long b) abobus in OW_13[(((z & 0xF) << 0x4) + (x & 0xF) << 0x2) + y])
                    found = found || (((cs * abobus.a + abobus.b) & 0xFFFFFFFFFFFF) >> 0x11) % 0x5 >= y;
                return found;
            }
            public override bool GetBlock(in int x, in byte y, in int z)
            {
                bool found = false;
                long cs = ((x >> 4) * 0x4F9939F508 + (z >> 4) * 0x1EF1565BD5) ^ 0x5DEECE66D;
                foreach ((long a, long b) abobus in OW_13[(((z & 0xF) << 0x4) + (x & 0xF) << 0x2) + y])
                    found = found || (((cs * abobus.a + abobus.b) & 0xFFFFFFFFFFFF) >> 0x11) % 0x5 >= y;
                return found;
            }
        }
        public class LN : BedrockGen
        {
            public LN() : base(MinecraftVersion.v13, Lower_Nether) { }
            public override bool GetBlock(in int x, in byte y, in int z, in long cs)
            {
                bool found = false;
                foreach ((long a, long b) abobus in LN_13[(((z & 0xF) << 0x4) + (x & 0xF) << 0x2) + y])
                    found = found || (((cs * abobus.a + abobus.b) & 0xFFFFFFFFFFFF) >> 0x11) % 0x5 >= y;
                return found;
            }
            public override bool GetBlock(in int x, in byte y, in int z)
            {
                bool found = false;
                long cs = ((x >> 4) * 0x4F9939F508 + (z >> 4) * 0x1EF1565BD5) ^ 0x5DEECE66D;
                foreach ((long a, long b) abobus in LN_13[(((z & 0xF) << 0x4) + (x & 0xF) << 0x2) + y])
                    found = found || (((cs * abobus.a + abobus.b) & 0xFFFFFFFFFFFF) >> 0x11) % 0x5 >= y;
                return found;
            }
        }
        public class HN : BedrockGen
        {
            public HN() : base(MinecraftVersion.v13, Higher_Nether) { }
            public override bool GetBlock(in int x, in byte y, in int z, in long cs)
            {
                bool found = false;
                foreach ((long a, long b) abobus in HN_13[(((z & 0xF) << 0x4) + (x & 0xF) << 0x2) + y])
                    found = found || (((cs * abobus.a + abobus.b) & 0xFFFFFFFFFFFF) >> 0x11) % 0x5 >= y;
                return found;
            }
            public override bool GetBlock(in int x, in byte y, in int z)
            {
                bool found = false;
                long cs = ((x >> 4) * 0x4F9939F508 + (z >> 4) * 0x1EF1565BD5) ^ 0x5DEECE66D;
                foreach ((long a, long b) abobus in HN_13[(((z & 0xF) << 0x4) + (x & 0xF) << 0x2) + y])
                    found = found || (((cs * abobus.a + abobus.b) & 0xFFFFFFFFFFFF) >> 0x11) % 0x5 >= y;
                return found;
            }
        }
    }
    public class v14
    {
        public class OW : BedrockGen
        {
            public OW() : base(MinecraftVersion.v14, Overworld)
            {
                fixed (long* ta = OW_14_A)
                    a = ta;
                fixed (long* tb = OW_14_B)
                    b = tb;
            }
            private readonly long* a, b;
            public override bool GetBlock(in int x, in byte y, in int z)
            {
                int cpos = (((z & 0xF) << 0x4) + (x & 0xF) << 0x2) + y;
                return (((((((x >> 4) * 0x4F9939F508 + (z >> 4) * 0x1EF1565BD5) ^ 0x5DEECE66D) * a[cpos] + b[cpos]) & 0xFFFFFFFFFFFF) >> 0x11) % 0x5) >= y;
            }
            public override bool GetBlock(in int x, in byte y, in int z, in long cs)
            {
                int cpos = (((z & 0xF) << 0x4) + (x & 0xF) << 0x2) + y;
                return ((((cs * a[cpos] + b[cpos]) & 0xFFFFFFFFFFFF) >> 0x11) % 0x5) >= y;
            }
        }
        public class LN : BedrockGen
        {
            public LN() : base(MinecraftVersion.v14, Lower_Nether)
            {
                fixed (long* ta = LN_14_A)
                    a = ta;
                fixed (long* tb = LN_14_B)
                    b = tb;
            }
            private readonly long* a, b;
            public override bool GetBlock(in int x, in byte y, in int z)
            {
                int cpos = (((z & 0xF) << 0x4) + (x & 0xF) << 0x2) + y;
                return (((((((x >> 4) * 0x4F9939F508 + (z >> 4) * 0x1EF1565BD5) ^ 0x5DEECE66D) * a[cpos] + b[cpos]) & 0xFFFFFFFFFFFF) >> 0x11) % 0x5) >= y;
            }
            public override bool GetBlock(in int x, in byte y, in int z, in long cs)
            {
                int cpos = (((z & 0xF) << 0x4) + (x & 0xF) << 0x2) + y;
                return ((((cs * a[cpos] + b[cpos]) & 0xFFFFFFFFFFFF) >> 0x11) % 0x5) >= y;
            }
        }
        public class HN : BedrockGen
        {
            public HN() : base(MinecraftVersion.v14, Higher_Nether)
            {
                fixed (long* ta = HN_14_A)
                    a = ta;
                fixed (long* tb = HN_14_B)
                    b = tb;
            }
            private readonly long* a, b;
            public override bool GetBlock(in int x, in byte y, in int z)
            {
                int cpos = (((z & 0xF) << 0x4) + (x & 0xF) << 0x2) + y;
                return (((((((x >> 4) * 0x4F9939F508 + (z >> 4) * 0x1EF1565BD5) ^ 0x5DEECE66D) * a[cpos] + b[cpos]) & 0xFFFFFFFFFFFF) >> 0x11) % 0x5) >= y;
            }
            public override bool GetBlock(in int x, in byte y, in int z, in long cs)
            {
                int cpos = (((z & 0xF) << 0x4) + (x & 0xF) << 0x2) + y;
                return ((((cs * a[cpos] + b[cpos]) & 0xFFFFFFFFFFFF) >> 0x11) % 0x5) >= y;
            }
        }
    }
    public class v15
    {
        public class OW : BedrockGen
        {
            public OW() : base(MinecraftVersion.v15, Overworld)
            {
                fixed (long* ta = OW_14_A)
                    a = ta;
                fixed (long* tb = OW_14_B)
                    b = tb;
            }
            private readonly long* a, b;
            public override bool GetBlock(in int x, in byte y, in int z)
            {
                int cpos = (((z & 0xF) << 0x4) + (x & 0xF) << 0x2) + y;
                return (((((((x >> 4) * 0x4F9939F508 + (z >> 4) * 0x1EF1565BD5) ^ 0x5DEECE66D) * a[cpos] + b[cpos]) & 0xFFFFFFFFFFFF) >> 0x11) % 0x5) >= y;
            }
            public override bool GetBlock(in int x, in byte y, in int z, in long cs)
            {
                int cpos = (((z & 0xF) << 0x4) + (x & 0xF) << 0x2) + y;
                return ((((cs * a[cpos] + b[cpos]) & 0xFFFFFFFFFFFF) >> 0x11) % 0x5) >= y;
            }
        }
        public class LN : BedrockGen
        {
            public LN() : base(MinecraftVersion.v15, Lower_Nether)
            {
                fixed (long* ta = LN_14_A)
                    a = ta;
                fixed (long* tb = LN_14_B)
                    b = tb;
            }
            private readonly long* a, b;
            public override bool GetBlock(in int x, in byte y, in int z)
            {
                int cpos = (((z & 0xF) << 0x4) + (x & 0xF) << 0x2) + y;
                return (((((((x >> 4) * 0x4F9939F508 + (z >> 4) * 0x1EF1565BD5) ^ 0x5DEECE66D) * a[cpos] + b[cpos]) & 0xFFFFFFFFFFFF) >> 0x11) % 0x5) >= y;
            }
            public override bool GetBlock(in int x, in byte y, in int z, in long cs)
            {
                int cpos = (((z & 0xF) << 0x4) + (x & 0xF) << 0x2) + y;
                return ((((cs * a[cpos] + b[cpos]) & 0xFFFFFFFFFFFF) >> 0x11) % 0x5) >= y;
            }
        }
        public class HN : BedrockGen
        {
            public HN() : base(MinecraftVersion.v15, Higher_Nether)
            {
                fixed (long* ta = HN_14_A)
                    a = ta;
                fixed (long* tb = HN_14_B)
                    b = tb;
            }
            private readonly long* a, b;
            public override bool GetBlock(in int x, in byte y, in int z)
            {
                int cpos = (((z & 0xF) << 0x4) + (x & 0xF) << 0x2) + y;
                return (((((((x >> 4) * 0x4F9939F508 + (z >> 4) * 0x1EF1565BD5) ^ 0x5DEECE66D) * a[cpos] + b[cpos]) & 0xFFFFFFFFFFFF) >> 0x11) % 0x5) >= y;
            }
            public override bool GetBlock(in int x, in byte y, in int z, in long cs)
            {
                int cpos = (((z & 0xF) << 0x4) + (x & 0xF) << 0x2) + y;
                return ((((cs * a[cpos] + b[cpos]) & 0xFFFFFFFFFFFF) >> 0x11) % 0x5) >= y;
            }
        }
    }
}