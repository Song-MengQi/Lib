namespace Lib
{
    /// <summary>
    /// SerialQueueBase
    /// 可执行队列基类
    /// 处理的最小粒度是Runnable
    /// </summary>
    public abstract class RunnableQueueBase : IRunnableQueue
    {
        public bool IsRunning { get; protected set; }
        //protected bool runFlag;
        protected RunnableQueueBase()
        {
            IsRunning = false;
            //runFlag = true;
        }
        public abstract bool IsEmpty { get; }
        public abstract void Clear();
        public abstract void Assign(IRunnable runnable);
        public abstract void Run();
        //public virtual void Pause()
        //{
        //    runFlag = false;
        //}

        ////同步执行一个任务，并返回是否可能还有下一个任务
        //protected abstract bool RunOne();
        //获取下一个任务
        protected abstract bool GetNext(out IRunnable runnable);
    }
}