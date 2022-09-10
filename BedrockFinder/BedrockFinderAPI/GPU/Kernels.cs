using Amplifier.OpenCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BedrockFinder.BedrockFinderAPI.GPU;
public class Kernels
{
    public class v12
    {
        public class OW : OpenCLFunctions
        {
            [OpenCLKernel]
            public void CalculateChunk([Global] byte[] founds, int x, int minZ, int patternSize, [Global] byte[] patternX, [Global] byte[] patternY, [Global] byte[] patternZ, [Global] byte[] patternBedrock, [Global] long[] a, [Global] long[] b)
            {
                int thread = get_global_id(0);
                int z = minZ + thread;
                int bX = x << 4, bZ = z << 4;
                for (int incX = 0; incX < 16; incX++)
                    for (int incZ = 0; incZ < 16; incZ++)
                    {
                        int exX = bX + incX, exZ = bZ + incZ;
                        founds[thread] = 1;
                        for (int i = 0; i < patternSize; i++)
                        {
                            int sx = exX + patternX[i], sz = exZ + patternZ[i];
                            int cpos = (((sz & 0xF) << 0x4) + (sx & 0xF) << 0x2) + patternY[i];
                            bool block = ((((sx >> 4) * 0x4F9939F508 + (sz >> 4) * 0x1EF1565BD5 ^ 0x5DEECE66D) * a[cpos] + b[cpos] & 0xFFFFFFFFFFFF) >> 0x11) % 0x5 >= patternY[i];
                            if (!(block && patternBedrock[i] == 1 || !block && patternBedrock[i] == 0))
                            {
                                founds[thread] = 0;
                                i = patternSize;
                            }
                        }
                        if (founds[thread] == 1)
                            return;
                    }
            }
        }
    }

