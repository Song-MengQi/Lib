using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Lib
{
    public static class GCExtends
    {
        internal static class NativeMethods
        {
            [DllImport("kernel32.dll")]
            internal static extern bool SetProcessWorkingSetSize(IntPtr proc, IntPtr min, IntPtr max);//CA1901
        }
        public static void Collect()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                NativeMethods.SetProcessWorkingSetSize(Process.GetCurrentProcess().Handle, new IntPtr(-1), new IntPtr(-1));
            }
        }
    }
}