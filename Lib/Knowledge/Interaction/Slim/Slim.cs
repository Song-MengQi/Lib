using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Lib
{
    public class Slim : ISlim, IDisposable
    {
        private readonly ILockable waitLockable = new Lockable();
        private readonly ILockable arrivalLockable = new Lockable();
        private readonly HashSet<ManualResetEventSlim> waitHashSet = new HashSet<ManualResetEventSlim>();
        private readonly ManualResetEventSlim shockSlim = new ManualResetEventSlim(true);
        #region Dispose
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                shockSlim.Dispose();
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
        //自旋SetDIBytes信号量
        private void SlimShock()
        {
            if (waitHashSet.Any(manualResetEventSlim => manualResetEventSlim.IsSet)) shockSlim.Reset();//只要存在线程正在验收结果，就不能SetDI
            else shockSlim.Set();//可以SetDI
        }
        //告诉所有等待的线程，新数据来了
        private void Shock()
        {
            waitLockable.Invoke(()=>{
                foreach (ManualResetEventSlim manualResetEventSlim in waitHashSet)
                {
                    manualResetEventSlim.Set();
                }
                SlimShock();
            });
        }
        public void Arrival(Action<ManualResetEventSlim> shockWaitAction, Action dispatchAction = default(Action))
        {
            ActionExtends.Invoke(shockWaitAction, shockSlim);
            arrivalLockable.Invoke(()=>{
                ActionExtends.Invoke(dispatchAction);
                Shock();
            });
        }
        public void Add(ManualResetEventSlim manualResetEventSlim)
        {
            arrivalLockable.Invoke(()=>{
                manualResetEventSlim.Reset();
                waitHashSet.Add(manualResetEventSlim);
                SlimShock();
            });
        }
        public void Remove(ManualResetEventSlim manualResetEventSlim)
        {
            arrivalLockable.Invoke(()=>{
                waitHashSet.Remove(manualResetEventSlim);
                manualResetEventSlim.Dispose();
                SlimShock();
            });
        }
        #region 检查不应该在锁里
        public bool Check(Func<bool> checkFunc, ManualResetEventSlim manualResetEventSlim)
        {
            return arrivalLockable.Invoke(()=>{
                bool result = checkFunc();
                if (result)
                {
                    waitHashSet.Remove(manualResetEventSlim);
                    manualResetEventSlim.Dispose();
                }
                else
                {
                    manualResetEventSlim.Reset();
                    waitHashSet.Add(manualResetEventSlim);
                }
                SlimShock();
                return result;
            });
        }
        #endregion
    }
}