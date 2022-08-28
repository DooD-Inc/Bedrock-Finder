using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BedrockFinder.BedrockFinderAPI;
public class CPUBedrockSearcher : BedrockSearcher
{
    public CPUBedrockSearcher(BedrockSearch parent) : base(parent)
    {
    }
    public override void Start()
    {
        new Thread(() =>
        {
            Working = true;
            CanStart = false;
            Queue = GetQueue().Select(z => Parent.TurnedPattern[z.y].blockList.Where(x => x.block == z.block).Select(x => (x.x, z.y, x.z, z.block))).Aggregate((a, b) => a.Concat(b)).ToList();
            for (int x = Parent.Progress.X; x < Parent.Range.CEnd.X; x++)
            {
                Parallel.For((int)Parent.Range.CStart.Z, (int)Parent.Range.CEnd.Z, MultiThreading.ParallelOptions, z => CalculateChunk(x, z));
                Parent.Progress.X++;
                Parent.InvokeUpdateProgress(Parent.Progress.GetPercent());
                if (!Working)
                {
                    CanStart = true;
                    return;
                }
            }
        }).Start();
    }
    private void CalculateChunk(in int x, in int z)
    {
        int bX = x << 4, bZ = z << 4;
        for (int incX = 0; incX < 16; incX++)
            for (int incZ = 0; incZ < 16; incZ++)
            {
                int exX = bX + incX,
                    exZ = bZ + incZ;
                foreach ((int bx, byte y, int bz, BlockType block) in Queue)
                {
                    int sx = exX + bx, sz = exZ + bz;
                    if (!Equals(block, Program.Gen.GetBlock(sx, y, sz, Program.Gen.GetChunk(sx >> 4, sz >> 4))))
                        goto NextBlock;
                }
                Vec2i found = new Vec2i(Parent.Vector.CurrentPoint.x ? exX : (exX + Parent.TurnedPattern.SizeX - 1), Parent.Vector.CurrentPoint.y ? exZ : (exZ + Parent.TurnedPattern.SizeZ - 1));
                lock (@lock)
                {
                    Parent.Result.Add(found);
                    Parent.InvokeFound(found);
                }
            NextBlock: { }
            }
    }
    public MultiThreading MultiThreading = new MultiThreading(Environment.ProcessorCount);
    private List<(int bx, byte y, int bz, BlockType block)> Queue;
    private bool Equals(BlockType block, bool isBedrock) => block == BlockType.Bedrock && isBedrock || block == BlockType.Stone && !isBedrock;
    private List<(byte y, BlockType block)> GetQueue()
    {
        List<(byte y, BlockType block)> queue = new List<(byte y, BlockType block)>();
        if (Parent.TurnedPattern.ExistedFloors.Any(z => z == 1) && Parent.TurnedPattern[1].blockList.Any(z => z.block == BlockType.Stone)) queue.Add((1, BlockType.Stone));
        if (Parent.TurnedPattern.ExistedFloors.Any(z => z == 4) && Parent.TurnedPattern[4].blockList.Any(z => z.block == BlockType.Bedrock)) queue.Add((4, BlockType.Bedrock));
        if (Parent.TurnedPattern.ExistedFloors.Any(z => z == 2) && Parent.TurnedPattern[2].blockList.Any(z => z.block == BlockType.Stone)) queue.Add((2, BlockType.Stone));
        if (Parent.TurnedPattern.ExistedFloors.Any(z => z == 3) && Parent.TurnedPattern[3].blockList.Any(z => z.block == BlockType.Bedrock)) queue.Add((3, BlockType.Bedrock));
        if (Parent.TurnedPattern.ExistedFloors.Any(z => z == 3) && Parent.TurnedPattern[3].blockList.Any(z => z.block == BlockType.Stone)) queue.Add((3, BlockType.Stone));
        if (Parent.TurnedPattern.ExistedFloors.Any(z => z == 2) && Parent.TurnedPattern[2].blockList.Any(z => z.block == BlockType.Bedrock)) queue.Add((2, BlockType.Bedrock));
        if (Parent.TurnedPattern.ExistedFloors.Any(z => z == 4) && Parent.TurnedPattern[4].blockList.Any(z => z.block == BlockType.Stone)) queue.Add((4, BlockType.Stone));
        if (Parent.TurnedPattern.ExistedFloors.Any(z => z == 1) && Parent.TurnedPattern[1].blockList.Any(z => z.block == BlockType.Bedrock)) queue.Add((1, BlockType.Bedrock));
        return queue;
    }
}