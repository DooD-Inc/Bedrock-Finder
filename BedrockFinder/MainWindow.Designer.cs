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
            this.PatternCoordL = new System.Windows.Forms.Label();
            this.MainSettingsP = new System.Windows.Forms.Panel();
            this.DeviceSelectDHCB = new BedrockFinder.Libraries.DHComboBox();
            this.SearchB = new System.Windows.Forms.Button();
            this.PenP = new System.Windows.Forms.PictureBox();
            this.AutoSavePB = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CanvasP = new System.Windows.Forms.Panel();
            this.CanvasSettingsP = new System.Windows.Forms.Panel();
            this.ClearPatternPB = new System.Windows.Forms.PictureBox();
            this.ExportPatternPB = new System.Windows.Forms.PictureBox();
            this.ImportPatternPB = new System.Windows.Forms.PictureBox();
            this.ToolTips = new System.Windows.Forms.ToolTip(this.components);
            this.PatternCurChecker = new System.Windows.Forms.Timer(this.components);
            this.MainDisplayP.SuspendLayout();
            this.MainSettingsP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PenP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AutoSavePB)).BeginInit();
            this.CanvasSettingsP.SuspendLayout();
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
            this.MainDisplayP.Controls.Add(this.PatternCoordL);
            this.MainDisplayP.Controls.Add(this.MainSettingsP);
            this.MainDisplayP.Controls.Add(this.SearchB);
            this.MainDisplayP.Controls.Add(this.PenP);
            this.MainDisplayP.Controls.Add(this.AutoSavePB);
            this.MainDisplayP.Controls.Add(this.label1);
            this.MainDisplayP.Controls.Add(this.CanvasP);
            this.MainDisplayP.Controls.Add(this.CanvasSettingsP);
            this.MainDisplayP.Location = new System.Drawing.Point(0, 24);
            this.MainDisplayP.Name = "MainDisplayP";
            this.MainDisplayP.Size = new System.Drawing.Size(914, 452);
            this.MainDisplayP.TabIndex = 2;
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
            this.MainSettingsP.Controls.Add(this.DeviceSelectDHCB);
            this.MainSettingsP.Location = new System.Drawing.Point(12, 10);
            this.MainSettingsP.Name = "MainSettingsP";
            this.MainSettingsP.Size = new System.Drawing.Size(236, 426);
            this.MainSettingsP.TabIndex = 6;
            // 
            // DeviceSelectDHCB
            // 
            this.DeviceSelectDHCB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.DeviceSelectDHCB.BorderColor = System.Drawing.Color.Empty;
            this.DeviceSelectDHCB.ContentAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.DeviceSelectDHCB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.DeviceSelectDHCB.ForeColor = System.Drawing.Color.Silver;
            this.DeviceSelectDHCB.GeneralSize = new System.Drawing.Size(230, 39);
            this.DeviceSelectDHCB.ItemSize = new System.Drawing.Size(230, 30);
            this.DeviceSelectDHCB.Location = new System.Drawing.Point(0, 13);
            this.DeviceSelectDHCB.Margin = new System.Windows.Forms.Padding(0);
            this.DeviceSelectDHCB.Name = "DeviceSelectDHCB";
            this.DeviceSelectDHCB.Size = new System.Drawing.Size(236, 37);
            this.DeviceSelectDHCB.TabIndex = 9;
            // 
            // SearchB
            // 
            this.SearchB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.SearchB.FlatAppearance.BorderSize = 0;
            this.SearchB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SearchB.ForeColor = System.Drawing.Color.Silver;
            this.SearchB.Location = new System.Drawing.Point(251, 412);
            this.SearchB.Margin = new System.Windows.Forms.Padding(0);
            this.SearchB.Name = "SearchB";
            this.SearchB.Size = new System.Drawing.Size(127, 24);
            this.SearchB.TabIndex = 13;
            this.SearchB.Text = "Start Search";
            this.SearchB.UseVisualStyleBackColor = false;
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
            // AutoSavePB
            // 
            this.AutoSavePB.Location = new System.Drawing.Point(488, 52);
            this.AutoSavePB.Margin = new System.Windows.Forms.Padding(0);
            this.AutoSavePB.Name = "AutoSavePB";
            this.AutoSavePB.Size = new System.Drawing.Size(24, 24);
            this.AutoSavePB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.AutoSavePB.TabIndex = 11;
            this.AutoSavePB.TabStop = false;
            this.AutoSavePB.Click += new System.EventHandler(this.AutoSavePB_Click);
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
            this.CanvasSettingsP.Controls.Add(this.ClearPatternPB);
            this.CanvasSettingsP.Controls.Add(this.ExportPatternPB);
            this.CanvasSettingsP.Controls.Add(this.ImportPatternPB);
            this.CanvasSettingsP.Location = new System.Drawing.Point(517, 10);
            this.CanvasSettingsP.Margin = new System.Windows.Forms.Padding(0);
            this.CanvasSettingsP.Name = "CanvasSettingsP";
            this.CanvasSettingsP.Size = new System.Drawing.Size(384, 66);
            this.CanvasSettingsP.TabIndex = 7;
            // 
            // ClearPatternPB
            // 
            this.ClearPatternPB.Location = new System.Drawing.Point(292, 9);
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
            this.MainSettingsP.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PenP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AutoSavePB)).EndInit();
            this.CanvasSettingsP.ResumeLayout(false);
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
    private PictureBox AutoSavePB;
    private PictureBox PenP;
    private PictureBox ClearPatternPB;
    private Button SearchB;
    private System.Windows.Forms.Timer PatternCurChecker;
    private Label PatternCoordL;
}
