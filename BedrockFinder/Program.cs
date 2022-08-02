using Amplifier;
using BedrockFinder.BedrockFinderAPI;
using BedrockFinder.Libraries;
using FastBitmapUtils;
using Substrate;

namespace BedrockFinder;

public static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        try
        {
            Resources.Perfom();
        } catch { }
        ApplicationConfiguration.Initialize();
        MainWindow = new MainWindow();
        Application.Run(MainWindow);
    }
    public static MainWindow MainWindow;
    public static IntPtr FormHandle = IntPtr.Zero;
    public static Resources Resources = new Resources(typeof(MainWindow), 
        new Resource("Icon", "https://cdn-124.anonfiles.com/N6j1w3xfy9/978c29ad-1657726804/yotic.ico"),
        new Resource("ImportImage", "https://cdn-icons-png.flaticon.com/512/151/151901.png"),
        new Resource("ExportImage", "https://cdn-icons-png.flaticon.com/512/151/151900.png"),
        new Resource("ImportWorldImage", "https://cdn-146.anonfiles.com/k5lfxa0cy6/ce08c151-1658691402/World-Import.png"),
        new Resource("ExportWorldImage", "https://cdn-145.anonfiles.com/j4l9x301y0/34ce6ffa-1658691524/World-Export.png"),
        new Resource("ClearImage", "https://cdn-146.anonfiles.com/vcrbR0x3y2/ddc8f1fe-1657875750/delete%20(1).png"),
        new Resource("AutoSaveImage", "https://cdn-130.anonfiles.com/v256B5xeyf/47ac790a-1657801961/save.png"),
        new Resource("LeftTurnImage", "https://cdn-144.anonfiles.com/n7Z6ufy5y0/f6de6fd4-1657997667/left-turn.png"),
        new Resource("RightTurnImage", "https://cdn-143.anonfiles.com/18Zaucyeyf/a4d8c736-1657997763/right-turn.png"),
        new Resource("CopyImage", "https://cdn-145.anonfiles.com/L474P9z0y5/0d088984-1658409865/copy.png"),
        new Resource("ZoomOutImage", "https://cdn-102.anonfiles.com/X997X30fy3/b68ecc82-1658971156/zoom-out.png")
    );
    public static BedrockPattern Pattern = new BedrockPattern(32, 32, 1, 2, 3, 4);
    public static SearchRange SearchRange = new SearchRange(new Vec2l(-32000, -32000), new Vec2l(32000, 32000));
    public static BedrockSearch Search;
    public static List<Device> Devices;
    public static BaseBedrockGen Gen = new OW_1_12();
    static Program()
    {
        Devices = new OpenCLCompiler().Devices;
        for(int i = 0; i < Devices.Count; i++)
            Devices[i].Name = Devices[i].Name.Replace("(TM)", "").Replace("(tm)", "").Replace("(R)", "").Replace("(r)", "").Replace("(C)", "").Replace("(c)", "").Replace(" ", " ").Replace(" ", " ");
    }
}