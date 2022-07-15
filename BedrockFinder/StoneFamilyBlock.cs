using FastBitmapUtils;

namespace BedrockFinder;
public static class StoneFamilyBlock
{
    private static Color[] bedrockColor = new Color[4] { Color.FromArgb(151, 151, 151), Color.FromArgb(87, 87, 87), Color.FromArgb(51, 51, 51), Color.FromArgb(7, 7, 7) };
    private static Color[] stoneColor = new Color[4] { Color.FromArgb(143, 143, 143), Color.FromArgb(127, 127, 127), Color.FromArgb(161, 161, 161), Color.FromArgb(106, 106, 106) };
    private static byte[,] signatureBlock = new byte[16, 16]
    {
        { 1, 2, 2, 2, 2, 1, 0, 0, 3, 0, 1, 2, 2, 2, 2, 1},
        { 1, 1, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 3, 1, 1, 2},
        { 1, 3, 2, 2, 3, 2, 2, 2, 0, 2, 1, 1, 1, 0, 1, 1},
        { 1, 0, 1, 1, 1, 3, 1, 0, 1, 1, 2, 2, 2, 2, 2, 1},
        { 1, 0, 0, 2, 2, 2, 2, 2, 2, 2, 0, 0, 0, 0, 0, 3},
        { 2, 2, 1, 1, 1, 2, 2, 2, 1, 3, 1, 1, 2, 2, 3, 1},
        { 0, 0, 1, 1, 1, 2, 0, 0, 1, 1, 1, 1, 0, 0, 0, 3},
        { 1, 1, 1, 2, 2, 2, 2, 2, 2, 3, 2, 2, 2, 2, 1, 1},
        { 1, 0, 0, 3, 0, 2, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0},
        { 1, 2, 2, 2, 2, 2, 2, 1, 3, 1, 1, 2, 2, 2, 0, 1},
        { 1, 1, 0, 2, 2, 0, 0, 2, 3, 2, 0, 0, 0, 0, 0, 0},
        { 3, 1, 1, 1, 2, 1, 1, 1, 0, 0, 1, 1, 1, 0, 0, 3},
        { 1, 2, 2, 2, 2, 2, 2, 2, 0, 0, 2, 2, 2, 2, 2, 1},
        { 1, 0, 2, 0, 3, 1, 1, 2, 2, 2, 3, 2, 1, 1, 0, 0},
        { 1, 1, 1, 2, 2 ,2, 2, 2, 1, 1, 0, 0, 1, 2, 2, 1},
        { 2, 2, 2, 2, 3, 0, 0, 1, 1, 1, 1, 2, 2, 2, 1, 1}
    };
    public static Bitmap DrawBedrockBlock() => DrawBlock(bedrockColor);
    public static Bitmap DrawStoneBlock() => DrawBlock(stoneColor);
    public static Bitmap DrawBedrockPen() => DrawPen(bedrockColor);
    public static Bitmap DrawStonePen() => DrawPen(stoneColor);
    public static void DrawBlockOnBitmap(ref Bitmap input, Point start, BlockType block)
    {
        FastBitmap bitmap = new FastBitmap(input);
        Color[] colors = block == BlockType.Bedrock ? bedrockColor : stoneColor;
        for (int x = 0; x < 16; x++)
            for (int y = 0; y < 16; y++)
                bitmap.SetPixel(start.X + x, start.Y + y, colors[signatureBlock[y, x]]);
        input = bitmap.GetResult();
    }
    public static Bitmap DrawBlock(BlockType block) => block == BlockType.Bedrock ? DrawBedrockBlock() : DrawStoneBlock();
    private static Bitmap DrawBlock(Color[] colors)
    {
        FastBitmap bitmap = new FastBitmap(new Bitmap(16, 16));
        for (int x = 0; x < 16; x++)
            for (int y = 0; y < 16; y++)
                bitmap.SetPixel(x, y, colors[signatureBlock[y, x]]);
        return bitmap.GetResult();
    }
    private static Bitmap DrawPen(Color[] colors)
    {
        FastBitmap bitmap = new FastBitmap(new Bitmap(32, 32));
        for (int x = 0; x < 32; x += 2)
            for (int y = 0; y < 32; y += 2)
            {
                Color color = colors[signatureBlock[y / 2, x / 2]];
                bitmap.SetPixel(x + 1, y, color);
                bitmap.SetPixel(x + 1, y + 1, color);
                bitmap.SetPixel(x, y + 1, color);
                bitmap.SetPixel(x, y, color);
            }
        return bitmap.GetResult();
    }
}