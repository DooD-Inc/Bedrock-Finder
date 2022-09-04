using Amplifier;
using BedrockFinder.BedrockFinderAPI.CPU;
using BedrockFinder.BedrockFinderAPI.GPU;
using BedrockFinder.Libraries;
using System.Runtime.InteropServices;
using static BedrockFinder.BedrockFinderAPI.CPU.CPUBedrockGens;

namespace BedrockFinder;

public static unsafe class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        Application.Run(MainWindow = new MainWindow());
    }
    public static MainWindow MainWindow;
    public static IntPtr FormHandle = IntPtr.Zero;
    public static int DeviceIndex, ContextIndex, VersionIndex;
    public static BedrockPattern Pattern = new BedrockPattern(32, 32);
    public static SearchRange SearchRange = new SearchRange(32000);
    public static BedrockSearch Search;
    public static List<Device> Devices = new OpenCLCompiler().Devices.Select(z => z.ClearName()).ToList();
    public static List<BedrockGen> BedrockGens = new List<BedrockGen>()
    {
        new v12.OW(),
        new v13.OW(), new v13.LN(), new v13.HN(),
        new v14v15v16v17.OW(), new v14v15v16v17.LN(), new v14v15v16v17.HN(),
    };
    public static BedrockGen Gen = BedrockGens[0];
}
