using System;
using System.Threading;

namespace Lib
{
    public interface ISlim
    {
        //信号到来
        void Arrival(Action<ManualResetEventSlim> shockWaitAction, Action dispatchAction = default(Action));
        //重置信号，若此信号不在等待集合里，则添加
        void Add(ManualResetEventSlim manualResetEventSlim);
        //删除一个信号
        void Remove(ManualResetEventSlim manualResetEventSlim);
        bool Check(Func<bool> checkFunc, ManualResetEventSlim manualResetEventSlim);
    }
}