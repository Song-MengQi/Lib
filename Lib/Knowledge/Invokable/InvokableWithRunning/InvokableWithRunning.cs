using System;

namespace Lib
{
    //1、并非所有情况都需要IsRunning
    //2、两个Action之间存在间隙，可能导致不准
    public class InvokableWithRunning : IInvokableWithRunning
    {
        public bool IsRunning { get; private set; }
        public InvokableWithRunning() : base()
        {
            IsRunning = false;
        }
        public virtual void Invoke(Action action)
        {
            IsRunning = true;
            ActionExtends.Invoke(action);
            IsRunning = false;
        }
        public T Invoke<T>(Func<T> func)
        {
            T t = default(T);
            Invoke(()=>{
                t = FuncExtends.Invoke(func);
            });
            return t;
        }
    }
}