using System.Collections.Concurrent;

namespace Lib
{
    public sealed class SerialQueue : SerialQueueBase
    {
        private readonly ConcurrentQueue<IRunnable> queue = new ConcurrentQueue<IRunnable>();
        public override bool IsEmpty { get { return false == IsRunning && queue.IsEmpty; } }
        public override void Clear() { queue.Clear(); }
        public override void Assign(IRunnable runnable)
        {
            if (default(IRunnable) == runnable) return;
            queue.Enqueue(runnable);
        }
        //protected override bool RunOne()
        //{
        //    IRunnable runnable;
        //    if (false == queue.TryDequeue(out runnable)) return false;
        //    TryExtends.Try(runnable.Run);
        //    return true;
        //}
        protected override bool GetNext(out IRunnable runnable)
        {
            return queue.TryDequeue(out runnable);
        }
    }
}