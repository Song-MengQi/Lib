using System.Threading.Tasks;

namespace Lib
{
    /// <summary>
    /// RunnableTask
    /// 实现IRunnable，封装了Task
    /// 我认为Task使用起来和Action的不同在于
    /// Task可以Wait，可以等待执行结果
    /// </summary>
    public class RunnableTask : IRunnable
    {
        private readonly Task task;
        public RunnableTask(Task task)
        {
            this.task = task;
        }
        public void Run() { task.RunSynchronously(); }
    }
}
