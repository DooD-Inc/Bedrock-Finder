namespace BedrockFinder;

partial class CanvasForm
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
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
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
            this.SuspendLayout();
            // 
            // CanvasForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.ClientSize = new System.Drawing.Size(575, 574);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CanvasForm";
            this.Text = "CanvasForm";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.CanvasForm_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.CanvasForm_MouseClick);
            this.ResumeLayout(false);

    }

    #endregion
}