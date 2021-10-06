using System.Collections.Generic;

namespace Lib.Timer
{
    public interface ITimingCache<TKey, TValue>
    {
        void Add(TKey key, TValue value);
        bool ContainsKey(TKey key);
        TValue this[TKey key] { get; set; }
        bool Remove(TKey key);
    }
    public interface ITimingCache<TKey, TValue, TDic> : ITimingCache<TKey, TValue>
        where TDic : IDictionary<TKey, ObjectTicks<TValue>>
    {
        TDic Dic { get; }
    }
}