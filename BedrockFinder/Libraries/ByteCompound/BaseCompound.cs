using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteCompound;
public abstract class BaseCompound
{
    public abstract Compound Serialize();
    public abstract void Deserialize(Compound compound);
    public enum BaseType : byte
    {
        Byte = 0,
        SByte = 1,
        Short = 2,
        UShort = 3,
        Int = 4,
        UInt = 5,
        Long = 6,
        ULong = 7,
        Sequence = 8,
        Compound = 9,
    }
    public static Dictionary<BaseType, int> TypeSizes = new Dictionary<BaseType, int>() 
    {
        { BaseType.Byte, 1},
        { BaseType.SByte, 1},
        { BaseType.Short, 2},
        { BaseType.UShort, 2},
        { BaseType.Int, 4},
        { BaseType.UInt, 4},
        { BaseType.Long, 8},
        { BaseType.ULong, 8},
    };
    public static Dictionary<Type, BaseType> BaseTypesByType = new Dictionary<Type, BaseType>()
    {
        { typeof(byte), BaseType.Byte},
        { typeof(sbyte), BaseType.SByte},
        { typeof(short), BaseType.Short},
        { typeof(ushort), BaseType.UShort},
        { typeof(int), BaseType.Int},
        { typeof(uint), BaseType.UInt},
        { typeof(long), BaseType.Long},
        { typeof(ulong), BaseType.ULong},
    };
    public static Dictionary<BaseType, Type> TypesByBaseType = new Dictionary<BaseType, Type>()
    {
        { BaseType.Byte, typeof(byte)},
        { BaseType.SByte, typeof(sbyte)},
        { BaseType.Short, typeof(short)},
        { BaseType.UShort, typeof(ushort)},
        { BaseType.Int, typeof(int)},
        { BaseType.UInt, typeof(uint)},
        { BaseType.Long, typeof(long)},
        { BaseType.ULong, typeof(ulong)},
    };
    public static List<BaseType> BaseTypes = new List<BaseType>()
    {
        BaseType.Byte,
        BaseType.SByte,
        BaseType.Short,
        BaseType.UShort,
        BaseType.Int,
        BaseType.UInt,
        BaseType.Long,
        BaseType.ULong,
        BaseType.Sequence,
        BaseType.Compound,
    };
    public static new List<Type> DecimalTypes = new List<Type>()
    {
        typeof(byte),
        typeof(sbyte),
        typeof(short),
        typeof(ushort),
        typeof(int),
        typeof(uint),
        typeof(long),
        typeof(ulong),
    };
    public static List<string> SequenceEncoding = new List<string>()
    {
        "UTF-16",
        "UTF-16BE",
        "UTF-32",
        "UTF-32BE",
        "US-ASCII",
        "ISO-8859-1",
        "UTF-8",
    };
    public static Dictionary<string, int> EncodingSize = new Dictionary<string, int>()
    {
        { "UTF-16", 2},
        { "UTF-16BE", 2},
        { "UTF-32", 4},
        { "UTF-32BE", 4},
        { "US-ASCII", 1},
        { "ISO-8859-1", 1},
        { "UTF-8", 1}
    };
    public static Encoding[] Encodings = Encoding.GetEncodings().Select(z => z.GetEncoding()).ToArray();
}