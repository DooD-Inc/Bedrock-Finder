using static ChunkСache;
using static BedrockFinder.BedrockFinderAPI.Structs.Enums.WorldContext;
using System.Runtime.InteropServices;

namespace BedrockFinder.BedrockFinderAPI.GPU;
public static unsafe class GPUChunkCalcs
{
    public static class v12
    {
        public class OW : GPUChunkCalc { public OW() : base(typeof(Kernels.v12.OW), Overworld, MinecraftVersion.v12) { A = OW_12_A; B = OW_12_B; } }
    }
    public static class v13
    {
        public class OW : GPUChunkCalc { public OW() : base(typeof(Kernels.v13.OW), Overworld, MinecraftVersion.v13) { A = OW_13; } }
        public class LN : GPUChunkCalc { public LN() : base(typeof(Kernels.v13.LN), Lower_Nether, MinecraftVersion.v13) { A = LN_13; } }
        public class HN : GPUChunkCalc { public HN() : base(typeof(Kernels.v13.HN), Higher_Nether, MinecraftVersion.v13) { A = HN_13; } }
    }
    public static class v14v15v16v17
    {
        public class OW : GPUChunkCalc { public OW() : base(typeof(Kernels.v14v15v16v17.OW), Overworld, MinecraftVersion.v14, MinecraftVersion.v15, MinecraftVersion.v16, MinecraftVersion.v17) { A = OW_14_A; B = OW_14_B; } }
        public class LN : GPUChunkCalc { public LN() : base(typeof(Kernels.v14v15v16v17.LN), Lower_Nether, MinecraftVersion.v14, MinecraftVersion.v15, MinecraftVersion.v16, MinecraftVersion.v17) { A = LN_14_A; B = LN_14_B; } }
        public class HN : GPUChunkCalc { public HN() : base(typeof(Kernels.v14v15v16v17.HN), Higher_Nether, MinecraftVersion.v14, MinecraftVersion.v15, MinecraftVersion.v16, MinecraftVersion.v17) { A = HN_14_A; B = HN_14_B; } }
    }
}