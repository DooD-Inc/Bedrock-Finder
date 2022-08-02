using System.ComponentModel;

namespace BedrockFinder.Libraries;
public partial class DHComboBox : UserControl
{
    public delegate void IndexChangeHandler(int index);
    public event IndexChangeHandler? IndexChange;
    public List<string> Collection = new List<string>();
    private bool open;
    public DHComboBox()
    {
        SuspendLayout();

        Paint += (s, e) =>
        {
            Graphics g = e.Graphics;
            g.DrawRectangle(new Pen(BorderColor), e.ClipRectangle);
            int nextLoc = 0;
            if (ItemIndex != -1)
            {
                string text = Collection[ItemIndex];                
                Point location = GetLocation(text);
                nextLoc += ItemSize.Height;
                g.DrawString(Text + text, Font, new SolidBrush(ForeColor), location);
            }
            foreach(string item in Collection)
            {
                Point rawLoc = GetLocation(item);
                Size rawSize = TextRenderer.MeasureText(item, Font);
                Point location = new Point(rawLoc.X, nextLoc);
                g.DrawString(item, Font, new SolidBrush(ForeColor), location);
                nextLoc += rawSize.Height;
            }
        };

        MouseClick += (s, e) =>
        {
            open = !open;
            if (open)
            {
                ((Control)s).BringToFront();
                Size = new Size(ItemSize.Width, ItemSize.Height + Collection.Count * TextRenderer.MeasureText("l", Font).Height);
                this.Round(20);
            }
            else
            {
                if (e.Y > ItemSize.Height)
                {
                    ItemIndex = (e.Y - ItemSize.Height) / TextRenderer.MeasureText("l", Font).Height;
                    IndexChange?.Invoke(ItemIndex);
                    Invalidate();
                }
                Size = ItemSize;
                this.Round(20);
            }
        };

        ResumeLayout();
    }
    private Point GetLocation(string text)
    {
        Size labelSize = TextRenderer.MeasureText(text, Font);
        switch (ContentAlignment)
        {
            case ContentAlignment.TopCenter: return new(ItemSize.Width / 2 - labelSize.Width / 2, 0);
            case ContentAlignment.TopLeft: return new(0, 0);
            case ContentAlignment.TopRight: return new(ItemSize.Width - labelSize.Width, 0);
            case ContentAlignment.BottomCenter: return new(ItemSize.Width / 2 - labelSize.Width / 2, ItemSize.Height - labelSize.Height);
            case ContentAlignment.BottomLeft: return new(0, ItemSize.Height - labelSize.Height);
            case ContentAlignment.BottomRight: return new(ItemSize.Width - labelSize.Width, ItemSize.Height - labelSize.Height);
            case ContentAlignment.MiddleCenter: return new(ItemSize.Width / 2 - labelSize.Width / 2, ItemSize.Height / 2 - labelSize.Height / 2);
            case ContentAlignment.MiddleLeft: return new(0, ItemSize.Height / 2 - labelSize.Height / 2);
            case ContentAlignment.MiddleRight: return new(ItemSize.Width - labelSize.Width, ItemSize.Height / 2 - labelSize.Height / 2);
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
    public int ItemIndex = -1;
}