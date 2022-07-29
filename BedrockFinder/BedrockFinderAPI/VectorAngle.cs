public class VectorAngle
{
    public int angle = 0;
    public void Turn(int diffAngle)
    {
        if (diffAngle == 1) angle += 45;
        else if (diffAngle == 2) angle += 90;
        else if (diffAngle == 3) angle += 135;
        else if (diffAngle == 45) angle += 45;
        else if (diffAngle == 90) angle += 90;
        else if (diffAngle == 135) angle += 135;
        else if (diffAngle == -1) angle -= 45;
        else if (diffAngle == -2) angle -= 90;
        else if (diffAngle == -3) angle -= 135;
        else if (diffAngle == -45) angle -= 45;
        else if (diffAngle == -90) angle -= 90;
        else if (diffAngle == -135) angle -= 135;
        angle = (angle < 0 ? 180 - Math.Abs(angle) : angle) % 180;
    }
    public (bool x, bool y) CurrentPoint => Points[angle];
    public static Dictionary<int, (bool x, bool y)> Points = new Dictionary<int, (bool x, bool y)>()
    {
        { 0, (true, true) },
        { 45, (false, true) },
        { 90, (false, false)},
        { 135, (true, false) },
    };
    public (int x, int z) Translate(int x, int z, int maxX, int maxZ)
    {
        (bool x, bool z) point = CurrentPoint;
        if (point == (true, true))
            return (z, x);
        if (point == (false, true))
            return (maxX - x, z);
        if (point == (false, false))
            return (maxX - x, maxZ - z);
        return (x, maxZ - z);
    }
    public override string ToString() => (Points[angle].x ? '+' : '-') + " " + (Points[angle].y ? '+' : '-');
}