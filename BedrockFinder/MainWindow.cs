using BedrockFinder.Libraries;
using FastBitmapUtils;

namespace BedrockFinder;

public partial class MainWindow : DHForm
{
    private void ShowInit()
    {
        Program.FormHandle = Handle;
        Instance();
    }
    private void ControlsInit()
    {
        Icon = SmallApp.Icon = Program.Resources.Get("Icon")?.GetContent<Icon>();

        ImportPatternPB.Image = Program.Resources.Get("ImportImage")?.GetContent<Image>();
        ToolTips.SetToolTip(ImportPatternPB, "Import Pattern");

        ExportPatternPB.Image = Program.Resources.Get("ExportImage")?.GetContent<Image>();
        ToolTips.SetToolTip(ExportPatternPB, "Export Pattern");

        ClearPatternPB.Image = Program.Resources.Get("ClearImage")?.GetContent<Image>();
        ToolTips.SetToolTip(ClearPatternPB, "Clear This Pattern Layer");

        AutoSavePB.Image = Program.Resources.Get("AutoSaveImage")?.GetContent<Image>();
        ToolTips.SetToolTip(AutoSavePB, "Disable AutoSave");
        ReplacePixels(AutoSavePB, AutoSave ? Color.FromArgb(51, 102, 51) : Color.FromArgb(102, 51, 51));
    }
    private CanvasForm canvas = new CanvasForm() { TopLevel = false };
    public MainWindow()
    {
        InitializeComponent();
        CanvasP.Controls.Add(canvas);
        canvas.Show();
        canvas.Location = new Point(30, -160);
        ControlsInit();
        ShowInit();

        DeviceSelectDHCB.Collection = new List<string>()
        {
            "CPU", "GPU"
        };
        DeviceSelectDHCB.Text = "Device: ";
        DeviceSelectDHCB.ItemIndex = 0;

        MainDisplayP.Round(25, false, true, true, true);
        MainSettingsP.Round(25, true, true, true, true);
        CanvasSettingsP.Round(25, true, true, false, false);
        CanvasP.Round(25, true, true, false, true);
        CloseB.Round(15, true, true, false, false);
        MakeAsSmallAppB.Round(15, false, true, false, false);

        PenP.BackgroundImage = StoneFamilyBlock.DrawBedrockPen();
    }
    public bool AutoSave = true;
    private void Save()
    {

    }
    private void ReplacePixels(PictureBox control, Color toPixel)
    {
        Bitmap b = (Bitmap)control.Image;
        FastBitmap fb = new FastBitmap(b);
        for(int x = 0; x < b.Width; x++)
            for(int y = 0; y < b.Height; y++)
                if(fb.GetPixel(x, y).A != 0)
                    fb.SetPixel(x, y, toPixel);
        control.Image = fb.GetResult();
    }
    private void CloseB_Click(object sender, EventArgs e)
    {
        Save();
        Environment.Exit(0);
    }
    private void MakeAsSmallAppB_Click(object sender, EventArgs e)
    {
        SmallApp.Visible = true;
        WindowState = FormWindowState.Minimized;
        ShowInTaskbar = false;
    }

    private void SmallApp_Click(object sender, EventArgs e)
    {
        SmallApp.Visible = false;
        WindowState = FormWindowState.Normal;
        ShowInTaskbar = true;
        Activate();
        ShowInit();
    }

    private void ImportPatternPB_Click(object sender, EventArgs e)
    {

    }

    private void ExportPatternPB_Click(object sender, EventArgs e)
    {

    }

    private void AutoSavePB_Click(object sender, EventArgs e)
    {
        AutoSave = !AutoSave;
        ToolTips.SetToolTip(AutoSavePB, (AutoSave ? "Disable" : "Enable") + " AutoSave");
        ReplacePixels(AutoSavePB, AutoSave ? Color.FromArgb(51, 102, 51) : Color.FromArgb(102, 51, 51));
    }

    private void PenP_Click(object sender, EventArgs e)
    {
        if(canvas.PenType == BlockType.Bedrock)
        {
            PenP.BackgroundImage = StoneFamilyBlock.DrawStonePen();
            canvas.PenType = BlockType.Stone;
        }
        else
        {
            PenP.BackgroundImage = StoneFamilyBlock.DrawBedrockPen();
            canvas.PenType = BlockType.Bedrock;
        }
    }

    private void ClearPatternPB_Click(object sender, EventArgs e)
    {
        Program.Pattern[canvas.YLevel].blockList.ForEach(z =>
        {
            canvas.DrawBlock(z.x, 31 - z.z, BlockType.None);
            Program.Pattern[canvas.YLevel][z.x, z.z] = BlockType.None;
        });
    }
}