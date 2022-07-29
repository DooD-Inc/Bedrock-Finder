using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using static ByteCompound.BaseCompound;

namespace ByteCompound;
public class Compound
{
    public Compound(params (BaseType type, dynamic value)[] args)
    {
        Values = args;
    }
    public int Cur = 0;
    public (BaseType type, dynamic value)[] Values;
    public dynamic Next => Values[Cur++].value;
    public static byte[] ToBytes(Compound compound)
    {
        List<byte> bytes = new List<byte>();
        compound.Values.ToList().ForEach(z =>
        {
            byte typeIndex = (byte)z.type;
            if (z.type == BaseType.Sequence)
            {
                bytes.Add(typeIndex);
                string value = z.value;
                bytes.Add((byte)GetIndexOfOptimalEncoding(value));
                bytes.AddRange(BitConverter.GetBytes((ushort)value.Length));
                bytes.AddRange(GetOptimalEncoding(value).GetBytes(value));
            }
            else if (z.type == BaseType.Compound)
            {
                bytes.Add(typeIndex);
                byte[] byteValue = Compound.ToBytes(((BaseCompound)z.value).Serialize());
                uint size = (uint)byteValue.Length;
                bytes.AddRange(BitConverter.GetBytes(size));
                bytes.AddRange(byteValue);
            }
            else if (typeIndex < 8)
            {
                Type optimalType = CutDecimalType(z.value);
                BaseType optimalBaseType = BaseTypesByType[optimalType];
                byte optimalTypeIndex = (byte)optimalBaseType;
                if (optimalBaseType == BaseType.Byte)
                {
                    bytes.Add(optimalTypeIndex);
                    bytes.Add((byte)z.value);
                }
                else if (optimalBaseType == BaseType.SByte)
                {
                    bytes.Add(optimalTypeIndex);
                    bytes.Add((byte)(z.value + 128));
                }
                else
                {
                    bytes.Add((byte)BaseTypesByType[optimalType]);
                    bytes.AddRange(BitConverter.GetBytes(Convert.ChangeType(z.value, optimalType)));
                }
            }
        });
        return bytes.ToArray();
    }
    public static Compound ToCompound(byte[] bytes)
    {
        List<(BaseType type, dynamic value)> values = new List<(BaseType type, dynamic value)>();
        int cur = 0;
        while (cur < bytes.Length)
        {
            BaseType type = BaseTypes[bytes[cur++]];
            if ((byte)type < 8)
            {
                int size = TypeSizes[type];
                dynamic value = ConvertBytes(type, bytes.Skip(cur).Take(size).ToArray());
                cur += size;
                values.Add((type, value));
            }
            else if((byte)type == 8)
            {
                Encoding encoding = Encodings[bytes[cur++]];
                ushort length = BitConverter.ToUInt16(bytes.Skip(cur).Take(2).ToArray());                
                cur += 2;
                int size = length * EncodingSize[encoding.EncodingName];
                string str = encoding.GetString(bytes.Skip(cur).Take(size).ToArray());
                cur += size;
                values.Add((type, str));
            }
            else if((byte)type == 9)
            {
                uint size = BitConverter.ToUInt32(bytes.Skip(cur).Take(4).ToArray());
                cur += 4;
                Compound compound = Compound.ToCompound(bytes.Skip(cur).Take(4).ToArray());
                cur += (int)size;
                values.Add((type, compound));
            }
        }
        return new Compound() { Values = values.ToArray() };
    }
    private static dynamic ConvertBytes(BaseType type, byte[] bytes)
    {
        if (type == BaseType.Byte)
            return bytes[0];
        if (type == BaseType.SByte)
            return bytes[0] - 128;
        if (type == BaseType.Short)
            return BitConverter.ToInt16(bytes);
        if (type == BaseType.UShort)
            return BitConverter.ToUInt16(bytes);
        if (type == BaseType.Int)
            return BitConverter.ToInt32(bytes);
        if (type == BaseType.UInt)
            return BitConverter.ToUInt32(bytes);
        if (type == BaseType.Long)
            return BitConverter.ToInt64(bytes);
        if (type == BaseType.ULong)
            return BitConverter.ToUInt64(bytes);
        return 0;
    }
    private int SizeOf(BaseType type, dynamic value = null)
    {
        if(TypeSizes.ContainsKey(type))
            return TypeSizes[type];
        if (type == BaseType.Sequence || value != null)
            return GetOptimalEncoding((string)value).GetBytes((string)value).Length;
        return 0;
    }
    private static Encoding GetOptimalEncoding(string str) => Encoding.GetEncodings()
        .Select(info => info.GetEncoding())
        .Select(enc => new { Encoding = enc, Bytes = enc.GetBytes(str)})
        .Where(x => x.Encoding.GetString(x.Bytes) == str)
        .MinBy(x => x.Bytes.Length).Encoding;
    private static int GetIndexOfOptimalEncoding(string str) => SequenceEncoding.IndexOf(GetOptimalEncoding(str).EncodingName);
    private static Type CutDecimalType(dynamic value) => DecimalTypes.Where(type => Convert.ToDecimal(type.GetField("MinValue").GetValue(null)) <= value && Convert.ToDecimal(type.GetField("MaxValue").GetValue(null)) >= value).First();
}