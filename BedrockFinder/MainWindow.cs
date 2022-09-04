using BedrockFinder.BedrockFinderAPI;
using BedrockFinder.BedrockFinderAPI.Structs;
using BedrockFinder.Libraries;
using BedrockFinder.Libraries.Custom_Controls;
using static BedrockSearch;

namespace BedrockFinder;

public partial class MainWindow : CForm
{
    #region Window
    private void ShowInit()
    {
        Program.FormHandle = Handle;
        Instance();
    }
    private CToolTips ToolTips;
    private CComboBoxBundle ComboBoxBundle;
    private void ControlsInit()
    {
        Icon = SmallApp.Icon = Icon.ExtractAssociatedIcon(@".\Resources\AppIcon.ico");

        ImportPatternPB.Image = Image.FromFile(@".\Resources\Import.png");
        ToolTips.SetDHToolTip(ImportPatternPB, "Import Pattern");

        ExportPatternPB.Image = Image.FromFile(@".\Resources\Export.png");
        ToolTips.SetDHToolTip(ExportPatternPB, "Export Pattern");

        ImportWorldPatternPB.Image = Image.FromFile(@".\Resources\ImportWorld.png");
        ToolTips.SetDHToolTip(ImportWorldPatternPB, "Import Pattern As World");

        ExportWorldPatternPB.Image = Image.FromFile(@".\Resources\ExportWorld.png");
        ToolTips.SetDHToolTip(ExportWorldPatternPB, "Export Pattern As World");

        ClearPatternPB.Image = Image.FromFile(@".\Resources\Trash.png");
        ToolTips.SetDHToolTip(ClearPatternPB, "Clear This Pattern Layer");

        RightTurnPB.Image = Image.FromFile(@".\Resources\RightTurn.png");
        ToolTips.SetDHToolTip(RightTurnPB, "Turn on Right");

        LeftTurnPB.Image = Image.FromFile(@".\Resources\LeftTurn.png");
        ToolTips.SetDHToolTip(LeftTurnPB, "Turn on Left");

        BackToStartPatternPB.Image = Image.FromFile(@".\Resources\ZoomOut.png");
        ToolTips.SetDHToolTip(BackToStartPatternPB, "Back to Start of Pattern");

        CopyFoundP.Image = Image.FromFile(@".\Resources\Copy.png");
        ToolTips.SetDHToolTip(CopyFoundP, "Copy All Founds In Clipboard");

        ToolTips.SetDHToolTip(YLevelSelectorTrB, "Change Y Level For Pattern");

        UpdateSelectorCollections();

        DeviceSelectDHCB.Text = "Device: ";
        DeviceSelectDHCB.ItemIndex = 0;
        DeviceSelectDHCB.IndexChange += DeviceChanged;

        VersionSelectDHCB.Text = "Version: ";
        VersionSelectDHCB.ItemIndex = 0;
        VersionSelectDHCB.IndexChange += VersionChanged;

        ContextSelectDHCB.Text = "Context: ";
        ContextSelectDHCB.ItemIndex = 0;
        ContextSelectDHCB.IndexChange += ContextChanged;

        ComboBoxBundle = new CComboBoxBundle(DeviceSelectDHCB, VersionSelectDHCB, ContextSelectDHCB);

        SearchExportProgress.Round(20, false, true, false, false);
        SearchImportProgress.Round(20, true, false, false, false);
        SearchResetProgress.Round(20, false, false, false, true);
        MakeAsSmallAppB.Round(15, false, true, false, false);
        CanvasSettingsP.Round(25, true, true, false, false);
        MainDisplayP.Round(25, false, true, true, true);
        SearchB.Round(20, false, false, true, false);
        CloseB.Round(15, true, true, false, false);
        VersionSelectDHCB.Round(20);
        ContextSelectDHCB.Round(20);
        DeviceSelectDHCB.Round(20);
        MainSettingsP.Round(25);
        SearchManageP.Round(25);
        FoundListRTB.Round(20);
        SearchInfoP.Round(25);
        CanvasP.Round(20);
        FoundP.Round(25);
        RangeP.Round(25);
    }
    private CanvasForm canvas = new CanvasForm() { TopLevel = false };
    public MainWindow()
    {
        InitializeComponent();
        CanvasP.Controls.Add(canvas);
        canvas.Show();
        canvas.Location = new Point(-30, -160);
        ToolTips = new CToolTips(new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point));
        ControlsInit();
        ShowInit();
        
