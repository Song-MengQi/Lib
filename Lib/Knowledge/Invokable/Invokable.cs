using System;

namespace Lib
{
    public class Invokable : IInvokable
    {
        public void Invoke(Action action)
        {
            ActionExtends.Invoke(action);
        }
        public T Invoke<T>(Func<T> func)
        {
            return FuncExtends.Invoke(func);
        }
    }
}