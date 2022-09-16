using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Amplifier
{
    public static class Crutch
    {
        public static List<IntPtr> Allocated = new List<IntPtr>();
        public static void Free()
        {
            foreach (IntPtr addr in Allocated)
            {
                try
                {
                    GCHandle.FromIntPtr(addr).Free();
                }
                catch { }
            }
        }
    }
}