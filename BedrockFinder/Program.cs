using BedrockFinder.Libraries;

namespace BedrockFinder;

public static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        Resources.Perfom();
        ApplicationConfiguration.Initialize();
        Application.Run(new MainWindow());
    }
    public static IntPtr FormHandle = IntPtr.Zero;
    public static Resources Resources = new Resources(typeof(MainWindow), 
        new Resource("Icon", "https://cdn-124.anonfiles.com/N6j1w3xfy9/978c29ad-1657726804/yotic.ico"),
        new Resource("ImportImage", "https://cdn-icons-png.flaticon.com/512/151/151901.png"),
        new Resource("ExportImage", "https://cdn-icons-png.flaticon.com/512/151/151900.png"),
        new Resource("ClearImage", "https://cdn-146.anonfiles.com/vcrbR0x3y2/ddc8f1fe-1657875750/delete%20(1).png"),
        new Resource("AutoSaveImage", "https://cdn-130.anonfiles.com/v256B5xeyf/47ac790a-1657801961/save.png")
    );
    public static BedrockPattern Pattern = new BedrockPattern(32, 32, 0, 1, 2, 3, 4);
}