using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Lib
{
    public class PriorityQueue<T> : IEnumerable<T>, System.Collections.ICollection
    {
        private readonly int priorityNum;
        public readonly Queue<T>[] queues;
        public PriorityQueue(int numOfPriority = 1)
        {
            priorityNum = numOfPriority;
            queues = ArrayExtends.GetArray(priorityNum, () => new Queue<T>());

            SyncRoot = new object();
        }
        private IEnumerable<T> Enumerable { get { return IEnumerableExtends.Concat(queues); } }
        #region IEnumerable
        IEnumerator IEnumerable.GetEnumerator() { return GetEnumerator(); }
        public IEnumerator<T> GetEnumerator() { return Enumerable.GetEnumerator(); }
        #endregion
        #region System.Collections.ICollection
        public object SyncRoot { get; private set; }
        public bool IsSynchronized { get { return false; } }
        public void CopyTo(Array array, int index = 0) { Enumerable.ToArray().CopyTo(array, index); }
        public void CopyTo(T[] array, int arrayIndex = 0) { Enumerable.ToArray().CopyTo(array, arrayIndex); }
        #endregion
        public int Count { get { return queues.Sum(queue => queue.Count); } }
        public void Clear() { queues.Foreach(queue => queue.Clear()); }
        public bool Contains(T item) { return queues.Any(queue => queue.Contains(item)); }
        public void Enqueue(T item, int priority)
        {
            if (priority < 0 || priority >= priorityNum) return;
            queues[priority].Enqueue(item);
        }
        public void Enqueue(T item) { Enqueue(item, 0); }
        //为空时，Peek、Dequeue的异常跟First一样，都是InvalidOperationException
        public T Dequeue() { return queues.First(q => false == q.IsEmpty()).Dequeue(); }
        public T Peek() { return queues.First(q => false == q.IsEmpty()).Peek(); }
        public bool IsEmpty { get { return queues.All(queue => queue.IsEmpty()); } }
        public bool TryPeek(out T result)
        {
            if (IsEmpty)
            {
                result = default(T);
                return false;
            }
            result = Peek();
            return true;
        }
        public bool TryDequeue(out T result)
        {
            if (IsEmpty)
            {
                result = default(T);
                return false;
            }
            result = Dequeue();
            return true;
        }
    }
}