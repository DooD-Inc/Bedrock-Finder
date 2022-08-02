using System.Collections;
using System.Diagnostics;
using static Newtonsoft.Json.JsonConvert;
public class ProgressSave
{
    public ProgressSave() { }
    public ProgressSave(BedrockSearch searcher)
    {
        Range = searcher.Range;
        Progress = searcher.Progress;
        Result = searcher.Result;
        Pattern = searcher.Pattern;
        Vector = searcher.Vector;
    }
    public string Path;
    public SearchRange Range;
    public SearchProgress Progress;
    public List<Vec2i> Result;
    public BedrockPattern Pattern;
    public VectorAngle Vector;
    public int DeviceIndex = 0, ContextIndex = 0, VersionIndex = 0;
    public void Save() => Save(Path);
    public void Save(string path)
    {
        DataManager data = new DataManager();
        #region Range
        data.WriteLong(Range.Start.X);
        data.WriteLong(Range.Start.Z);
        data.WriteLong(Range.End.X);
        data.WriteLong(Range.End.Z);
        #endregion
        #region Progress
        data.WriteInt(Progress.StartX);
        data.WriteInt(Progress.EndX);
        data.WriteInt(Progress.X);
        data.WriteLong(Progress.ElapsedTime.Ticks);
        #endregion
        #region Result
        data.WriteInt(Result.Count);
        foreach(Vec2i result in Result)
        {
            data.WriteInt(result.X);
            data.WriteInt(result.Z);
        }
        #endregion
        #region Pattern
        bool[] bits = new bool[8192]; //32 * 32 * 4 * 2
        for (byte y = 0; y < 4; y++)
            for (int z = 0; z < 32; z++)
                for (int x = 0; x < 32; x++)
                    switch ((byte)Pattern[(byte)(y + 1)][z, x])
                    {
                        case 1:
                            bits[y * 2048 + z * 64 + x * 2] = true;
                            break;
                        case 2:
                            bits[y * 2048 + z * 64 + x * 2 + 1] = true;
                            break;
                    }
        data.WriteBits(bits);
        #endregion
        data.WriteByte((byte)Vector.angle);
        #region Indexes
        data.WriteByte((byte)DeviceIndex);
        data.WriteByte((byte)ContextIndex);
        data.WriteByte((byte)VersionIndex);
        #endregion
        if (!File.Exists(path))
            File.Create(path).Dispose();
        File.WriteAllBytes(path, data.ToBytes());
    }
    public static ProgressSave Load(string path)
    {
        ProgressSave save = new ProgressSave();
        DataManager data = new DataManager(File.ReadAllBytes(path));
        save.Range = new SearchRange(new Vec2l(data.ReadLong(), data.ReadLong()), new Vec2l(data.ReadLong(), data.ReadLong()));
        save.Progress = new SearchProgress(data.ReadInt(), data.ReadInt()) { X = data.ReadInt(), ElapsedTime = TimeSpan.FromTicks(data.ReadLong()) };
        #region Result
        save.Result = new List<Vec2i>();
        int count = data.ReadInt();
        for (int i = 0; i < count; i++)
            save.Result.Add(new Vec2i(data.ReadInt(), data.ReadInt()));
        #endregion
        #region Pattern
        bool[] bits = data.ReadBits(8192);
        save.Pattern = new BedrockPattern(32, 32, 1, 2, 3, 4);
        for (byte y = 0; y < 4; y++)
            for (int z = 0; z < 32; z++)
                for (int x = 0; x < 32; x++)
                {
                    bool f = bits[y * 2048 + z * 64 + x * 2];
                    bool s = bits[y * 2048 + z * 64 + x * 2 + 1];
                    if (f && !s) save.Pattern[(byte)(y + 1)][z, x] = BlockType.Bedrock;
                    else if (!f && s) save.Pattern[(byte)(y + 1)][z, x] = BlockType.Stone;
                    else save.Pattern[(byte)(y + 1)][z, x] = BlockType.None;
                }
        #endregion
        save.Vector = new VectorAngle() { angle = data.ReadByte() };
        #region Indexes
        save.DeviceIndex = data.ReadByte();
        save.ContextIndex = data.ReadByte();
        save.VersionIndex = data.ReadByte();
        #endregion
        return save;
    }
    public class DataManager
    {
        public DataManager()
        {
            Bits = new List<bool>();
        }
        public DataManager(byte[] bytes)
        {
            Bits = BytesToBits(bytes).ToList();
        }
        public List<bool> Bits { get; set; }
        public int Cur { get; private set; } = 0;
        public void WriteLong(long num) => Bits.AddRange(ToBits(num));
        public void WriteInt(int num) => Bits.AddRange(ToBits(num));
        public void WriteBits(bool[] bits) => Bits.AddRange(bits);
        public void WriteByte(byte @byte) => Bits.AddRange(ToBits(@byte).Take(8));
        public long ReadLong()
        {
            long num = BitConverter.ToInt64(BitsToBytes(Bits.Skip(Cur).Take(64).ToArray()), 0);
            Cur += 64;
            return num;
        }
        public int ReadInt()
        {
            int num = BitConverter.ToInt32(BitsToBytes(Bits.Skip(Cur).Take(32).ToArray()), 0);
            Cur += 32;
            return num;
        }
        public bool[] ReadBits(int count)
        {
            bool[] bits = Bits.Skip(Cur).Take(count).ToArray();
            Cur += count;
            return bits;
        }
        public byte ReadByte()
        {
            byte @byte = BitsToByte(Bits.Skip(Cur).Take(8).ToArray());
            Cur += 8;
            return @byte;
        }
        public byte[] ToBytes() => BitsToBytes(Bits.ToArray());
        private static byte[] ToBytes(dynamic value) => BitConverter.GetBytes(value);
        private static bool[] ToBits(dynamic value) => BytesToBits(ToBytes(value));
        private static byte BitsToByte(bool[] bits) => BitsToBytes(bits)[0];
        private static bool[] BytesToBits(byte[] bytes)
        {
            BitArray bitArr = new BitArray(bytes);
            bool[] result = new bool[bitArr.Length];
            bitArr.CopyTo(result, 0);
            return result;
        }
        private static byte[] BitsToBytes(params bool[] bits)
        {
            BitArray bitArr = new BitArray(bits);
            byte[] bytes = new byte[bits.Length / 8 + (bits.Length % 8 == 0 ? 0 : 1)];
            bitArr.CopyTo(bytes, 0);
            return bytes;
        }
    }
}