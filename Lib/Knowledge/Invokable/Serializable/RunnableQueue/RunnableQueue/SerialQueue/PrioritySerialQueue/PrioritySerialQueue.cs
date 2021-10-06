using System.Collections.Concurrent;
using System.Linq;

namespace Lib
{
    public sealed class PrioritySerialQueue : SerialQueueBase
    {
        private readonly int priorityNum;
        private readonly ConcurrentQueue<IRunnable>[] queues;
        public PrioritySerialQueue(int numOfPriority = 1) : base()
        {
            priorityNum = numOfPriority;
            queues = ArrayExtends.GetArray(priorityNum, () => new ConcurrentQueue<IRunnable>());
        }
        public override bool IsEmpty { get { return false == IsRunning && queues.All(queue => queue.IsEmpty); } }
        public override void Clear() { queues.Foreach(queue => queue.Clear()); }
        public void Assign(IRunnable runnable, int priority)
        {
            if (default(IRunnable) == runnable) return;
            if (priority < 0 || priority >= priorityNum) return;
            queues[priority].Enqueue(runnable);
        }

        public override void Assign(IRunnable runnable)
        {
            //默认为优先级最高的
            Assign(runnable, 0);
        }
        //protected override bool RunOne()
        //{
        //    foreach (var queue in queues)
        //    {
        //        IRunnable runnable;
        //        if (queue.TryDequeue(out runnable))
        //        {
        //            TryExtends.Try(runnable.Run);
        //            return true;
        //        }
        //    }
        //    return false;
        //}
        protected override bool GetNext(out IRunnable runnable)
        {
            foreach (var queue in queues)
            {
                if (queue.TryDequeue(out runnable)) return true;
            }
            runnable = default(IRunnable);
            return false;
        }
    }
}