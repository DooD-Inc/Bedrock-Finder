using BedrockFinder.Libraries;
using FastBitmapUtils;
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
public partial class CanvasForm : Form
{    
    public void MouseDownRelocate(object sender, MouseEventArgs e)
    {
        if (e.Button.Equals(MouseButtons.Left))
        {
            ((Control)sender).Capture = false;
            var m = Message.Create(Handle, 0xa1, new IntPtr(0x2), IntPtr.Zero);
            WndProc(ref m);   
        }
    }
    public CanvasForm()
    {
        InitializeComponent();
        MouseDown += MouseDownRelocate;
        DrawGrid();
        DrawVectors();
        DrawPointers();
    }
    private void DrawGrid()
    {
        FastBitmap bitmap = new FastBitmap(new Bitmap(574, 574));
        for (int c = 0; c < 32; c++)
        {
            for (int i = 0; i < 544; i++)
            {
                bitmap.SetPixel(c * 17 + 30, i, Color.Black);
                bitmap.SetPixel(i + 30, c * 17, Color.Black);
            }
        }
        for (int i = 0; i < 544; i++)
        {
            bitmap.SetPixel(574, i, Color.Black);
            bitmap.SetPixel(0, i, Color.FromArgb(30, 30, 30));
            bitmap.SetPixel(i + 30, 544, Color.Black);
            bitmap.SetPixel(i + 30, 573, Color.FromArgb(30, 30, 30));
        }
        for (int i = 0; i < 30; i++)
        {
            bitmap.SetPixel(i, 0, Color.FromArgb(30, 30, 30));
            bitmap.SetPixel(0, 573 - i, Color.FromArgb(30, 30, 30));
            bitmap.SetPixel(i, 573, Color.FromArgb(30, 30, 30));
        }

        BackgroundImage = bitmap.GetResult();
    }
    private void DrawVectors()
    {
        FastBitmap bitmap = new FastBitmap((Bitmap)BackgroundImage);
        for (int i = 5; i < 544; i++)
        {
            bitmap.SetPixel(i + 25, 573, Color.FromArgb(30, 30, 30));
            bitmap.SetPixel(i + 25, 548, Color.FromArgb(30, 30, 30));
        }
        for (int i = 5; i < 544; i++)
        {
            bitmap.SetPixel(25, i, Color.FromArgb(30, 30, 30));
            bitmap.SetPixel(i + 25, 548, Color.FromArgb(30, 30, 30));
        }
        BackgroundImage = bitmap.GetResult();
    }
    public void DrawPointers()
    {
        FastBitmap bitmap = new FastBitmap((Bitmap)BackgroundImage);
        (bool x, bool y) points = Vector.CurrentPoint;

        DrawPlus(bitmap, 43, 550, Color.FromArgb(43, 43, 43));
        if (points.x) DrawPlus(bitmap, 43, 550, Color.Silver);
        else DrawMinus(bitmap, 43, 550, Color.Silver);

        DrawPlus(bitmap, 14, 523, Color.FromArgb(43, 43, 43));
        if (points.y) DrawPlus(bitmap, 14, 523, Color.Silver);
        else DrawMinus(bitmap, 14, 523, Color.Silver);

        BackgroundImage = bitmap.GetResult();
    }
    private void DrawPlus(FastBitmap b, int x, int y, Color p)
    {
        for(int i = 0; i < 9; i++)
        {
            b.SetPixel(x + 4, y + i, p);
            b.SetPixel(x + i, y + 4, p);
        }
    }
    private void DrawMinus(FastBitmap b, int x, int y, Color p)
    {
        for (int i = 0; i < 9; i++)
            b.SetPixel(x + i, y + 4, p);
    }
    private void CanvasForm_Paint(object sender, PaintEventArgs e)
    {
        
    }
    public VectorAngle Vector = new VectorAngle();
    public BlockType PenType = BlockType.Bedrock;
    public byte YLevel = 4;
    public void DrawBlock(int xc, int yc, BlockType block)
    {
        if(block == BlockType.None)
        {            
            FastBitmap bitmap = new FastBitmap((Bitmap)BackgroundImage);
            for (int x = 0; x < 16; x++)
                for (int y = 0; y < 16; y++)
                    bitmap.SetPixel(30 + xc * 17 + x + 1, yc * 17 + y + 1, Color.FromArgb(43, 43, 43));
            BackgroundImage = bitmap.GetResult();
        }
        else
        {
            Bitmap bitmap = (Bitmap)BackgroundImage;
            StoneFamilyBlock.DrawVectorBlock(ref bitmap, new Point(30 + xc * 17 + 1, yc * 17 + 1), block, Vector);
            BackgroundImage = bitmap;
        }

        Invalidate();
    }
    private void CanvasForm_MouseClick(object sender, MouseEventArgs e)
    {
        if (!e.Button.Equals(MouseButtons.Right)) return;
        if (!(e.Location.X > 30 && e.Location.Y < 543)) return;
        Point panelIndex = new Point((e.Location.X - 30) / 17, (e.Location.Y) / 17);
        Point patternIndex = new Point((e.Location.X - 30) / 17, 31 - (e.Location.Y) / 17);
        BlockType block = Program.Pattern[YLevel][patternIndex.X, patternIndex.Y];
        if (block != PenType)
        {
            Program.Pattern[YLevel][patternIndex.X, patternIndex.Y] = PenType;
            DrawBlock(panelIndex.X, panelIndex.Y, PenType);
        }
        else
        {
            Program.Pattern[YLevel][patternIndex.X, patternIndex.Y] = BlockType.None;
            DrawBlock(panelIndex.X, panelIndex.Y, BlockType.None);
        }
        Program.MainWindow.Invoke(() => Program.MainWindow.UpdatePatternScore());
    }
    public void UnDraw() => Program.Pattern[YLevel].blockList.ForEach(z => DrawBlock(z.x, 31 - z.z, BlockType.None));
    public void OverDraw() => Program.Pattern[YLevel].blockList.ForEach(z => DrawBlock(z.x, 31 - z.z, z.block));
}
