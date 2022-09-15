using static BedrockFinder.BedrockFinderAPI.Structs.Enums.WorldContext;
using System.Runtime.InteropServices;

namespace BedrockFinder.BedrockFinderAPI.CPU;
public static unsafe class BedrockGens
{
    public static class v12
    {
        public class OW : CPUBedrockGen
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
        public class OW : CPUBedrockGen
        {
            public OW() : base(Overworld, MinecraftVersion.v13) { }
            public static long* cache;
            public override bool GetBlock(in int x, in byte y, in int z, in long cs)
            {
                int cpos = ((((z & 0xF) << 0x4) + (x & 0xF) << 0x2) + y) << 3;
                for (int i = 0; i < 8; i += 2)
                    if (cache[cpos + i] == 0)
                        break;
                    else if (((cs * cache[cpos + i] + cache[cpos + i + 1] & 0xFFFFFFFFFFFF) >> 0x11) % 0x5 >= y)
                        return true;
                return false;
            }
            public override bool GetBlock(in int x, in byte y, in int z)
            {
                long cs = (x >> 4) * 0x4F9939F508 + (z >> 4) * 0x1EF1565BD5 ^ 0x5DEECE66D;
                int cpos = ((((z & 0xF) << 0x4) + (x & 0xF) << 0x2) + y) << 3;
                for (int i = 0; i < 8; i += 2)
                    if (cache[cpos + i] == 0)
                        break;
                    else if (((cs * cache[cpos + i] + cache[cpos + i + 1] & 0xFFFFFFFFFFFF) >> 0x11) % 0x5 >= y)
                        return true;
                return false;
            }
        }
        public class LN : CPUBedrockGen
        {
            public LN() : base(Lower_Nether, MinecraftVersion.v13) { }
            public static long* cache;
            public override bool GetBlock(in int x, in byte y, in int z, in long cs)
            {
                int cpos = ((((z & 0xF) << 0x4) + (x & 0xF) << 0x2) + y) << 3;
                for (int i = 0; i < 8; i += 2)
                    if (cache[cpos + i] == 0)
                        break;
                    else if (((cs * cache[cpos + i] + cache[cpos + i + 1] & 0xFFFFFFFFFFFF) >> 0x11) % 0x5 >= y)
                            return true;
                return false;
            }
            public override bool GetBlock(in int x, in byte y, in int z)
            {
                long cs = (x >> 4) * 0x4F9939F508 + (z >> 4) * 0x1EF1565BD5 ^ 0x5DEECE66D;
                int cpos = ((((z & 0xF) << 0x4) + (x & 0xF) << 0x2) + y) << 3;
                for (int i = 0; i < 8; i += 2)
                    if (cache[cpos + i] == 0)
                        break;
                    else if (((cs * cache[cpos + i] + cache[cpos + i + 1] & 0xFFFFFFFFFFFF) >> 0x11) % 0x5 >= y)
                        return true;
                return false;
            }
        }
        public class HN : CPUBedrockGen
        {
            public HN() : base(Higher_Nether, MinecraftVersion.v13) { }
            public static long* cache;
            public override bool GetBlock(in int x, in byte y, in int z, in long cs)
            {
                int cpos = ((((z & 0xF) << 0x4) + (x & 0xF) << 0x2) + y) << 3;
                for (int i = 0; i < 8; i += 2)
                    if (cache[cpos + i] == 0)
                        break;
                    else if (((cs * cache[cpos + i] + cache[cpos + i + 1] & 0xFFFFFFFFFFFF) >> 0x11) % 0x5 >= y)
                        return true;
                return false;
            }
            public override bool GetBlock(in int x, in byte y, in int z)
            {
                long cs = (x >> 4) * 0x4F9939F508 + (z >> 4) * 0x1EF1565BD5 ^ 0x5DEECE66D;
                int cpos = ((((z & 0xF) << 0x4) + (x & 0xF) << 0x2) + y) << 3;
                for (int i = 0; i < 8; i += 2)
                    if (cache[cpos + i] == 0)
                        break;
                    else if (((cs * cache[cpos + i] + cache[cpos + i + 1] & 0xFFFFFFFFFFFF) >> 0x11) % 0x5 >= y)
                        return true;
                return false;
            }
        }
    }
    public static class v14v15v16v17
    {
        public class OW : CPUBedrockGen
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
        public class LN : CPUBedrockGen
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
        public class HN : CPUBedrockGen
        {
            public HN() : base(Higher_Nether, MinecraftVersion.v14, MinecraftVersion.v15, MinecraftVersion.v16, MinecraftVersion.v17) { }
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
}