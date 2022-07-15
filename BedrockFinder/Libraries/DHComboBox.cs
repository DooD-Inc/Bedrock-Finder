using System.ComponentModel;

namespace BedrockFinder.Libraries;
public partial class DHComboBox : UserControl
{
    public List<string> Collection = new List<string>();
    public int ItemIndex = -1;
    private bool open;
    public DHComboBox()
    {
        SuspendLayout();

        Paint += (s, e) =>
        {
            //OpenCS template = new OpenCS(e.Graphics)
            //{
            //    Font = Font
            //};
            //template.DrawRect(e.ClipRectangle, BorderColor);
            //template.DBrush.SetGradientBrush(e.ClipRectangle, new Color[] { Color.FromArgb(30, 150, 180), Color.FromArgb(30, 90, 150), Color.FromArgb(15, 100, 100), Color.FromArgb(15, 150, 200), Color.FromArgb(30, 150, 150) });
            Graphics g = e.Graphics;
            g.DrawRectangle(new Pen(BorderColor), e.ClipRectangle);
            if (ItemIndex != -1)
            {
                string text = Collection[ItemIndex];                
                Point location = GetLocation(text);                
                g.DrawString(Text + text, Font, new SolidBrush(ForeColor), location);
            }
        };

        Click += (s, e) =>
        {
            open = !open;
            if (open)
            {
                ((Control)s).BringToFront();
                Size = new Size(GeneralSize.Width, GeneralSize.Height + ItemSize.Height * Collection.Count);
            }
            else
            {
                Size = GeneralSize;
            }
        };

        ResumeLayout();
    }
    private Point GetLocation(string text)
    {
        Size labelSize = TextRenderer.MeasureText(text, Font);
        switch (ContentAlignment)
        {
            case ContentAlignment.TopCenter: return new(GeneralSize.Width / 2 - labelSize.Width / 2, 0);
            case ContentAlignment.TopLeft: return new(0, 0);
            case ContentAlignment.TopRight: return new(GeneralSize.Width - labelSize.Width, 0);
            case ContentAlignment.BottomCenter: return new(GeneralSize.Width / 2 - labelSize.Width / 2, GeneralSize.Height - labelSize.Height);
            case ContentAlignment.BottomLeft: return new(0, GeneralSize.Height - labelSize.Height);
            case ContentAlignment.BottomRight: return new(GeneralSize.Width - labelSize.Width, GeneralSize.Height - labelSize.Height);
            case ContentAlignment.MiddleCenter: return new(GeneralSize.Width / 2 - labelSize.Width / 2, GeneralSize.Height / 2 - labelSize.Height / 2);
            case ContentAlignment.MiddleLeft: return new(0, GeneralSize.Height / 2 - labelSize.Height / 2);
            case ContentAlignment.MiddleRight: return new(GeneralSize.Width - labelSize.Width, GeneralSize.Height / 2 - labelSize.Height / 2);
        }
        return default;
    }
    [Category("Appearance")]
    public ContentAlignment ContentAlignment { get; set; }
    [Category("Appearance")]
    public Color BorderColor { get; set; }
    [Category("Appearance")]
    public override string? Text { get; set; }
    [Category("Appearance")]
    public Size ItemSize { get; set; } = new Size(100, 30);
    [Category("Appearance")]
    public Size GeneralSize { get; set; } = new Size(100, 30);
}