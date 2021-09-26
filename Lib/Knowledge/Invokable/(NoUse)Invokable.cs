//using System;
//using System.Threading.Tasks;

////废弃，因为并不能保证串行，没有意义。
//namespace Lib
//{
//    public class Invokable : IInvokable
//    {
//        public bool IsRunning { get; private set; }
//        public virtual void Invoke(Action action)
//        {
//            IsRunning = true;
//            ActionExtends.Invoke(action);
//            IsRunning = false;
//        }
//        public T Invoke<T>(Func<T> func)
//        {
//            T t = default(T);
//            Invoke(()=>{
//                t = FuncExtends.Invoke(func);
//            });
//            return t;
//        }
//        public Task InvokeAsync(Action action)
//        {
//            return Task.Run(()=>Invoke(action));
//        }
//        public void InvokeBackground(Action action)
//        {
//            InvokeAsync(action);
//        }
//        public Task<T> InvokeAsync<T>(Func<T> func)
//        {
//            return Task.Run(()=>Invoke(func));
//        }
//    }
//}