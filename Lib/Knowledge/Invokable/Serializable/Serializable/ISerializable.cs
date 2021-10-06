using System;
using System.Threading.Tasks;

namespace Lib
{
    public interface ISerializable : IInvokableWithRunning
    {
        //bool IsRunning { get; }
        bool IsEmpty { get; }
        void Clear();
        //void Invoke(Action action);
        Task InvokeAsync(Action action);
        void InvokeBackground(Action action);
        //T Invoke<T>(Func<T> func);
        Task<T> InvokeAsync<T>(Func<T> func);
    }
}