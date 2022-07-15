using System.Drawing;
using System.Drawing.Imaging;

namespace FastBitmapUtils
{
    public unsafe sealed class FastBitmap 
    {
        private Bitmap bmp;
        private IntPtr ptr;
        private int bytes;
        private BitmapData data;
        private byte* pointer;
        public FastBitmap(Bitmap bitmap)
        {           
            bmp = bitmap;
            data = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadWrite, bmp.PixelFormat);
            ptr = data.Scan0;
            bytes = Math.Abs(data.Stride) * bmp.Height;
            pointer = (byte*)ptr.ToPointer();
        }
        public void SetPixel(int x, int y, Color color) => SetPixel((ushort)x, (ushort)y, color);
        public void SetPixel(ushort x, ushort y, Color color)
        {
            byte* p = (byte*)(pointer + ((y * bmp.Height + x) * 4));
            *p = color.B;
            *(p + 1) = color.G;
            *(p + 2) = color.R;
            *(p + 3) = color.A;
        }
        public Color GetPixel(int x, int y) => GetPixel((ushort)x, (ushort)y);
        public Color GetPixel(ushort x, ushort y)
        {
            byte* p = (byte*)(pointer + ((y * bmp.Height + x) * 4));
            return Color.FromArgb(*(p + 3), *(p + 2), *(p + 1), *p);
        }
        public Bitmap GetResult()
        {
            bmp.UnlockBits(data);
            return bmp;
        }
    }
}