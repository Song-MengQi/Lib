using System;
using System.Collections.Concurrent;

namespace Lib.Timer
{
    public class ConcurrentTimingCache<TKey, TValue> : TimingCache<TKey, TValue, ConcurrentDictionary<TKey, ObjectTicks<TValue>>>
    {
        public ConcurrentTimingCache() :base() { }
        public ConcurrentTimingCache(TimeSpan duration) : base(duration) { }
    }
}