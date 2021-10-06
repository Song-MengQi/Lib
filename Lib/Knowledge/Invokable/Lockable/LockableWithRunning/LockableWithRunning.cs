using System;

namespace Lib
{
    public class LockableWithRunning : InvokableWithRunning, ILockableWithRunning
    {
        public override void Invoke(Action action)
        {
            lock (this)
            {
                base.Invoke(action);
            }
        }
    }
}
