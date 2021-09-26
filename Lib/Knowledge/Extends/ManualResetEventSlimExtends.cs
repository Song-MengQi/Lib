using System.Threading;

namespace Lib
{
    public static class ManualResetEventSlimExtends
    {
        public static void Set(ManualResetEventSlim manualResetEventSlim)
        {
            if (default(ManualResetEventSlim) != manualResetEventSlim) manualResetEventSlim.Set();
            //即使已经Dispose，Set也不会异常
        }
        public static void Reset(ManualResetEventSlim manualResetEventSlim)
        {
            if (default(ManualResetEventSlim) != manualResetEventSlim) manualResetEventSlim.Reset();
        }
    }
}