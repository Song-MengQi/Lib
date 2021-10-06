using System;
using System.Threading.Tasks;

namespace Lib
{
    public interface IPrioritySerializable
    {
        bool IsRunning { get; }
        bool IsEmpty { get; }
        void Clear();
        void InvokeBackground(Action action, int priority = 0);
        Task InvokeAsync(Action action, int priority = 0);
        void Invoke(Action action, int priority = 0);
        Task<T> InvokeAsync<T>(Func<T> func, int priority = 0);
        T Invoke<T>(Func<T> func, int priority = 0);
    }
}