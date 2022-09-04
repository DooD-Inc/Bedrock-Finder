using Amplifier;
using Amplifier.OpenCL;
using BedrockFinder.BedrockFinderAPI.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BedrockFinder.BedrockFinderAPI.GPU;
public class KernelBedrockSearcher : BedrockSearcher
{
    public KernelBedrockSearcher(BedrockSearch parent) : base(parent) { }
    private OpenCLCompiler compiler = new OpenCLCompiler();
    private byte[] founds;
    public override void Start()
    {
        new Thread(() =>
        {
            Working = true;
            CanStart = false;
            compiler.UseDevice(Program.DeviceIndex - 1);
            compiler.CompileKernel(typeof(Kernels.v12.OW));
            UpdateQueue();
            for (int x = Parent.Progress.X; x < Parent.Range.CEnd.X; x++)
            {
                founds = Enumerable.Repeat((byte)0, (int)Parent.Range.ZCSize).ToArray();
                compiler.Execute("CalculateChunk", founds, x, (int)Parent.Range.CStart.Z, kernelQBlock.Length, kernelQBX, kernelQY, kernelQBZ, kernelQBlock, ChunkСache.OW_12_A, ChunkСache.OW_12_B);
                Parent.Progress.X++;
                Parent.InvokeUpdateProgress(Parent.Progress.GetPercent());
                founds.Select((z, i) => (z, i)).Where(z => z.z == 1).ToList().ForEach(z =>
                {
                    int fX = x << 4;
                    int fZ = (int)Parent.Range.CStart.Z + z.i << 4;
                    Vec2i found = new Vec2i(Parent.Vector.CurrentPoint.x ? fX : fX + Parent.TurnedPattern.SizeX - 1, Parent.Vector.CurrentPoint.y ? fZ : fZ + Parent.TurnedPattern.SizeZ - 1);
                    Parent.Result.Add(found);
                    Parent.InvokeFound(found);
                });
                if (!Working)
                {
                    CanStart = true;
                    return;
                }
            }
            CanStart = true;
        }).Start();
    }
    public void UpdateQueue()
    {
        Queue = GetQueue().Select(z => Parent.TurnedPattern[z.y].blockList.Where(x => x.block == BlockType.Stone && !z.block || x.block == BlockType.Bedrock && z.block).Select(x => ((byte)x.x, (byte)z.y, (byte)x.z, z.block))).Aggregate((a, b) => a.Concat(b)).ToList();
        kernelQBX = Queue.Select(z => z.bx).ToArray();
        kernelQY = Queue.Select(z => z.y).ToArray();
        kernelQBZ = Queue.Select(z => z.bz).ToArray();
        kernelQBlock = Queue.Select(z => (byte)(z.block ? 1 : 0)).ToArray();
    }
    private List<(byte bx, byte y, byte bz, bool block)> Queue;
    private byte[] kernelQBX;
    private byte[] kernelQY;
    private byte[] kernelQBZ;
    private byte[] kernelQBlock;
    private List<(byte y, bool block)> GetQueue()
    {
        List<(byte y, bool block)> queue = new List<(byte y, bool block)>();
        if (Parent.TurnedPattern.ExistedFloors.Any(z => z == 1) && Parent.TurnedPattern[1].blockList.Any(z => z.block == BlockType.Stone)) queue.Add((1, false));
        if (Parent.TurnedPattern.ExistedFloors.Any(z => z == 4) && Parent.TurnedPattern[4].blockList.Any(z => z.block == BlockType.Bedrock)) queue.Add((4, true));
        if (Parent.TurnedPattern.ExistedFloors.Any(z => z == 2) && Parent.TurnedPattern[2].blockList.Any(z => z.block == BlockType.Stone)) queue.Add((2, false));
        if (Parent.TurnedPattern.ExistedFloors.Any(z => z == 3) && Parent.TurnedPattern[3].blockList.Any(z => z.block == BlockType.Bedrock)) queue.Add((3, true));
        if (Parent.TurnedPattern.ExistedFloors.Any(z => z == 3) && Parent.TurnedPattern[3].blockList.Any(z => z.block == BlockType.Stone)) queue.Add((3, false));
        if (Parent.TurnedPattern.ExistedFloors.Any(z => z == 2) && Parent.TurnedPattern[2].blockList.Any(z => z.block == BlockType.Bedrock)) queue.Add((2, true));
        if (Parent.TurnedPattern.ExistedFloors.Any(z => z == 4) && Parent.TurnedPattern[4].blockList.Any(z => z.block == BlockType.Stone)) queue.Add((4, false));
        if (Parent.TurnedPattern.ExistedFloors.Any(z => z == 1) && Parent.TurnedPattern[1].blockList.Any(z => z.block == BlockType.Bedrock)) queue.Add((1, true));
        return queue;
    }
}