        PenP.BackgroundImage = StoneFamilyBlock.DrawVectorPen(BlockType.Bedrock, canvas.Vector);
    }
    private void CloseB_Click(object sender, EventArgs e) => Environment.Exit(0);
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
    #endregion
    #region Canvas
    public void UpdatePatternScore()
    {
        PatternScoreL.Text = "Score: " + Program.Pattern.CalculateScore();
        decimal predicted = Math.Round(Program.SearchRange.BlockRange * Program.Pattern.CalculateFindPercent(), 0, MidpointRounding.AwayFromZero);
        SearchPredictedCountL.Text = "Predicted Count: " + (predicted < 10000 ? predicted : "Much");
    }
    private void ImportPatternPB_Click(object sender, EventArgs e)
    {
        using (OpenFileDialog openFileDialog = new OpenFileDialog())
        {
            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "Pattern File|*.bfp;";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;
            openFileDialog.Multiselect = false;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                canvas.UnDraw();
                Program.Pattern = ConfigManager.ImportPatternAsBFP(openFileDialog.FileName);
                canvas.OverDraw();
                UpdatePatternScore();
            }
        }        
    }
    private void ExportPatternPB_Click(object sender, EventArgs e)
    {
        using (OpenFileDialog openFileDialog = new OpenFileDialog())
        {
            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "Pattern File|*.bfp;";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;
            openFileDialog.CheckFileExists = false; 
            openFileDialog.Multiselect = false;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (!File.Exists(openFileDialog.FileName))
                    File.Create(openFileDialog.FileName).Dispose();
                ConfigManager.ExportPatternAsBFP(Program.Pattern, openFileDialog.FileName);
            }
        }
    }
    private void ExportWorldPatternPB_Click(object sender, EventArgs e)
    {
        using (FolderBrowserDialog openFileDialog = new FolderBrowserDialog())
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (!Directory.Exists(openFileDialog.SelectedPath))
                    Directory.CreateDirectory(openFileDialog.SelectedPath);
                ConfigManager.ExportPatternAsWorld(Program.Pattern, openFileDialog.SelectedPath);
            }
        }
    }
    private void ImportWorldPatternPB_Click(object sender, EventArgs e)
    {
        using (FolderBrowserDialog openFileDialog = new FolderBrowserDialog())
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (!Directory.Exists(openFileDialog.SelectedPath))
                    Directory.CreateDirectory(openFileDialog.SelectedPath);

                BedrockPattern? pattern = ConfigManager.ImportPatternAsWorld(openFileDialog.SelectedPath);
                if (pattern != null)
                {
                    canvas.UnDraw();
                    Program.Pattern = pattern;
                    canvas.OverDraw();
                    UpdatePatternScore();
                }
            }
        }
    }
    private void ClearPatternPB_Click(object sender, EventArgs e)
    {
        Program.Pattern[canvas.YLevel].blockList.ToList().ForEach(z =>
        {
            canvas.DrawBlock(z.x, 31 - z.z, BlockType.None);
            Program.Pattern[canvas.YLevel][z.x, z.z] = BlockType.None;
        });
        UpdatePatternScore();
    }
    private void PatternCurChecker_Tick(object sender, EventArgs e)
    {
        Point panel = new Point(
            Location.X + MainDisplayP.Location.X + CanvasP.Location.X,
            Location.Y + MainDisplayP.Location.Y + CanvasP.Location.Y
        );
        Point curDiff = new Point(Cursor.Position.X - panel.X, Cursor.Position.Y - panel.Y);
        if (curDiff.X > 0 && curDiff.X < 384 && curDiff.Y > 0 && curDiff.Y < 384)
        {
            Point pos = new Point(curDiff.X - canvas.Location.X - 30, 543 - (curDiff.Y - canvas.Location.Y));
            if (pos.X > 0 && pos.Y > 0 && pos.X < 543 && pos.Y < 543)
            {
                Point index = new Point(pos.X / 17, pos.Y / 17);
                (bool x, bool z) points = canvas.Vector.CurrentPoint;
                PatternCoordL.ForeColor = Color.Silver;
                PatternCoordL.Text = "C: " + (points.x ? "" : "-") + index.X + ", " + (points.z ? "" : "-") + index.Y;
                return;
            }
        }
        PatternCoordL.ForeColor = Color.Gray;
        PatternCoordL.Text = "C: NaN";
    }
    private void RightTurnPB_Click(object sender, EventArgs e)
    {
        canvas.Vector.Turn(-1);
        canvas.DrawPointers();
        canvas.OverDraw();
        canvas.Invalidate();
        PenP.Image = StoneFamilyBlock.DrawVectorPen(canvas.PenType, canvas.Vector);
    }
    private void LeftTurnPB_Click(object sender, EventArgs e)
    {
        canvas.Vector.Turn(1);
        canvas.DrawPointers();
        canvas.OverDraw();
        canvas.Invalidate();
        PenP.Image = StoneFamilyBlock.DrawVectorPen(canvas.PenType, canvas.Vector);
    }
    private void YLevelSelectorTrB_Scroll(object sender, EventArgs e)
    {
        YLevelL.Text = $"({(ContextSelectDHCB.ItemIndex != (int)WorldContext.Higher_Nether ? YLevelSelectorTrB.Value : (YLevelSelectorTrB.Value + 122))})";
        canvas.UnDraw();
        canvas.YLevel = (byte)YLevelSelectorTrB.Value;
        canvas.OverDraw();
    }
    private void BackToStartPatternPB_Click(object sender, EventArgs e) => canvas.Location = new Point(-30, -160);
    private void PenP_Click(object sender, EventArgs e)
    {
        if (canvas.PenType == BlockType.Bedrock)
        {
            PenP.Image = StoneFamilyBlock.DrawVectorPen(BlockType.Stone, canvas.Vector);
            canvas.PenType = BlockType.Stone;
        }
        else
        {
            PenP.Image = StoneFamilyBlock.DrawVectorPen(BlockType.Bedrock, canvas.Vector);
            canvas.PenType = BlockType.Bedrock;
        }
    }
    #endregion
    #region Search
    private SearchStatus status = SearchStatus.PatternEdit;
    private object controlLock = new object();
    private void SearchB_Click(object sender, EventArgs e)
    {
        if (status == SearchStatus.PatternEdit || status == SearchStatus.Finish)
        {
            if (Program.Search != null && !Program.Search.Searcher.CanStart)
                return;
            if(Program.Pattern.CalculateScore() < 30)
            {
                MessageBox.Show("not enough pattern score, minimum is 30");
                return;
            }
            FoundedCountL.Text = $"Found: 0";
            FoundListRTB.Text = "";
            if (Program.Search != null)
            {
                Program.Search.UpdateProgress -= UpdateProgress;
                Program.Search.Found -= FoundEvent;
            }
            Program.Search = new BedrockSearch(Program.Pattern, canvas.Vector, Program.SearchRange, Program.DeviceIndex == 0 ? SearchDeviceType.CPU : SearchDeviceType.Kernel);
            Program.Search.UpdateProgress += UpdateProgress;
            Program.Search.Found += FoundEvent;
            status = SearchStatus.Search;
            Program.Search.Result = new List<Vec2i>();
            Program.Search.Searcher.Start();
            SearchB.Text = "Stop Search";
        }
        else if (status == SearchStatus.Search)
        {
            Program.Search.Stop();
            status = SearchStatus.Pause;
            SearchB.Text = "Resume Search";
        }
        else if (status == SearchStatus.Pause)
        {
            if (Program.Search.Searcher.CanStart && Program.Search.Resume())
            {
                status = SearchStatus.Search;
                SearchB.Text = "Stop Search";
            }
        }
        SearchStatusL.Text = $"Status: {statusStrings[status]}";
    }
    private void UpdateProgress(double progress)
    {
        lock (controlLock)
        {
            Invoke(() =>
            {
                if(progress == 100)
                {
                    status = SearchStatus.Finish;
                    SearchStatusL.Text = $"Status: {statusStrings[status]}";
                    SearchB.Text = "Start Search";
                    if (SearchElapsedTimeL.Text == "Elapsed Time:")
                        SearchElapsedTimeL.Text = $"Elapsed Time: 0s";
                }
                SearchProgressL.Text = $"Progress: {Math.Round(progress, 2, MidpointRounding.AwayFromZero)}%";
                SearchElapsedTimeL.Text = $"Elapsed Time: " + Program.Search.Progress.ElapsedTime.ToDescriptiveString();
            });
        }
    }
    private void FoundEvent(Vec2i found)
    {
        lock (controlLock)
        {
            Invoke(() =>
            {
                FoundedCountL.Text = $"Found: " + Program.Search.Result.Count;
                FoundListRTB.Text += $"{Program.Search.Result.Count}. {found.X} {found.Z}\n";
            });
        }
    }
    Dictionary<SearchStatus, string> statusStrings = new Dictionary<SearchStatus, string>()
    {
        { SearchStatus.PatternEdit, "Pattern Editing" },
        { SearchStatus.Search, "Searching" },
        { SearchStatus.Finish, "Finished" },
        { SearchStatus.Pause, "Paused" },
    };

    private void SearchResetProgress_Click(object sender, EventArgs e)
    {
        if (status != SearchStatus.PatternEdit)
        {
            if (status == SearchStatus.Search)
                Program.Search.Stop();
            status = SearchStatus.PatternEdit;
            Program.Search.UpdateProgress -= UpdateProgress;
            Program.Search.Found -= FoundEvent;
            FoundedCountL.Text = $"Found: NaN";
            SearchB.Text = "Start Search";
            SearchProgressL.Text = $"Progress: NaN%";
            SearchElapsedTimeL.Text = $"Elapsed Time: NaN";
            FoundListRTB.Text = "";
        }
    }
    private void SearchExportProgress_Click(object sender, EventArgs e)
    {
        using (OpenFileDialog openFileDialog = new OpenFileDialog())
        {
            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "Pattern File|*.bfr;";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;
            openFileDialog.CheckFileExists = false;
            openFileDialog.Multiselect = false;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (!File.Exists(openFileDialog.FileName))
                    File.Create(openFileDialog.FileName).Dispose();
                if(Program.Search == null)
                    Program.Search = new BedrockSearch(Program.Pattern, canvas.Vector, Program.SearchRange, Program.DeviceIndex == 0 ? SearchDeviceType.CPU : SearchDeviceType.Kernel);
                ConfigManager.ExportSearchAsBFR(Program.Search, openFileDialog.FileName);
            }
        }
    }
    private void SearchImportProgress_Click(object sender, EventArgs e)
    {
        using (OpenFileDialog openFileDialog = new OpenFileDialog())
        {
            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "Pattern File|*.bfr;";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;
            openFileDialog.CheckFileExists = false;
            openFileDialog.Multiselect = false;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (!File.Exists(openFileDialog.FileName))
                    File.Create(openFileDialog.FileName).Dispose();
                canvas.UnDraw();
                Program.Search = ConfigManager.ImportSearchAsBFR(openFileDialog.FileName);
                Program.SearchRange = Program.Search.Range;
                Program.Pattern = Program.Search.Pattern;
                canvas.Vector = Program.Search.Vector;
                canvas.OverDraw();
                FoundListRTB.Text = string.Join('\n', Program.Search.Result.Select((z, i) => $"{i+1}. {z.X} {z.X}"));
                FoundedCountL.Text = $"Found: {Program.Search.Result.Count}";
                XAtTB.Text = Program.Search.Range.Start.X.ToString();
                ZAtTB.Text = Program.Search.Range.Start.Z.ToString();
                XToTB.Text = Program.Search.Range.End.X.ToString();
                ZToTB.Text = Program.Search.Range.End.Z.ToString();
                SearchElapsedTimeL.Text = $"Elapsed Time: {Program.Search.Progress.ElapsedTime.ToDescriptiveString()}";
                SearchProgressL.Text = $"Progress: {(Program.Search.Progress.X == Program.Search.Progress.StartX ? "NaN" : Math.Round(Program.Search.Progress.GetPercent(), 2, MidpointRounding.AwayFromZero))}%";
                RangeSizeL.Text = $"Size {Program.SearchRange.XSize}x{Program.SearchRange.ZSize}";
            }
        }
    }
    private void CopyFoundP_Click(object sender, EventArgs e)
    {
        if (FoundListRTB.Text != "")
            Clipboard.SetText(FoundListRTB.Text);
    }
    #endregion
    #region Indexes
    public void UpdateSelectorCollections()
    {
        DeviceSelectDHCB.Collection = new List<string>()
        {
            "CPU"
        };
        DeviceSelectDHCB.Collection.AddRange(Program.Devices.Select(z => "K -> " + z.Name));
        VersionSelectDHCB.Collection = MinecraftVersions.ToList().Select(z => z.Value).ToList();
        ContextSelectDHCB.Collection = Program.BedrockGens.Where(z => z.Version == MinecraftVersions.Keys.ToList()[Program.VersionIndex]).Select(z => WorldContexts[z.Context]).Distinct().ToList();
    }
    public void ChangedContext()
    {
        bool newContextIsNormal = Program.ContextIndex != (int)WorldContext.Higher_Nether;
        bool nowContextIsNormal = YLevelL.Text.Length == 3;
        if(newContextIsNormal != nowContextIsNormal)
            YLevelL.Text = $"({(newContextIsNormal ? (canvas.YLevel) : (canvas.YLevel + 122))})";
        Program.Gen = Program.BedrockGens.Find(z => 
        z.Context == WorldContexts.Keys.Select(z => z).ToList()[Program.ContextIndex] &&
        z.Version == MinecraftVersions.Keys.Select(z => z).ToList()[Program.VersionIndex]);
    }
    private void VersionChanged(int index)
    {
        if (Program.VersionIndex == index)
            return;
        Program.VersionIndex = index;
        ContextSelectDHCB.Collection = Program.BedrockGens.Where(z => z.Version == MinecraftVersions.Keys.ToList()[index]).Select(z => WorldContexts[z.Context]).Distinct().ToList();
        Program.ContextIndex = ContextSelectDHCB.ItemIndex = 0;
        ChangedContext();
    }
    private void ContextChanged(int index)
    {
        if (Program.ContextIndex == index)
            return;
        Program.ContextIndex = index;
        ChangedContext();
    }
    private void DeviceChanged(int index)
    {
        if (Program.DeviceIndex == index)
            return;
        Program.DeviceIndex = index;
    }
    #endregion
    #region Range
    private void UpdateRange(object sender, EventArgs e)
    {
        TextBox dSender = (TextBox)sender;
        if (ValidateTextCoord(dSender.Text))
        {
            dSender.ForeColor = Color.Silver;
            if (ValidateTextCoord(XAtTB.Text) && ValidateTextCoord(ZAtTB.Text) && ValidateTextCoord(XToTB.Text) && ValidateTextCoord(ZToTB.Text))
            {
                Program.SearchRange = new SearchRange(new Vec2l(int.Parse(XAtTB.Text), int.Parse(ZAtTB.Text)), new Vec2l(int.Parse(XToTB.Text), int.Parse(ZToTB.Text)));
                RangeSizeL.Text = $"Size: {Program.SearchRange.XSize}x{Program.SearchRange.ZSize}";
                UpdatePatternScore();
            }
            return;
        }
        dSender.ForeColor = Color.Red;
    }
    private bool ValidateTextCoord(string text) => int.TryParse(text, out int num) && num >= -30000000 && num <= 30000000;
    #endregion
}