    public class v13
    {        
        public class OW : OpenCLFunctions
        {
            [OpenCLKernel]
            public void CalculateChunk([Global] byte[] founds, int x, int minZ, int patternSize, [Global] byte[] patternX, [Global] byte[] patternY, [Global] byte[] patternZ, [Global] byte[] patternBedrock, [Global] long[] c)
            {
                int thread = get_global_id(0);
                int z = minZ + thread;
                int bX = x << 4, bZ = z << 4;
                for (int incX = 0; incX < 16; incX++)
                    for (int incZ = 0; incZ < 16; incZ++)
                    {
                        int exX = bX + incX, exZ = bZ + incZ;
                        founds[thread] = 1;
                        for (int i = 0; i < patternSize; i++)
                        {
                            int sx = exX + patternX[i], sz = exZ + patternZ[i];
                            long cs = (sx >> 4) * 0x4F9939F508 + (sz >> 4) * 0x1EF1565BD5 ^ 0x5DEECE66D;
                            bool block = false;
                            int cpos = ((((sz & 0xF) << 0x4) + (sx & 0xF) << 0x2) + patternY[i]) * 8;
                            for (int ci = 0; ci < 8; ci += 2)
                                block = block || ((cs * c[cpos + ci] + c[cpos + ci + 1] & 0xFFFFFFFFFFFF) >> 0x11) % 0x5 >= patternY[i];
                            if (!(block && patternBedrock[i] == 1 || !block && patternBedrock[i] == 0))
                            {
                                founds[thread] = 0;
                                i = patternSize;
                            }
                        }
                        if (founds[thread] == 1)
                            return;
                    }
            }
        }        
        public class LN : OpenCLFunctions
        {
            /*
            public bool GetBlock(in int x, in byte y, in int z)
            {
                bool found = false;
                long cs = ((x >> 4) * 0x4F9939F508 + (z >> 4) * 0x1EF1565BD5) ^ 0x5DEECE66D;
                foreach ((long a, long b) abobus in LN_13[(((z & 0xF) << 0x4) + (x & 0xF) << 0x2) + y])
                    found = found || (((cs * abobus.a + abobus.b) & 0xFFFFFFFFFFFF) >> 0x11) % 0x5 >= y;
                return found;
            }
            */
        }
        public class HN : OpenCLFunctions
        {
            /*
            public bool GetBlock(in int x, in byte y, in int z)
            {
                bool found = false;
                long cs = ((x >> 4) * 0x4F9939F508 + (z >> 4) * 0x1EF1565BD5) ^ 0x5DEECE66D;
                foreach ((long a, long b) abobus in HN_13[(((z & 0xF) << 0x4) + (x & 0xF) << 0x2) + y])
                    found = found || (((cs * abobus.a + abobus.b) & 0xFFFFFFFFFFFF) >> 0x11) % 0x5 >= y;
                return found;
            }
            */
        }
    }
    public static class v14v15v16v17
    {
        public class OW : OpenCLFunctions
        {
            [OpenCLKernel]
            public void CalculateChunk([Global] byte[] founds, int x, int minZ, int patternSize, [Global] byte[] patternX, [Global] byte[] patternY, [Global] byte[] patternZ, [Global] byte[] patternBedrock, [Global] long[] a, [Global] long[] b)
            {
                int thread = get_global_id(0);
                int z = minZ + thread;
                int bX = x << 4, bZ = z << 4;
                for (int incX = 0; incX < 16; incX++)
                    for (int incZ = 0; incZ < 16; incZ++)
                    {
                        int exX = bX + incX, exZ = bZ + incZ;
                        founds[thread] = 1;
                        for (int i = 0; i < patternSize; i++)
                        {
                            int sx = exX + patternX[i], sz = exZ + patternZ[i];
                            int cpos = (((sz & 0xF) << 0x4) + (sx & 0xF) << 0x2) + patternY[i];
                            bool block = ((((sx >> 4) * 0x4F9939F508 + (sz >> 4) * 0x1EF1565BD5 ^ 0x5DEECE66D) * a[cpos] + b[cpos] & 0xFFFFFFFFFFFF) >> 0x11) % 0x5 >= patternY[i];
                            if (!(block && patternBedrock[i] == 1 || !block && patternBedrock[i] == 0))
                            {
                                founds[thread] = 0;
                                i = patternSize;
                            }
                        }
                        if (founds[thread] == 1)
                            return;
                    }
            }
        }
        public class LN : OpenCLFunctions
        {
            [OpenCLKernel]
            public void CalculateChunk([Global] byte[] founds, int x, int minZ, int patternSize, [Global] byte[] patternX, [Global] byte[] patternY, [Global] byte[] patternZ, [Global] byte[] patternBedrock, [Global] long[] a, [Global] long[] b)
            {
                int thread = get_global_id(0);
                int z = minZ + thread;
                int bX = x << 4, bZ = z << 4;
                for (int incX = 0; incX < 16; incX++)
                    for (int incZ = 0; incZ < 16; incZ++)
                    {
                        int exX = bX + incX, exZ = bZ + incZ;
                        founds[thread] = 1;
                        for (int i = 0; i < patternSize; i++)
                        {
                            int sx = exX + patternX[i], sz = exZ + patternZ[i];
                            int cpos = (((sz & 0xF) << 0x4) + (sx & 0xF) << 0x2) + patternY[i];
                            bool block = ((((sx >> 4) * 0x4F9939F508 + (sz >> 4) * 0x1EF1565BD5 ^ 0x5DEECE66D) * a[cpos] + b[cpos] & 0xFFFFFFFFFFFF) >> 0x11) % 0x5 >= patternY[i];
                            if (!(block && patternBedrock[i] == 1 || !block && patternBedrock[i] == 0))
                            {
                                founds[thread] = 0;
                                i = patternSize;
                            }
                        }
                        if (founds[thread] == 1)
                            return;
                    }
            }
        }
        public class HN : OpenCLFunctions
        {
            [OpenCLKernel]
            public void CalculateChunk([Global] byte[] founds, int x, int minZ, int patternSize, [Global] byte[] patternX, [Global] byte[] patternY, [Global] byte[] patternZ, [Global] byte[] patternBedrock, [Global] long[] a, [Global] long[] b)
            {
                int thread = get_global_id(0);
                int z = minZ + thread;
                int bX = x << 4, bZ = z << 4;
                for (int incX = 0; incX < 16; incX++)
                    for (int incZ = 0; incZ < 16; incZ++)
                    {
                        int exX = bX + incX, exZ = bZ + incZ;
                        founds[thread] = 1;
                        for (int i = 0; i < patternSize; i++)
                        {
                            int sx = exX + patternX[i], sz = exZ + patternZ[i];
                            int cpos = (((sz & 0xF) << 0x4) + (sx & 0xF) << 0x2) + patternY[i];
                            bool block = ((((sx >> 4) * 0x4F9939F508 + (sz >> 4) * 0x1EF1565BD5 ^ 0x5DEECE66D) * a[cpos] + b[cpos] & 0xFFFFFFFFFFFF) >> 0x11) % 0x5 >= patternY[i];
                            if (!(block && patternBedrock[i] == 1 || !block && patternBedrock[i] == 0))
                            {
                                founds[thread] = 0;
                                i = patternSize;
                            }
                        }
                        if (founds[thread] == 1)
                            return;
                    }
            }
        }
    }
}