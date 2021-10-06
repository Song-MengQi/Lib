using System;
using System.Collections.Generic;
using System.Linq;

namespace Lib.Timer
{
    public class TimingCache<TKey, TValue, TDic> : ITimingCache<TKey, TValue, TDic>, IDisposable
        where TDic : IDictionary<TKey, ObjectTicks<TValue>>, new()
    {
        public TDic Dic { get; private set; }
        private ulong key;
        protected TimingCache() : this(TimeSpan.FromMinutes(10d)) { }
        protected TimingCache(TimeSpan duration)
        {
            Dic = new TDic();
            TotalTimerExtends.RegisterRepeat(ref key, ()=>{
                long threshold = DateTime.Now.Ticks - duration.Ticks;
                TKey[] toDeleteKeys = Dic.Where(kvt=>kvt.Value.Ticks < threshold).Select(kvt=>kvt.Key).ToArray();
                if (toDeleteKeys.Count() == 0) return;
                foreach (TKey toDelete in toDeleteKeys)
                    Remove(toDelete);
            }, 1);
        }
        #region Dispose
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                TotalTimerExtends.UnRegisterRepeat(ref key);
            }
        }
        #endregion
        public void Add(TKey key, TValue value)
        {
            Dic.Add(key, new ObjectTicks<TValue>(value));
        }
        public bool ContainsKey(TKey key)
        {
            return Dic.ContainsKey(key);
        }
        public TValue this[TKey key]
        {
            get
            {
                ObjectTicks<TValue> objectTicks;
                return Dic.TryGetValue(key, out objectTicks)
                    ? objectTicks.Object
                    : default(TValue);
            }
            set
            {
                Dic[key] = new ObjectTicks<TValue>(value);
            }
        }
        public bool Remove(TKey key)
        {
            return Dic.Remove(key);
        }
    }
    public class TimingCache<TKey, TValue> : TimingCache<TKey, TValue, Dictionary<TKey, ObjectTicks<TValue>>>
    {
        public TimingCache() : base() { }
        public TimingCache(TimeSpan duration) : base(duration) { }
    }
}