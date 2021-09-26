using System.Threading;

namespace Lib
{
    public static class TickExtends
    {
        //private static ILockable lockable = new Lockable();
        //private static ulong tick = 0ul;
        //public static ulong Tick { get { return lockable.Invoke(() => ++tick); } }

        private static long tick = 0L;
        public static ulong Tick { get { return (ulong)Interlocked.Increment(ref tick); } }
    }
}