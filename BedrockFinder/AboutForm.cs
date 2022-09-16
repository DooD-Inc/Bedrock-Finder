using BedrockFinder.Libraries;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BedrockFinder;
public partial class AboutForm : Form
{
    #region Hood
    public void MouseDownRelocate(object sender, MouseEventArgs e)
    {
        if (e.Button.Equals(MouseButtons.Left))
        {
            ((Control)sender).Capture = false;
            var m = Message.Create(Handle, 0xa1, new IntPtr(0x2), IntPtr.Zero);
            WndProc(ref m);
        }
    }
    #endregion
    public AboutForm()
    {
        InitializeComponent();
        Icon = Icon.ExtractAssociatedIcon(@".\Resources\AppIcon.ico");
        VersionL.Text = $"Version: {Program.ProgramVersion}";
        this.Round(15);
        AboutBedrockFinderP.Round(15);
        ContributionsP.Round(15);
        FactsP.Round(15);
        CloseB.Round(10);
        AboutBedrockFinderPanelL.Round(15, true, true, false, false);
        ContributionsPanelL.Round(15, true, true, false, false);
        FactsPanelL.Round(15, true, true, false, false);
        MouseDown += MouseDownRelocate;
        ControlHelper.GetControls(this).ToList().ForEach(x => x.MouseDown += MouseDownRelocate);
        FactsL.Text = @"1. BedrockFinder on GPU work better when Z coord is large X.
2. 1.13 Overworld 50% coords is fake, it bug made by coolmann24 ;(
3. Idea of Bedrock Finder with GPU launched at the end of 2020, but
then I don't have enough C# knowledge.
4. On AMD GPU Bedrock Finder work better.
5. The C++ version is very unoptimized, except for the fact that 
coolmann24 was able to make the table cache for java a random func.
6. This BedrockFinder work better that C++ version
7. Zoom function was deleted duel to WinForms can't make form 
bigger than monitor
(Author has 1280x1080, but need on 150pixel more)
Cry about it.";
    }
    private void OpenLink(string url) => Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
    private void GithubLL_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) => OpenLink("https://github.com/DooD-Inc/Bedrock-Finder");
    private void AuthorGithubLL_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) => OpenLink("https://github.com/MrYotic");
    private void AmplifierLL_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) => OpenLink("https://github.com/deepakkumar1984/Amplifier.NET");
    private void SubstrateLL_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) => OpenLink("https://github.com/minecraft-dotnet/Substrate");
}
