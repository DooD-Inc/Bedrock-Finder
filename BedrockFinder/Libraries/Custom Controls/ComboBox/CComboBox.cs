using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
namespace BedrockFinder.Libraries;
public partial class CComboBox : UserControl
{
    public delegate void IndexChangeHandler(int index);
    public event IndexChangeHandler? IndexChange;
    public delegate void OpenedHandler();
    public event OpenedHandler? Opened;
    public List<string> Collection = new List<string>();
    private int hoveringIndex = -1;
    private bool open;
    private int itemIndex = -1;
    private Graphics g;
    public CComboBox()
    {
        SuspendLayout();
        g = CreateGraphics();

        Paint += (s, e) =>
        {
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
            if (open)
            {
                if (e.Y > ItemSize.Height)
                {
                    ItemIndex = (e.Y - ItemSize.Height) / TextRenderer.MeasureText("l", Font).Height;
                    IndexChange?.Invoke(ItemIndex);
                    Size = ItemSize;
                    Invalidate();
                }
                else Size = ItemSize;
            }
            else
            {
                Opened?.Invoke();
                ((Control)s).BringToFront();
                Size = new Size(ItemSize.Width, ItemSize.Height + Collection.Count * TextRenderer.MeasureText("l", Font).Height);
                Invalidate();
            }
            this.Round(10);
            open = !open;
            g = CreateGraphics();
        };
        
        MouseMove += (s, e) =>
        {
            if (open)
            {
                int index = (e.Y - ItemSize.Height) / TextRenderer.MeasureText("l", Font).Height;
                if (index != -1 && e.Y - ItemSize.Height >= 0 && index < Collection.Count)
                {
                    if (index != hoveringIndex)
                    {
                        if(hoveringIndex != -1)
                        {
                            g.FillRectangle(new SolidBrush(BackColor), new Rectangle(new Point(0, ItemSize.Height + hoveringIndex * TextRenderer.MeasureText("l", Font).Height), new Size(ItemSize.Width, TextRenderer.MeasureText("l", Font).Height)));
                            g.DrawString(Collection[hoveringIndex], Font, new SolidBrush(ForeColor), new Point(0, ItemSize.Height + TextRenderer.MeasureText("l", Font).Height * hoveringIndex));
                        }
                        hoveringIndex = index;
                        g.FillRectangle(new SolidBrush(Color.FromArgb(BackColor.R + 3, BackColor.G + 3, BackColor.B + 3)), new Rectangle(new Point(0, ItemSize.Height + index * TextRenderer.MeasureText("l", Font).Height), new Size(ItemSize.Width, TextRenderer.MeasureText("l", Font).Height)));
                        g.DrawString(Collection[index], Font, new SolidBrush(ForeColor), new Point(0, ItemSize.Height + TextRenderer.MeasureText("l", Font).Height * index));
                    }
                }
                else
                {
                    if(hoveringIndex != -1)
                    {
                        g.FillRectangle(new SolidBrush(BackColor), new Rectangle(new Point(0, ItemSize.Height + hoveringIndex * TextRenderer.MeasureText("l", Font).Height), new Size(ItemSize.Width, TextRenderer.MeasureText("l", Font).Height)));
                        if (Collection.Count > hoveringIndex)
                            g.DrawString(Collection[hoveringIndex], Font, new SolidBrush(ForeColor), new Point(0, ItemSize.Height + TextRenderer.MeasureText("l", Font).Height * hoveringIndex));
                        hoveringIndex = -1;
                    }
                }
            }
        };

        MouseLeave += (s, e) =>
        {
            if(hoveringIndex != -1)
            {
                g.FillRectangle(new SolidBrush(BackColor), new Rectangle(new Point(0, ItemSize.Height + hoveringIndex * TextRenderer.MeasureText("l", Font).Height), new Size(ItemSize.Width, TextRenderer.MeasureText("l", Font).Height)));
                if(Collection.Count > hoveringIndex)
                    g.DrawString(Collection[hoveringIndex], Font, new SolidBrush(ForeColor), new Point(0, ItemSize.Height + TextRenderer.MeasureText("l", Font).Height * hoveringIndex));
                hoveringIndex = -1;
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
    public Size ItemSize { get; set; } = new Size(245, 28);
    [Category("Appearance")]
    public int ItemIndex { get => itemIndex; set {
            itemIndex = value;
            Invalidate();
        }
    }
}