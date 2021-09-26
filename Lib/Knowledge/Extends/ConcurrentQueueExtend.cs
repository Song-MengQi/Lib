using System.Collections.Concurrent;

namespace Lib
{
    public static class ConcurrentQueueExtend
    {
        public static void Clear<T>(this ConcurrentQueue<T> queue)
        {
            T t;
            while (queue.TryDequeue(out t)) ;
        }
    }
}
