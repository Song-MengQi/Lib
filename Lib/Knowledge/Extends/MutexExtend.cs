using System;
using System.Threading;

namespace Lib
{
    public static class MutexExtend
    {
        private static bool InvokeOrAbandoned(Func<bool> func)
        {
            try { return func(); }
            catch (AbandonedMutexException) { return true; }
        }
        public static bool WaitOneOrAbandoned(this Mutex mutex)
        {
            return InvokeOrAbandoned(mutex.WaitOne);
        }
        public static bool WaitOneOrAbandoned(this Mutex mutex, int millisecondsTimeout)
        {
            return InvokeOrAbandoned(()=>mutex.WaitOne(millisecondsTimeout));
        }
        public static bool WaitOneOrAbandoned(this Mutex mutex, TimeSpan timeout)
        {
            return InvokeOrAbandoned(()=>mutex.WaitOne(timeout));
        }
    }
}