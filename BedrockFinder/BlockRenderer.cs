using FastBitmapUtils;

namespace BedrockFinder;
public static class BlockRenderer
{
    private static Color[] bedrockColor = new Color[4] { Color.FromArgb(151, 151, 151), Color.FromArgb(87, 87, 87), Color.FromArgb(51, 51, 51), Color.FromArgb(7, 7, 7) };
    private static Color[] stoneColor = new Color[4] { Color.FromArgb(143, 143, 143), Color.FromArgb(127, 127, 127), Color.FromArgb(161, 161, 161), Color.FromArgb(106, 106, 106) };
    private static Color[] netherrackColor = new Color[] { Color.FromArgb(10, 10, 10), Color.FromArgb(20, 10, 10), Color.FromArgb(23, 9, 9), Color.FromArgb(25, 9, 9), Color.FromArgb(23, 10, 10), Color.FromArgb(27, 9, 9), Color.FromArgb(28, 9, 9), Color.FromArgb(29, 10, 10), Color.FromArgb(33, 9, 9), Color.FromArgb(38, 9, 9), Color.FromArgb(45, 8, 8), Color.FromArgb(36, 14, 14), Color.FromArgb(50, 8, 8), Color.FromArgb(55, 8, 8), Color.FromArgb(41, 17, 17), Color.FromArgb(60, 8, 8), Color.FromArgb(40, 19, 19), Color.FromArgb(64, 7, 7), Color.FromArgb(41, 19, 19), Color.FromArgb(43, 18, 18), Color.FromArgb(69, 7, 7), Color.FromArgb(70, 7, 7), Color.FromArgb(47, 20, 20), Color.FromArgb(47, 21, 21), Color.FromArgb(79, 7, 7), Color.FromArgb(49, 25, 25), Color.FromArgb(50, 25, 25), Color.FromArgb(89, 6, 6), Color.FromArgb(90, 6, 6), Color.FromArgb(94, 6, 6), Color.FromArgb(96, 6, 6), Color.FromArgb(56, 26, 26), Color.FromArgb(55, 28, 28), Color.FromArgb(99, 7, 7), Color.FromArgb(56, 29, 29), Color.FromArgb(57, 29, 29), Color.FromArgb(60, 28, 28), Color.FromArgb(103, 8, 8), Color.FromArgb(104, 8, 8), Color.FromArgb(63, 30, 30), Color.FromArgb(67, 32, 32), Color.FromArgb(68, 32, 32), Color.FromArgb(114, 10, 10), Color.FromArgb(117, 11, 11), Color.FromArgb(69, 37, 37), Color.FromArgb(93, 30, 22), Color.FromArgb(73, 36, 36), Color.FromArgb(70, 38, 38), Color.FromArgb(123, 12, 12), Color.FromArgb(75, 36, 36), Color.FromArgb(71, 38, 38), Color.FromArgb(124, 12, 12), Color.FromArgb(77, 37, 37), Color.FromArgb(126, 13, 13), Color.FromArgb(78, 39, 39), Color.FromArgb(131, 13, 13), Color.FromArgb(80, 40, 40), Color.FromArgb(81, 40, 40), Color.FromArgb(82, 40, 40), Color.FromArgb(135, 15, 15), Color.FromArgb(137, 15, 15), Color.FromArgb(138, 15, 15), Color.FromArgb(84, 46, 46), Color.FromArgb(145, 17, 17), Color.FromArgb(91, 46, 46), Color.FromArgb(91, 50, 50), Color.FromArgb(109, 47, 35), Color.FromArgb(96, 48, 48), Color.FromArgb(154, 19, 19), Color.FromArgb(93, 52, 52), Color.FromArgb(98, 50, 50), Color.FromArgb(99, 50, 50), Color.FromArgb(95, 54, 54), Color.FromArgb(101, 52, 52), Color.FromArgb(97, 55, 55), Color.FromArgb(98, 55, 55), Color.FromArgb(104, 53, 53), Color.FromArgb(100, 56, 56), Color.FromArgb(103, 58, 58), Color.FromArgb(108, 56, 56), Color.FromArgb(112, 58, 58), Color.FromArgb(107, 61, 61), Color.FromArgb(113, 58, 58), Color.FromArgb(115, 60, 60), Color.FromArgb(116, 61, 61), Color.FromArgb(120, 63, 63), Color.FromArgb(122, 64, 64), Color.FromArgb(124, 65, 65), Color.FromArgb(119, 68, 68), Color.FromArgb(126, 66, 66), Color.FromArgb(131, 69, 69), Color.FromArgb(129, 74, 74), Color.FromArgb(136, 72, 72), Color.FromArgb(131, 76, 76), Color.FromArgb(141, 80, 62), Color.FromArgb(134, 78, 78), Color.FromArgb(144, 82, 64), Color.FromArgb(136, 79, 79), Color.FromArgb(146, 78, 78), Color.FromArgb(149, 87, 68), Color.FromArgb(141, 82, 82), Color.FromArgb(143, 84, 84), Color.FromArgb(151, 81, 81), Color.FromArgb(146, 86, 86), Color.FromArgb(154, 83, 83), Color.FromArgb(149, 88, 88), Color.FromArgb(159, 85, 85), Color.FromArgb(158, 97, 75), Color.FromArgb(164, 88, 88), Color.FromArgb(166, 89, 89), Color.FromArgb(158, 93, 93), Color.FromArgb(160, 94, 94), Color.FromArgb(169, 92, 92), Color.FromArgb(170, 92, 92), Color.FromArgb(172, 92, 92), Color.FromArgb(168, 107, 83), Color.FromArgb(170, 109, 85), Color.FromArgb(168, 99, 99), Color.FromArgb(169, 99, 99), Color.FromArgb(173, 102, 102), Color.FromArgb(175, 114, 89), Color.FromArgb(175, 103, 103), Color.FromArgb(176, 103, 103), Color.FromArgb(178, 105, 105), Color.FromArgb(182, 107, 107), Color.FromArgb(184, 109, 109), Color.FromArgb(188, 111, 111), Color.FromArgb(191, 130, 102), Color.FromArgb(194, 115, 115), Color.FromArgb(194, 134, 105), Color.FromArgb(201, 119, 119), Color.FromArgb(202, 120, 120), Color.FromArgb(211, 125, 125), Color.FromArgb(217, 130, 130), Color.FromArgb(222, 162, 127), Color.FromArgb(225, 165, 129), Color.FromArgb(229, 170, 134) };
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
    private static byte[,] signatureNetherrackBlock = new byte[16, 16]
    {
        { 128, 26, 25, 72, 26, 85, 28, 134, 63, 13, 19, 72, 69, 100, 118, 128, },
        { 34, 22, 87, 94, 15, 42, 28, 133, 17, 27, 1, 53, 60, 15, 70, 112, },
        { 36, 92, 28, 83, 54, 54, 132, 0, 26, 97, 69, 116, 125, 72, 66, 54, },
        { 31, 105, 110, 97, 126, 75, 56, 23, 28, 73, 99, 41, 54, 14, 38, 84, },
        { 96, 38, 28, 43, 12, 6, 72, 50, 103, 97, 103, 117, 35, 28, 28, 109, },
        { 46, 120, 123, 128, 14, 86, 127, 57, 26, 122, 91, 98, 14, 89, 103, 128, },
        { 120, 15, 68, 5, 83, 83, 90, 82, 10, 37, 133, 102, 49, 4, 28, 55, },
        { 108, 54, 78, 44, 110, 97, 136, 124, 74, 77, 125, 72, 26, 11, 54, 54, },
        { 15, 15, 6, 28, 83, 83, 21, 109, 40, 58, 26, 8, 120, 29, 55, 54, },
        { 14, 27, 72, 78, 97, 109, 109, 107, 54, 26, 97, 101, 111, 128, 128, 58, },
        { 3, 79, 113, 6, 6, 2, 32, 120, 128, 6, 33, 101, 81, 55, 54, 83, },
        { 45, 29, 51, 14, 67, 83, 30, 55, 106, 64, 79, 128, 114, 52, 7, 129, },
        { 39, 121, 130, 26, 95, 97, 59, 61, 62, 72, 72, 72, 72, 16, 97, 104, },
        { 93, 9, 71, 14, 119, 115, 128, 72, 18, 83, 80, 94, 2, 97, 20, 109, },
        { 109, 14, 93, 109, 15, 48, 54, 1, 97, 97, 101, 128, 47, 83, 109, 109, },
        { 109, 76, 131, 128, 72, 54, 89, 80, 83, 28, 24, 135, 88, 65, 128, 128, },
    };
    public static Bitmap DrawBlock(Bitmap input, Point start, BlockType block, VectorAngle angle, int zoom = 1)
    {
        FastBitmap bitmap = new FastBitmap(input);
        Color[] colors = block == BlockType.Bedrock ? bedrockColor : Program.ContextIndex != (int)WorldContext.Overworld ? netherrackColor : stoneColor;
        byte[,] signature = block == BlockType.Bedrock ? signatureBlock : Program.ContextIndex != (int)WorldContext.Overworld ? signatureNetherrackBlock : signatureBlock;
        for(int x = 0; x < 16; x++)
            for(int y = 0; y < 16; y++)
                DrawPixel(start.X + x, start.Y + y, GetColor(x, y));
        void DrawPixel(int x, int y, Color color)
        {
            if(zoom == 1)
                bitmap.SetPixel(x, y, color);
            else
            {
                x *= zoom;
                y *= zoom;
                for(int px = 0; px < zoom; px++)
                    for(int py = 0; py < zoom; py++)
                        bitmap.SetPixel(x + px, y + py, color);
            }
        }
        Color GetColor(int x, int y)
        {
            if (angle.CurrentPoint == (true, false))
                return colors[signature[y, x]];
            if (angle.CurrentPoint == (true, true))
                return colors[signature[x, y]];
            if (angle.CurrentPoint == (false, true))
                return colors[signature[15 - y, 15 - x]];
            return colors[signature[15 - x, 15 - y]];
        }
        return bitmap.GetResult();
    }
    public static Bitmap DrawBlock(Point start, BlockType block, VectorAngle angle, int zoom = 1) => DrawBlock(new Bitmap(zoom * 16, zoom * 16), start, block, angle, zoom);
}