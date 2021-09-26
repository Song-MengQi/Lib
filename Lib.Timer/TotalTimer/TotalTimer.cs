using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lib.Timer
{
    public sealed class TotalTimer : SingletonBase<TotalTimer>, IDisposable
    {
        private readonly System.Threading.Timer timer;
        private readonly ConcurrentDictionary<ulong, TimingAction> repeatActionDic;
        private readonly ConcurrentDictionary<ulong, TimingAction> onceActionDic;
        public TotalTimer()
        {
            repeatActionDic = new ConcurrentDictionary<ulong, TimingAction>();
            onceActionDic = new ConcurrentDictionary<ulong, TimingAction>();
            timer = new System.Threading.Timer(delegate{
                ActRepeats();
                ActOnces();
            }, default(object), TimeSpan.Zero, Config.Instance.PeriodDuration);
        }
        #region Dispose
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #region sealed不用protected virtual
        //protected virtual void Dispose(bool disposing)
        #endregion
        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                timer.Dispose();
            }
        }
        #endregion
        private void ActRepeats()
        {
            TimingAction[] timingActions = repeatActionDic.Values.ToArray();
            if (ArrayExtends.IsNullOrEmpty(timingActions)) return;
            Parallel.ForEach(timingActions, timingAction => timingAction.Act());
        }
        private void ActOnces()
        {
            KeyValuePair<ulong, TimingAction>[] kvs = onceActionDic.ToArray();
            if (ArrayExtends.IsNullOrEmpty(kvs)) return;
            Parallel.ForEach(kvs, kv => {
                if (kv.Value.Act()) {
                    TimingAction timingAction;
                    onceActionDic.TryRemove(kv.Key, out timingAction);
                }
            });
        }
        private ulong Register(ConcurrentDictionary<ulong, TimingAction> actionDic, Action action, uint period)
        {
            if (default(Action) == action) return default(ulong);
            TimingAction timingAction = new TimingAction(action, period);
            ulong key = TickExtends.Tick;
            actionDic.TryAdd(key, timingAction);
            return key;
        }
        public ulong RegisterRepeat(Action action, uint period)
        {
            return Register(repeatActionDic, action, period);
        }
        public ulong RegisterOnce(Action action, uint period)
        {
            return Register(onceActionDic, action, period);
        }

        private bool UnRegister(ConcurrentDictionary<ulong, TimingAction> actionDic, ulong key)
        {
            if (default(ulong) == key) return false;
            TimingAction _;
            return actionDic.TryRemove(key, out _);
        }
        public bool UnRegisterRepeat(ulong key)
        {
            return UnRegister(repeatActionDic, key);
        }
        public bool UnRegisterOnce(ulong key)
        {
            return UnRegister(onceActionDic, key);
        }
    }
}