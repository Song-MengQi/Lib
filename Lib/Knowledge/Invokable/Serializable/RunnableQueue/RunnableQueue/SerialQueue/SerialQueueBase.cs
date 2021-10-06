using System.Threading.Tasks;

namespace Lib
{
    public abstract class SerialQueueBase : RunnableQueueBase
    {
        //public override void Run()
        //{
        //    if (IsRunning) return;
        //    lock (this) {
        //        if (IsRunning) return;
        //        IsRunning = true;
        //    }
        //    Task.Run(() => {
        //        while (RunOne()) ;
        //        //runFlag = true;
        //        //while (runFlag && RunOne()) ;
        //        IsRunning = false;
        //    });
        //}
        private bool GetNextForRun(out IRunnable runnable)
        {
            lock (this) {
                bool result = GetNext(out runnable);
                if (false == result) IsRunning = false; 
                return result;
            }
        }
        //保证有且只有一个线程在Run 
        public override void Run()
        {
            lock (this) {
                if (IsRunning) return;
                IsRunning = true;
            }
            Task.Run(() => {
                IRunnable runnable;
                while (GetNextForRun(out runnable)) TryExtends.Try(runnable.Run);
            });
        }
    }
}