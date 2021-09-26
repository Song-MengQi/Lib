using System;

namespace Lib
{
    /// <summary>
    /// RunnableAction
    /// 实现IRunnable接口，封装了Action
    /// </summary>
    public class RunnableAction : IRunnable
    {
        private readonly Action action;

        public RunnableAction(Action action)
        {
            this.action = action;
        }
        public void Run() { action.Invoke(); }
    }
}
