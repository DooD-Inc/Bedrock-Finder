using Amplifier;
using BedrockFinder.BedrockFinderAPI;
using BedrockFinder.Libraries;
using static BedrockFinder.BedrockFinderAPI.CPUBedrockGens;

namespace BedrockFinder;

public static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        MainWindow = new MainWindow();
        Application.Run(MainWindow);
    }
    public static MainWindow MainWindow;
    public static IntPtr FormHandle = IntPtr.Zero;
    public static int DeviceIndex = 0, ContextIndex = 0, VersionIndex = 0;
    public static BedrockPattern Pattern = new BedrockPattern(32, 32, 1, 2, 3, 4);
    public static SearchRange SearchRange = new SearchRange(new Vec2l(-32000, -32000), new Vec2l(32000, 32000));
    public static BedrockSearch Search;
    public static List<Device> Devices;
    public static List<BedrockGen> BedrockGens = new List<BedrockGen>()
    {
        new v12.OW(),
        new v13.OW(), new v13.LN(), new v13.HN(),
        new v14.OW(), new v14.LN(), new v14.HN(),
        new v15.OW(), new v15.LN(), new v15.HN(),
    };
    public static BedrockGen Gen = BedrockGens[0];
    static Program()
    {
        Devices = new OpenCLCompiler().Devices;
        for(int i = 0; i < Devices.Count; i++)
            Devices[i].Name = Devices[i].Name.Replace("Core", "").Replace("(TM)", "").Replace("(tm)", "").Replace("(R)", "").Replace("(r)", "").Replace("(C)", "").Replace("(c)", "").Replace(" ", " ").Replace("  ", " ").Split('@')[0];
    }
}