using Amplifier;
using BedrockFinder.BedrockFinderAPI.CPU;
using BedrockFinder.BedrockFinderAPI.GPU;
using BedrockFinder.Libraries;
using System.Runtime.InteropServices;
using CPU = BedrockFinder.BedrockFinderAPI.CPU.BedrockGens;
using GPU = BedrockFinder.BedrockFinderAPI.GPU.GPUChunkCalcs;

namespace BedrockFinder;

public static unsafe class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        _ = ChunkСache.OW_13;
        Application.Run(MainWindow = new MainWindow());
    }
    public static MainWindow MainWindow;
    public static IntPtr FormHandle = IntPtr.Zero;
    public static int DeviceIndex, ContextIndex, VersionIndex;
    public static BedrockPattern Pattern = new BedrockPattern(32, 32);
    public static SearchRange SearchRange = new SearchRange(32000);
    public static BedrockSearch Search;
    public static List<Device> Devices = new OpenCLCompiler().Devices.Select(z => z.ClearName()).ToList();
    public static List<CPUBedrockGen> CPUBedrockGens = new List<CPUBedrockGen>()
    {
        new CPU.v12.OW(),
        new CPU.v13.OW(), new CPU.v13.LN(), new CPU.v13.HN(),
        new CPU.v14v15v16v17.OW(), new CPU.v14v15v16v17.LN(), new CPU.v14v15v16v17.HN(),
    };
    public static List<GPUChunkCalc> GPUChunkCalcs = new List<GPUChunkCalc>()
    {
        new GPU.v12.OW(),
        new GPU.v13.OW(), new GPU.v13.LN(), new GPU.v13.HN(),
        new GPU.v14v15v16v17.OW(), new GPU.v14v15v16v17.LN(), new GPU.v14v15v16v17.HN(),
    };
    public static CPUBedrockGen CPUGen = CPUBedrockGens[0];
    public static GPUChunkCalc GPUCalc = GPUChunkCalcs[0];
}
