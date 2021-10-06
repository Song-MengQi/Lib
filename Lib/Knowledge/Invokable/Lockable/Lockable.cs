using System;

namespace Lib
{
    public class Lockable : ILockable
    {
        public void Invoke(Action action)
        {
            lock (this)
            {
                ActionExtends.Invoke(action);
            }
        }
        public T Invoke<T>(Func<T> func)
        {
            lock (this)
            {
                return FuncExtends.Invoke(func);
            }
        }
    }
}