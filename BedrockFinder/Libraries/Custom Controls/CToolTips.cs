using System.Data;
using System.Drawing.Drawing2D;

//this class from other project (DH - DooDHack).
public sealed partial class CToolTips : ToolTip
{
    private Dictionary<Control, (string caption, Size size)> AssociatedControls = new Dictionary<Control, (string caption, Size size)>();
    private Font font;
    public Font Font { get => font; set {
        font = value;
        AssociatedControls = AssociatedControls.ToList().Select(z => (z.Key, (z.Value.caption, Graphics.FromImage(new Bitmap(1, 1)).MeasureString(z.Value.caption, Font).ToSize()))).ToDictionary(z => z.Key, z => z.Item2);
    }}
    public CToolTips(Font font)
    {
        this.font = font;
        InitializeComponent();
        OwnerDraw = true;
        UseFading = true;
        UseAnimation = true;
        Draw += OnDraw;
        Popup += OnPopup;
    }
    private void OnPopup(object sender, PopupEventArgs e)
    {
        e.ToolTipSize = AssociatedControls.ContainsKey(e.AssociatedControl) ? AssociatedControls[e.AssociatedControl].size : new Size(200, 100);
    }
    private void OnDraw(object sender, DrawToolTipEventArgs e)
    { 
        Graphics g = e.Graphics;
        LinearGradientBrush b = new LinearGradientBrush(e.Bounds, Color.FromArgb(57, 57, 57), Color.FromArgb(60, 60, 60), 45f);
        e.DrawBackground();
        g.FillRectangle(new SolidBrush(Color.FromArgb(70, 70, 70)), e.Bounds);
        g.DrawRectangle(new Pen(Color.FromArgb(80, 80, 80)), new Rectangle(e.Bounds.X, e.Bounds.X, e.Bounds.Width - 1, e.Bounds.Height - 1));
        string caption = AssociatedControls.ContainsKey(e.AssociatedControl) ? AssociatedControls[e.AssociatedControl].caption : e.ToolTipText;
        g.DrawString(caption, font, Brushes.Silver, new PointF(e.Bounds.X + 1, e.Bounds.Y + 1));
        b.Dispose();
    }
    public void SetDHToolTip(Control control, string text)
    {
        SetToolTip(control, text != "" ? "." : "");
        Size captionSize = Graphics.FromImage(new Bitmap(1, 1)).MeasureString(text, Font).ToSize();
        AssociatedControls[control] = (text, new Size(captionSize.Width, captionSize.Height + 3));
    }
}
