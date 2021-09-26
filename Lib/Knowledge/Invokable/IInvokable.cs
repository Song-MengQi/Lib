using System;

namespace Lib
{
    public interface IInvokable
    {
        void Invoke(Action action);
        T Invoke<T>(Func<T> func);
    }
}