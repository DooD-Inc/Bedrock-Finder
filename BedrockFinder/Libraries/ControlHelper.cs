using System.Drawing.Drawing2D;

namespace BedrockFinder.Libraries;
public static class ControlHelper
{    
    public static Point FindMiddle(Control ownControl, Control memControl, bool x, bool y) => new Point(x ? ownControl.Width / 2 - memControl.Width / 2 : memControl.Location.X, y ? ownControl.Height / 2 - memControl.Height / 2 : memControl.Location.Y);
    public static void Round(this Control control, int radius, bool topRight, bool topLeft, bool bottomLeft, bool bottomRight)
    {
        try
        {
            using (var path = new GraphicsPath())
            {
                if (topRight)
                {
                    path.AddLine(radius, 0, control.Width - radius, 0);
                    path.AddArc(control.Width - radius, 0, radius, radius, 270, 90);
                }
                else 
                    path.AddLine(0, 0, control.Width, 0);
                if (bottomRight)
                {
                    path.AddLine(control.Width, radius, control.Width, control.Height - radius);
                    path.AddArc(control.Width - radius, control.Height - radius, radius, radius, 0, 90);
                }
                else
                    path.AddLine(control.Width, 0, control.Width, control.Height);
                if (bottomLeft)
                {
                    path.AddLine(control.Width - radius, control.Height, radius, control.Height);
                    path.AddArc(0, control.Height - radius, radius, radius, 90, 90);
                }
                else
                    path.AddLine(control.Width, control.Height, 0, control.Height);
                if (topLeft)
                {
                    path.AddLine(0, control.Height - radius, 0, radius);
                    path.AddArc(0, 0, radius, radius, 180, 90);
                }
                else
                    path.AddLine(0, control.Height, 0, 0);
                control.Region = new Region(path);
            }
        }
        catch (Exception e) { Console.WriteLine("При прорисовке элемента: " + control.Name + " Произошла ошибка: " + e); }
    }
    public static void DrawBorder(Control control, Color color) => ControlPaint.DrawBorder(control.CreateGraphics(), control.ClientRectangle, color, ButtonBorderStyle.Solid);
    public static IEnumerable<Control> GetControls(Control control, Type[] type)
    {
        var controls = control.Controls.Cast<Control>();
        return controls.Cast<Control>().SelectMany(x => GetControls(x, type)).Concat(controls).Where(c => type.Contains(c.GetType()));
    }
    private static List<Type> types = new List<Type> { typeof(Label), typeof(Panel)};
    public static IEnumerable<Control> GetControls(Control control)
    {
        var controls = control.Controls.Cast<Control>();
        return controls.Cast<Control>().SelectMany(x => GetControls(x)).Concat(controls).Where(c => types.Contains(c.GetType()));
    }
}