using System.Collections;
using System.Collections.Generic;

namespace Lib
{
    public static class QueueExtend
    {
        public static bool IsEmpty(this Queue queue) { return queue.Count == 0; }
        public static bool TryPeek(this Queue queue, out object result)
        {
            result = default(object);
            if (queue.IsEmpty()) return false;
            result = queue.Peek();
            return true;
        }
        public static bool TryDequeue(this Queue queue, out object result)
        {
            result = default(object);
            if (queue.IsEmpty()) return false;
            result = queue.Dequeue();
            return true;
        }

        public static bool IsEmpty<T>(this Queue<T> queue) { return queue.Count == 0; }
        public static bool TryPeek<T>(this Queue<T> queue, out T result)
        {
            result = default(T);
            if (queue.IsEmpty()) return false;
            result = queue.Peek();
            return true;
        }
        public static bool TryDequeue<T>(this Queue<T> queue, out T result)
        {
            result = default(T);
            if (queue.IsEmpty()) return false;
            result = queue.Dequeue();
            return true;
        }
    }
}