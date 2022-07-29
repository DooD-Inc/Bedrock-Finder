using BedrockFinder.Libraries;

namespace BedrockFinder;

public partial class MainWindow : DHForm
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
            this.components = new System.ComponentModel.Container();
            this.CloseB = new System.Windows.Forms.Button();
            this.SmallApp = new System.Windows.Forms.NotifyIcon(this.components);
            this.MakeAsSmallAppB = new System.Windows.Forms.Button();
            this.MainDisplayP = new System.Windows.Forms.Panel();
            this.PatternScoreL = new System.Windows.Forms.Label();
            this.FoundP = new System.Windows.Forms.Panel();
            this.CopyFoundP = new System.Windows.Forms.PictureBox();
            this.FoundListRTB = new System.Windows.Forms.RichTextBox();
            this.FoundedCountL = new System.Windows.Forms.Label();
            this.SearchManageP = new System.Windows.Forms.Panel();
            this.SearchResetProgress = new System.Windows.Forms.Button();
            this.SearchImportProgress = new System.Windows.Forms.Button();
            this.SearchExportProgress = new System.Windows.Forms.Button();
            this.SearchB = new System.Windows.Forms.Button();
            this.SearchInfoP = new System.Windows.Forms.Panel();
            this.SearchElapsedTimeL = new System.Windows.Forms.Label();
            this.SearchStatusL = new System.Windows.Forms.Label();
            this.SearchProgressL = new System.Windows.Forms.Label();
            this.YLevelDataL = new System.Windows.Forms.Label();
            this.YLevelL = new System.Windows.Forms.Label();
            this.YLevelSelectorTrB = new System.Windows.Forms.TrackBar();
            this.PatternCoordL = new System.Windows.Forms.Label();
            this.MainSettingsP = new System.Windows.Forms.Panel();
            this.ContextSelectDHCB = new BedrockFinder.Libraries.DHComboBox();
            this.VersionSelectDHCB = new BedrockFinder.Libraries.DHComboBox();
            this.DeviceSelectDHCB = new BedrockFinder.Libraries.DHComboBox();
            this.PenP = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CanvasP = new System.Windows.Forms.Panel();
            this.CanvasSettingsP = new System.Windows.Forms.Panel();
            this.BackToStartPatternPB = new System.Windows.Forms.PictureBox();
            this.ExportWorldPatternPB = new System.Windows.Forms.PictureBox();
            this.ImportWorldPatternPB = new System.Windows.Forms.PictureBox();
            this.LeftTurnPB = new System.Windows.Forms.PictureBox();
            this.RightTurnPB = new System.Windows.Forms.PictureBox();
            this.ClearPatternPB = new System.Windows.Forms.PictureBox();
            this.ExportPatternPB = new System.Windows.Forms.PictureBox();
            this.ImportPatternPB = new System.Windows.Forms.PictureBox();
            this.ToolTips = new System.Windows.Forms.ToolTip(this.components);
            this.PatternCurChecker = new System.Windows.Forms.Timer(this.components);
            this.SearchPredictedCountL = new System.Windows.Forms.Label();
            this.MainDisplayP.SuspendLayout();
            this.FoundP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CopyFoundP)).BeginInit();
            this.SearchManageP.SuspendLayout();
            this.SearchInfoP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.YLevelSelectorTrB)).BeginInit();
            this.MainSettingsP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PenP)).BeginInit();
            this.CanvasSettingsP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BackToStartPatternPB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExportWorldPatternPB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImportWorldPatternPB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftTurnPB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightTurnPB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClearPatternPB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExportPatternPB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImportPatternPB)).BeginInit();
            this.SuspendLayout();
            // 
            // CloseB
            // 
            this.CloseB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.CloseB.FlatAppearance.BorderSize = 0;
            this.CloseB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseB.ForeColor = System.Drawing.Color.Silver;
            this.CloseB.Location = new System.Drawing.Point(890, 0);
            this.CloseB.Margin = new System.Windows.Forms.Padding(0);
            this.CloseB.Name = "CloseB";
            this.CloseB.Size = new System.Drawing.Size(24, 24);
            this.CloseB.TabIndex = 0;
            this.CloseB.Text = "X";
            this.CloseB.UseVisualStyleBackColor = false;
            this.CloseB.Click += new System.EventHandler(this.CloseB_Click);
            // 
            // SmallApp
            // 
            this.SmallApp.BalloonTipText = "Doing nothing";
            this.SmallApp.BalloonTipTitle = "BedrockFinder";
            this.SmallApp.Text = "BedrockFinder - SmallApp";
            this.SmallApp.Click += new System.EventHandler(this.SmallApp_Click);
            // 
            // MakeAsSmallAppB
            // 
            this.MakeAsSmallAppB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.MakeAsSmallAppB.FlatAppearance.BorderSize = 0;
            this.MakeAsSmallAppB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MakeAsSmallAppB.ForeColor = System.Drawing.Color.Silver;
            this.MakeAsSmallAppB.Location = new System.Drawing.Point(866, 9);
            this.MakeAsSmallAppB.Margin = new System.Windows.Forms.Padding(0);
            this.MakeAsSmallAppB.Name = "MakeAsSmallAppB";
            this.MakeAsSmallAppB.Size = new System.Drawing.Size(24, 15);
            this.MakeAsSmallAppB.TabIndex = 1;
            this.MakeAsSmallAppB.Text = " Try to find me";
            this.MakeAsSmallAppB.UseVisualStyleBackColor = false;
            this.MakeAsSmallAppB.Click += new System.EventHandler(this.MakeAsSmallAppB_Click);
            // 
            // MainDisplayP
            // 
            this.MainDisplayP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.MainDisplayP.Controls.Add(this.PatternScoreL);
            this.MainDisplayP.Controls.Add(this.FoundP);
            this.MainDisplayP.Controls.Add(this.SearchManageP);
            this.MainDisplayP.Controls.Add(this.SearchInfoP);
            this.MainDisplayP.Controls.Add(this.YLevelDataL);
            this.MainDisplayP.Controls.Add(this.YLevelL);
            this.MainDisplayP.Controls.Add(this.YLevelSelectorTrB);
            this.MainDisplayP.Controls.Add(this.PatternCoordL);
            this.MainDisplayP.Controls.Add(this.MainSettingsP);
            this.MainDisplayP.Controls.Add(this.PenP);
            this.MainDisplayP.Controls.Add(this.label1);
            this.MainDisplayP.Controls.Add(this.CanvasP);
            this.MainDisplayP.Controls.Add(this.CanvasSettingsP);
            this.MainDisplayP.Location = new System.Drawing.Point(0, 24);
            this.MainDisplayP.Name = "MainDisplayP";
            this.MainDisplayP.Size = new System.Drawing.Size(914, 452);
            this.MainDisplayP.TabIndex = 2;
            // 
            // PatternScoreL
            // 
            this.PatternScoreL.AutoSize = true;
            this.PatternScoreL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PatternScoreL.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.PatternScoreL.ForeColor = System.Drawing.Color.Silver;
            this.PatternScoreL.Location = new System.Drawing.Point(581, 436);
            this.PatternScoreL.Name = "PatternScoreL";
            this.PatternScoreL.Size = new System.Drawing.Size(45, 15);
            this.PatternScoreL.TabIndex = 25;
            this.PatternScoreL.Text = "Score: ";
            // 
            // FoundP
            // 
            this.FoundP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.FoundP.Controls.Add(this.CopyFoundP);
            this.FoundP.Controls.Add(this.FoundListRTB);
            this.FoundP.Controls.Add(this.FoundedCountL);
            this.FoundP.Location = new System.Drawing.Point(3, 12);
            this.FoundP.Name = "FoundP";
            this.FoundP.Size = new System.Drawing.Size(248, 437);
            this.FoundP.TabIndex = 24;
            // 
            // CopyFoundP
            // 
            this.CopyFoundP.Location = new System.Drawing.Point(226, 2);
            this.CopyFoundP.Margin = new System.Windows.Forms.Padding(0);
            this.CopyFoundP.Name = "CopyFoundP";
            this.CopyFoundP.Size = new System.Drawing.Size(22, 22);
            this.CopyFoundP.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.CopyFoundP.TabIndex = 25;
            this.CopyFoundP.TabStop = false;
            this.CopyFoundP.Click += new System.EventHandler(this.CopyFoundP_Click);
            // 
            // FoundListRTB
            // 
            this.FoundListRTB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.FoundListRTB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.FoundListRTB.ForeColor = System.Drawing.Color.Silver;
            this.FoundListRTB.Location = new System.Drawing.Point(7, 27);
            this.FoundListRTB.Name = "FoundListRTB";
            this.FoundListRTB.ReadOnly = true;
            this.FoundListRTB.Size = new System.Drawing.Size(234, 401);
            this.FoundListRTB.TabIndex = 24;
            this.FoundListRTB.Text = "";
            // 
            // FoundedCountL
            // 
            this.FoundedCountL.AutoSize = true;
            this.FoundedCountL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FoundedCountL.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.FoundedCountL.ForeColor = System.Drawing.Color.Silver;
            this.FoundedCountL.Location = new System.Drawing.Point(3, 4);
            this.FoundedCountL.Name = "FoundedCountL";
            this.FoundedCountL.Size = new System.Drawing.Size(104, 20);
            this.FoundedCountL.TabIndex = 23;
            this.FoundedCountL.Text = "Found: NaN";
            // 
            // SearchManageP
            // 
            this.SearchManageP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.SearchManageP.Controls.Add(this.SearchResetProgress);
            this.SearchManageP.Controls.Add(this.SearchImportProgress);
            this.SearchManageP.Controls.Add(this.SearchExportProgress);
            this.SearchManageP.Controls.Add(this.SearchB);
            this.SearchManageP.Location = new System.Drawing.Point(254, 107);
            this.SearchManageP.Name = "SearchManageP";
            this.SearchManageP.Size = new System.Drawing.Size(257, 63);
            this.SearchManageP.TabIndex = 23;
            // 
            // SearchResetProgress
            // 
            this.SearchResetProgress.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.SearchResetProgress.FlatAppearance.BorderSize = 0;
            this.SearchResetProgress.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SearchResetProgress.ForeColor = System.Drawing.Color.Silver;
            this.SearchResetProgress.Location = new System.Drawing.Point(127, 32);
            this.SearchResetProgress.Margin = new System.Windows.Forms.Padding(0);
            this.SearchResetProgress.Name = "SearchResetProgress";
            this.SearchResetProgress.Size = new System.Drawing.Size(122, 24);
            this.SearchResetProgress.TabIndex = 16;
            this.SearchResetProgress.Text = "Reset Progress";
            this.SearchResetProgress.UseVisualStyleBackColor = false;
            this.SearchResetProgress.Click += new System.EventHandler(this.SearchResetProgress_Click);
            // 
            // SearchImportProgress
            // 
            this.SearchImportProgress.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.SearchImportProgress.FlatAppearance.BorderSize = 0;
            this.SearchImportProgress.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SearchImportProgress.ForeColor = System.Drawing.Color.Silver;
            this.SearchImportProgress.Location = new System.Drawing.Point(127, 8);
            this.SearchImportProgress.Margin = new System.Windows.Forms.Padding(0);
            this.SearchImportProgress.Name = "SearchImportProgress";
            this.SearchImportProgress.Size = new System.Drawing.Size(122, 24);
            this.SearchImportProgress.TabIndex = 15;
            this.SearchImportProgress.Text = "Import Progress";
            this.SearchImportProgress.UseVisualStyleBackColor = false;
            this.SearchImportProgress.Click += new System.EventHandler(this.SearchImportProgress_Click);
            // 
            // SearchExportProgress
            // 
            this.SearchExportProgress.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.SearchExportProgress.FlatAppearance.BorderSize = 0;
            this.SearchExportProgress.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SearchExportProgress.ForeColor = System.Drawing.Color.Silver;
            this.SearchExportProgress.Location = new System.Drawing.Point(5, 8);
            this.SearchExportProgress.Margin = new System.Windows.Forms.Padding(0);
            this.SearchExportProgress.Name = "SearchExportProgress";
            this.SearchExportProgress.Size = new System.Drawing.Size(122, 24);
            this.SearchExportProgress.TabIndex = 14;
            this.SearchExportProgress.Text = "Export Progress";
            this.SearchExportProgress.UseVisualStyleBackColor = false;
            this.SearchExportProgress.Click += new System.EventHandler(this.SearchExportProgress_Click);
            // 
            // SearchB
            // 
            this.SearchB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.SearchB.FlatAppearance.BorderSize = 0;
            this.SearchB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SearchB.ForeColor = System.Drawing.Color.Silver;
            this.SearchB.Location = new System.Drawing.Point(5, 32);
            this.SearchB.Margin = new System.Windows.Forms.Padding(0);
            this.SearchB.Name = "SearchB";
            this.SearchB.Size = new System.Drawing.Size(122, 24);
            this.SearchB.TabIndex = 13;
            this.SearchB.Text = "Start Search";
            this.SearchB.UseVisualStyleBackColor = false;
            this.SearchB.Click += new System.EventHandler(this.SearchB_Click);
            // 
            // SearchInfoP
            // 
            this.SearchInfoP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.SearchInfoP.Controls.Add(this.SearchPredictedCountL);
            this.SearchInfoP.Controls.Add(this.SearchElapsedTimeL);
            this.SearchInfoP.Controls.Add(this.SearchStatusL);
            this.SearchInfoP.Controls.Add(this.SearchProgressL);
            this.SearchInfoP.Location = new System.Drawing.Point(254, 10);
            this.SearchInfoP.Name = "SearchInfoP";
            this.SearchInfoP.Size = new System.Drawing.Size(257, 91);
            this.SearchInfoP.TabIndex = 19;
            // 
            // SearchElapsedTimeL
            // 
            this.SearchElapsedTimeL.AutoSize = true;
            this.SearchElapsedTimeL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SearchElapsedTimeL.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.SearchElapsedTimeL.ForeColor = System.Drawing.Color.Silver;
            this.SearchElapsedTimeL.Location = new System.Drawing.Point(3, 46);
            this.SearchElapsedTimeL.Name = "SearchElapsedTimeL";
            this.SearchElapsedTimeL.Size = new System.Drawing.Size(161, 20);
            this.SearchElapsedTimeL.TabIndex = 21;
            this.SearchElapsedTimeL.Text = "Elapsed Time: NaN";
            // 
            // SearchStatusL
            // 
            this.SearchStatusL.AutoSize = true;
            this.SearchStatusL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SearchStatusL.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.SearchStatusL.ForeColor = System.Drawing.Color.Silver;
            this.SearchStatusL.Location = new System.Drawing.Point(3, 26);
            this.SearchStatusL.Name = "SearchStatusL";
            this.SearchStatusL.Size = new System.Drawing.Size(192, 20);
            this.SearchStatusL.TabIndex = 20;
            this.SearchStatusL.Text = "Status: Pattern Editing";
            // 
            // SearchProgressL
            // 
            this.SearchProgressL.AutoSize = true;
            this.SearchProgressL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SearchProgressL.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.SearchProgressL.ForeColor = System.Drawing.Color.Silver;
            this.SearchProgressL.Location = new System.Drawing.Point(3, 5);
            this.SearchProgressL.Name = "SearchProgressL";
            this.SearchProgressL.Size = new System.Drawing.Size(139, 20);
            this.SearchProgressL.TabIndex = 19;
            this.SearchProgressL.Text = "Progress: NaN%";
            // 
            // YLevelDataL
            // 
            this.YLevelDataL.AutoSize = true;
            this.YLevelDataL.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.YLevelDataL.ForeColor = System.Drawing.Color.Silver;
            this.YLevelDataL.Location = new System.Drawing.Point(700, 436);
            this.YLevelDataL.Name = "YLevelDataL";
            this.YLevelDataL.Size = new System.Drawing.Size(49, 15);
            this.YLevelDataL.TabIndex = 18;
            this.YLevelDataL.Text = "Y Level:";
            // 
            // YLevelL
            // 
            this.YLevelL.AutoSize = true;
            this.YLevelL.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.YLevelL.ForeColor = System.Drawing.Color.Silver;
            this.YLevelL.Location = new System.Drawing.Point(877, 437);
            this.YLevelL.Name = "YLevelL";
            this.YLevelL.Size = new System.Drawing.Size(22, 15);
            this.YLevelL.TabIndex = 17;
            this.YLevelL.Text = "(4)";
            // 
            // YLevelSelectorTrB
            // 
            this.YLevelSelectorTrB.LargeChange = 1;
            this.YLevelSelectorTrB.Location = new System.Drawing.Point(745, 436);
            this.YLevelSelectorTrB.Margin = new System.Windows.Forms.Padding(0);
            this.YLevelSelectorTrB.Maximum = 4;
            this.YLevelSelectorTrB.Minimum = 1;
            this.YLevelSelectorTrB.Name = "YLevelSelectorTrB";
            this.YLevelSelectorTrB.Size = new System.Drawing.Size(140, 45);
            this.YLevelSelectorTrB.TabIndex = 16;
            this.YLevelSelectorTrB.TickStyle = System.Windows.Forms.TickStyle.None;
            this.YLevelSelectorTrB.Value = 4;
            this.YLevelSelectorTrB.Scroll += new System.EventHandler(this.YLevelSelectorTrB_Scroll);
            // 
            // PatternCoordL
            // 
            this.PatternCoordL.AutoSize = true;
            this.PatternCoordL.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.PatternCoordL.ForeColor = System.Drawing.Color.Silver;
            this.PatternCoordL.Location = new System.Drawing.Point(517, 436);
            this.PatternCoordL.Name = "PatternCoordL";
            this.PatternCoordL.Size = new System.Drawing.Size(18, 15);
            this.PatternCoordL.TabIndex = 14;
            this.PatternCoordL.Text = "C:";
            // 
            // MainSettingsP
            // 
            this.MainSettingsP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.MainSettingsP.Controls.Add(this.ContextSelectDHCB);
            this.MainSettingsP.Controls.Add(this.VersionSelectDHCB);
            this.MainSettingsP.Controls.Add(this.DeviceSelectDHCB);
            this.MainSettingsP.Location = new System.Drawing.Point(254, 176);
            this.MainSettingsP.Name = "MainSettingsP";
            this.MainSettingsP.Size = new System.Drawing.Size(257, 212);
            this.MainSettingsP.TabIndex = 6;
            // 
            // ContextSelectDHCB
            // 
            this.ContextSelectDHCB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.ContextSelectDHCB.BorderColor = System.Drawing.Color.Empty;
            this.ContextSelectDHCB.ContentAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.ContextSelectDHCB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ContextSelectDHCB.ForeColor = System.Drawing.Color.Silver;
            this.ContextSelectDHCB.ItemSize = new System.Drawing.Size(249, 28);
            this.ContextSelectDHCB.Location = new System.Drawing.Point(4, 72);
            this.ContextSelectDHCB.Margin = new System.Windows.Forms.Padding(0);
            this.ContextSelectDHCB.Name = "ContextSelectDHCB";
            this.ContextSelectDHCB.Size = new System.Drawing.Size(249, 28);
            this.ContextSelectDHCB.TabIndex = 11;
            // 
            // VersionSelectDHCB
            // 
            this.VersionSelectDHCB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.VersionSelectDHCB.BorderColor = System.Drawing.Color.Empty;
            this.VersionSelectDHCB.ContentAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.VersionSelectDHCB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.VersionSelectDHCB.ForeColor = System.Drawing.Color.Silver;
            this.VersionSelectDHCB.ItemSize = new System.Drawing.Size(249, 28);
            this.VersionSelectDHCB.Location = new System.Drawing.Point(4, 39);
            this.VersionSelectDHCB.Margin = new System.Windows.Forms.Padding(0);
            this.VersionSelectDHCB.Name = "VersionSelectDHCB";
            this.VersionSelectDHCB.Size = new System.Drawing.Size(249, 28);
            this.VersionSelectDHCB.TabIndex = 10;
            // 
            // DeviceSelectDHCB
            // 
            this.DeviceSelectDHCB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.DeviceSelectDHCB.BorderColor = System.Drawing.Color.Empty;
            this.DeviceSelectDHCB.ContentAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.DeviceSelectDHCB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.DeviceSelectDHCB.ForeColor = System.Drawing.Color.Silver;
            this.DeviceSelectDHCB.ItemSize = new System.Drawing.Size(249, 28);
            this.DeviceSelectDHCB.Location = new System.Drawing.Point(4, 6);
            this.DeviceSelectDHCB.Margin = new System.Windows.Forms.Padding(0);
            this.DeviceSelectDHCB.Name = "DeviceSelectDHCB";
            this.DeviceSelectDHCB.Size = new System.Drawing.Size(249, 28);
            this.DeviceSelectDHCB.TabIndex = 9;
            // 
            // PenP
            // 
            this.PenP.Location = new System.Drawing.Point(482, 404);
            this.PenP.Name = "PenP";
            this.PenP.Size = new System.Drawing.Size(32, 32);
            this.PenP.TabIndex = 12;
            this.PenP.TabStop = false;
            this.PenP.Click += new System.EventHandler(this.PenP_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.label1.Location = new System.Drawing.Point(3, 436);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 15);
            this.label1.TabIndex = 8;
            this.label1.Text = "Made by Yotic";
            // 
            // CanvasP
            // 
            this.CanvasP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.CanvasP.Location = new System.Drawing.Point(517, 52);
            this.CanvasP.Margin = new System.Windows.Forms.Padding(0);
            this.CanvasP.Name = "CanvasP";
            this.CanvasP.Size = new System.Drawing.Size(384, 384);
            this.CanvasP.TabIndex = 5;
            // 
            // CanvasSettingsP
            // 
            this.CanvasSettingsP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.CanvasSettingsP.Controls.Add(this.BackToStartPatternPB);
            this.CanvasSettingsP.Controls.Add(this.ExportWorldPatternPB);
            this.CanvasSettingsP.Controls.Add(this.ImportWorldPatternPB);
            this.CanvasSettingsP.Controls.Add(this.LeftTurnPB);
            this.CanvasSettingsP.Controls.Add(this.RightTurnPB);
            this.CanvasSettingsP.Controls.Add(this.ClearPatternPB);
            this.CanvasSettingsP.Controls.Add(this.ExportPatternPB);
            this.CanvasSettingsP.Controls.Add(this.ImportPatternPB);
            this.CanvasSettingsP.Location = new System.Drawing.Point(517, 10);
            this.CanvasSettingsP.Margin = new System.Windows.Forms.Padding(0);
            this.CanvasSettingsP.Name = "CanvasSettingsP";
            this.CanvasSettingsP.Size = new System.Drawing.Size(384, 66);
            this.CanvasSettingsP.TabIndex = 7;
            // 
            // BackToStartPatternPB
            // 
            this.BackToStartPatternPB.Location = new System.Drawing.Point(144, 6);
            this.BackToStartPatternPB.Margin = new System.Windows.Forms.Padding(0);
            this.BackToStartPatternPB.Name = "BackToStartPatternPB";
            this.BackToStartPatternPB.Size = new System.Drawing.Size(32, 32);
            this.BackToStartPatternPB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.BackToStartPatternPB.TabIndex = 16;
            this.BackToStartPatternPB.TabStop = false;
            this.BackToStartPatternPB.Click += new System.EventHandler(this.BackToStartPatternPB_Click);
            // 
            // ExportWorldPatternPB
            // 
            this.ExportWorldPatternPB.Location = new System.Drawing.Point(261, 12);
            this.ExportWorldPatternPB.Margin = new System.Windows.Forms.Padding(0);
            this.ExportWorldPatternPB.Name = "ExportWorldPatternPB";
            this.ExportWorldPatternPB.Size = new System.Drawing.Size(22, 22);
            this.ExportWorldPatternPB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ExportWorldPatternPB.TabIndex = 15;
            this.ExportWorldPatternPB.TabStop = false;
            this.ExportWorldPatternPB.Click += new System.EventHandler(this.ExportWorldPatternPB_Click);
            // 
            // ImportWorldPatternPB
            // 
            this.ImportWorldPatternPB.Location = new System.Drawing.Point(292, 12);
            this.ImportWorldPatternPB.Margin = new System.Windows.Forms.Padding(0);
            this.ImportWorldPatternPB.Name = "ImportWorldPatternPB";
            this.ImportWorldPatternPB.Size = new System.Drawing.Size(22, 22);
            this.ImportWorldPatternPB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ImportWorldPatternPB.TabIndex = 14;
            this.ImportWorldPatternPB.TabStop = false;
            this.ImportWorldPatternPB.Click += new System.EventHandler(this.ImportWorldPatternPB_Click);
            // 
            // LeftTurnPB
            // 
            this.LeftTurnPB.Location = new System.Drawing.Point(176, 11);
            this.LeftTurnPB.Margin = new System.Windows.Forms.Padding(0);
            this.LeftTurnPB.Name = "LeftTurnPB";
            this.LeftTurnPB.Size = new System.Drawing.Size(22, 22);
            this.LeftTurnPB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.LeftTurnPB.TabIndex = 13;
            this.LeftTurnPB.TabStop = false;
            this.LeftTurnPB.Click += new System.EventHandler(this.LeftTurnPB_Click);
            // 
            // RightTurnPB
            // 
            this.RightTurnPB.Location = new System.Drawing.Point(204, 11);
            this.RightTurnPB.Margin = new System.Windows.Forms.Padding(0);
            this.RightTurnPB.Name = "RightTurnPB";
            this.RightTurnPB.Size = new System.Drawing.Size(22, 22);
            this.RightTurnPB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.RightTurnPB.TabIndex = 12;
            this.RightTurnPB.TabStop = false;
            this.RightTurnPB.Click += new System.EventHandler(this.RightTurnPB_Click);
            // 
            // ClearPatternPB
            // 
            this.ClearPatternPB.Location = new System.Drawing.Point(228, 9);
            this.ClearPatternPB.Margin = new System.Windows.Forms.Padding(0);
            this.ClearPatternPB.Name = "ClearPatternPB";
            this.ClearPatternPB.Size = new System.Drawing.Size(26, 26);
            this.ClearPatternPB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ClearPatternPB.TabIndex = 11;
            this.ClearPatternPB.TabStop = false;
            this.ClearPatternPB.Click += new System.EventHandler(this.ClearPatternPB_Click);
            // 
            // ExportPatternPB
            // 
            this.ExportPatternPB.Location = new System.Drawing.Point(322, 9);
            this.ExportPatternPB.Margin = new System.Windows.Forms.Padding(0);
            this.ExportPatternPB.Name = "ExportPatternPB";
            this.ExportPatternPB.Size = new System.Drawing.Size(24, 24);
            this.ExportPatternPB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ExportPatternPB.TabIndex = 10;
            this.ExportPatternPB.TabStop = false;
            this.ExportPatternPB.Click += new System.EventHandler(this.ExportPatternPB_Click);
            // 
            // ImportPatternPB
            // 
            this.ImportPatternPB.Location = new System.Drawing.Point(353, 9);
            this.ImportPatternPB.Margin = new System.Windows.Forms.Padding(0);
            this.ImportPatternPB.Name = "ImportPatternPB";
            this.ImportPatternPB.Size = new System.Drawing.Size(24, 24);
            this.ImportPatternPB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ImportPatternPB.TabIndex = 9;
            this.ImportPatternPB.TabStop = false;
            this.ImportPatternPB.Click += new System.EventHandler(this.ImportPatternPB_Click);
            // 
            // ToolTips
            // 
            this.ToolTips.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(57)))), ((int)(((byte)(57)))));
            this.ToolTips.ForeColor = System.Drawing.Color.Silver;
            // 
            // PatternCurChecker
            // 
            this.PatternCurChecker.Enabled = true;
            this.PatternCurChecker.Interval = 20;
            this.PatternCurChecker.Tick += new System.EventHandler(this.PatternCurChecker_Tick);
            // 
            // SearchPredictedCountL
            // 
            this.SearchPredictedCountL.AutoSize = true;
            this.SearchPredictedCountL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SearchPredictedCountL.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.SearchPredictedCountL.ForeColor = System.Drawing.Color.Silver;
            this.SearchPredictedCountL.Location = new System.Drawing.Point(3, 66);
            this.SearchPredictedCountL.Name = "SearchPredictedCountL";
            this.SearchPredictedCountL.Size = new System.Drawing.Size(182, 20);
            this.SearchPredictedCountL.TabIndex = 22;
            this.SearchPredictedCountL.Text = "Predicted Count: NaN";
            // 
            // MainWindow
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Lime;
            this.ClientSize = new System.Drawing.Size(914, 476);
            this.Controls.Add(this.MainDisplayP);
            this.Controls.Add(this.MakeAsSmallAppB);
            this.Controls.Add(this.CloseB);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainWindow";
            this.Text = "BedrockFinder";
            this.MainDisplayP.ResumeLayout(false);
            this.MainDisplayP.PerformLayout();
            this.FoundP.ResumeLayout(false);
            this.FoundP.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CopyFoundP)).EndInit();
            this.SearchManageP.ResumeLayout(false);
            this.SearchInfoP.ResumeLayout(false);
            this.SearchInfoP.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.YLevelSelectorTrB)).EndInit();
            this.MainSettingsP.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PenP)).EndInit();
            this.CanvasSettingsP.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BackToStartPatternPB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExportWorldPatternPB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImportWorldPatternPB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftTurnPB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightTurnPB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClearPatternPB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExportPatternPB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImportPatternPB)).EndInit();
            this.ResumeLayout(false);

    }

    #endregion

    private Button CloseB;
    private NotifyIcon SmallApp;
    private Button MakeAsSmallAppB;
    private Panel MainDisplayP;
    private Panel CanvasSettingsP;
    private Panel MainSettingsP;
    private Panel CanvasP;
    private Label label1;
    private DHComboBox DeviceSelectDHCB;
    private PictureBox ImportPatternPB;
    private PictureBox ExportPatternPB;
    private ToolTip ToolTips;
    private PictureBox PenP;
    private PictureBox ClearPatternPB;
    private Button SearchB;
    private System.Windows.Forms.Timer PatternCurChecker;
    private Label PatternCoordL;
    private PictureBox LeftTurnPB;
    private PictureBox RightTurnPB;
    private TrackBar YLevelSelectorTrB;
    private Label YLevelL;
    private Label YLevelDataL;
    private Panel SearchInfoP;
    private Label SearchProgressL;
    private Label SearchStatusL;
    private Label SearchElapsedTimeL;
    private Panel SearchManageP;
    private Button SearchResetProgress;
    private Button SearchImportProgress;
    private Button SearchExportProgress;
    private Panel FoundP;
    private Label FoundedCountL;
    private RichTextBox FoundListRTB;
    private PictureBox CopyFoundP;
    private PictureBox ExportWorldPatternPB;
    private PictureBox ImportWorldPatternPB;
    private DHComboBox VersionSelectDHCB;
    private DHComboBox ContextSelectDHCB;
    private Label PatternScoreL;
    private PictureBox BackToStartPatternPB;
    private Label SearchPredictedCountL;
}
