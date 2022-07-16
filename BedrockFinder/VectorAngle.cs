using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BedrockFinder;
public class VectorAngle
{
    private byte step = 1;
    public void Turn(int count) => step = (byte)Math.Abs((step + count) % 4);
    public (bool x, bool y) GetVector() => angles[step];
    private Dictionary<byte, (bool x, bool y)> angles = new Dictionary<byte, (bool x, bool y)>()
    {
        { 0, (true, false) },
        { 1, (true, true) },
        { 2, (false, true) },
        { 3, (false, false)}
    };
    public override string ToString() => (angles[step].x ? '+' : '-') + " " + (angles[step].y ? '+' : '-');
}