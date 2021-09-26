//using System;
//using System.Threading.Tasks;

////废弃，因为并不能保证串行，没有意义。
//namespace Lib
//{
//    public interface IInvokable
//    {
//        bool IsRunning { get; }
//        void Invoke(Action action);
//        Task InvokeAsync(Action action);
//        void InvokeBackground(Action action);
//        T Invoke<T>(Func<T> func);
//        Task<T> InvokeAsync<T>(Func<T> func);
//    }
//}