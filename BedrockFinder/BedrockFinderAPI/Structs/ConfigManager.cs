using Substrate;
using System.Collections;

namespace BedrockFinder.BedrockFinderAPI.Structs;
public class ConfigManager
{
    #region Pattern
    public static BedrockPattern ImportPatternAsBFP(string path) => ConvertBFPToPattern(File.ReadAllBytes(path));
    public static void ExportPatternAsBFP(BedrockPattern pattern, string path) => File.WriteAllBytes(path, ConvertPatternToBFP(pattern));
    public static BedrockPattern? ImportPatternAsWorld(string path)
    {
        string levelPath = Path.Combine(path, "level.dat");
        if (!File.Exists(levelPath))
        {
            MessageBox.Show("Failed to find the world (level.dat) in this folder.");
            return null;
        }
        return ConvertWorldToPattern(AnvilWorld.Open(levelPath));
    }
    public static void ExportPatternAsWorld(BedrockPattern pattern, string path) => CreateWorldByPattern(path, pattern);

    public static byte[] ConvertPatternToBFP(BedrockPattern pattern)
    {
        bool[] bits = new bool[32 * 32 * 4 * 2];
        for (byte y = 0; y < 4; y++)
            for (int z = 0; z < 32; z++)
                for (int x = 0; x < 32; x++)
                    switch ((byte)pattern[(byte)(y + 1)][z, x])
                    {
                        case 1:
                            bits[y * 2048 + z * 64 + x * 2] = true;
                            break;
                        case 2:
                            bits[y * 2048 + z * 64 + x * 2 + 1] = true;
                            break;
                    }
        byte[] bytes = new byte[1024];
        new BitArray(bits).CopyTo(bytes, 0);
        return bytes;
    }
    public static BedrockPattern ConvertBFPToPattern(byte[] bytes)
    {
        BitArray bits = new BitArray(bytes);
        BedrockPattern pattern = new BedrockPattern(32, 32, 1, 2, 3, 4);
        for (byte y = 0; y < 4; y++)
            for (int z = 0; z < 32; z++)
                for (int x = 0; x < 32; x++)
                {
                    bool f = bits[y * 2048 + z * 64 + x * 2];
                    bool s = bits[y * 2048 + z * 64 + x * 2 + 1];
                    if (f && !s) pattern[(byte)(y + 1)][z, x] = BlockType.Bedrock;
                    else if (!f && s) pattern[(byte)(y + 1)][z, x] = BlockType.Stone;
                    else pattern[(byte)(y + 1)][z, x] = BlockType.None;
                }
        return pattern;
    }
    public static void CreateWorldByPattern(string path, BedrockPattern pattern)
    {
        if (!Directory.Exists(path))
            Directory.CreateDirectory(path);
        /*
        if(Directory.GetFiles(path).Length > 0 || Directory.GetDirectories(path).Length > 0)
        {
            MessageBox.Show("This Folder is not Empty!");
            return;
        }
        */
        AnvilWorld world = AnvilWorld.Create(path);
        world.Level.Spawn = new SpawnPoint(16, 5, 16);
        world.Level.GameType = GameType.CREATIVE;
        world.Level.LevelName = path.Split('\\')[^1];
        world.Level.Player = new Player()
        {
            Position = new Vector3(0, 5, 0),
            GameType = PlayerGameType.Creative
        };
        world.Level.UseMapFeatures = false;
        world.Level.Save();
        RegionChunkManager rcm = world.GetChunkManager();
        BlockManager bm = world.GetBlockManager();
        //ChunkRef chunk;
        for (int x = -32; x < 32; x++)
            for (int z = -32; z < 32; z++)
            {
                rcm.CreateChunk(x, z);
                //chunk.IsTerrainPopulated = true; // is shit 👹👹👹👹👹👹👹👹👹👹 | Memory leak enjoyers uncomment it!
            }
        for (byte y = 1; y < 5; y++)
            for (int z = 0; z < 32; z++)
                for (int x = 0; x < 32; x++)
                    switch ((byte)pattern[y][x, z])
                    {
                        case 1:
                            bm.SetID(x, y, z, 7);
                            break;
                        case 2:
                            bm.SetID(x, y, z, 1);
                            break;
                    }
        for (int z = 0; z < 32; z++)
            for (int x = 0; x < 32; x++)
                bm.SetID(x, 0, z, 7);
        world.Save();
        world = null;
        rcm = null;
        bm = null;
    }
    public static BedrockPattern ConvertWorldToPattern(AnvilWorld world)
    {
        BedrockPattern pattern = new BedrockPattern(32, 32, 1, 2, 3, 4);
        BlockManager bm = world.GetBlockManager();
        for (byte y = 1; y < 5; y++)
            for (int z = 0; z < 32; z++)
                for (int x = 0; x < 32; x++)
                    switch ((byte)bm.GetID(x, y, z))
                    {
                        case 0:
                            pattern[y][z, x] = BlockType.None;
                            break;
                        case 7:
                            pattern[y][z, x] = BlockType.Bedrock;
                            break;
                        default:
                            pattern[y][z, x] = BlockType.Stone;
                            break;
                    }
        return pattern;
    }
    #endregion
    #region Progress
    public static void ExportProgressAsBFR(ProgressSave progress, string path) => progress.Save(path);
    public static ProgressSave ImportProgressAsBFR(string path) => ProgressSave.Load(path);
    public static void ExportSearchAsBFR(BedrockSearch search, string path) => ExportProgressAsBFR(new ProgressSave(search), path);
    public static BedrockSearch ImportSearchAsBFR(string path) => new BedrockSearch(ProgressSave.Load(path));
    #endregion
}