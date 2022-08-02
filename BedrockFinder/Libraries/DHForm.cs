using System.Reflection;

namespace BedrockFinder.Libraries;
public class DHForm : Form
{
    public void MouseDownRelocate(object sender, MouseEventArgs e)
    {
        if (e.Button.Equals(MouseButtons.Left))
        {
            ((Control)sender).Capture = false;
            var m = Message.Create(Program.FormHandle, 0xa1, new IntPtr(0x2), IntPtr.Zero);
            WndProc(ref m);            
        }
    }
    public void Instance()
    {
        TransparencyKey = Color.Lime;
        AllowTransparency = true;
        MouseDown += MouseDownRelocate;
        ControlHelper.GetControls(this).Where(z => !z.Name.Contains("NoRelocate")).ToList().ForEach(x => x.MouseDown += MouseDownRelocate);
    }
}