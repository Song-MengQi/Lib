using System.Collections.Generic;

namespace Lib
{
    public class KeyEqualityComparer<TKey, TValue> : SingletonBase<KeyEqualityComparer<TKey, TValue>, IEqualityComparer<KeyValuePair<TKey, TValue>>>, IEqualityComparer<KeyValuePair<TKey, TValue>>
    {
        public bool Equals(KeyValuePair<TKey, TValue> x, KeyValuePair<TKey, TValue> y)
        {
            return ObjectExtends.Equals(x.Key, y.Key);
        }
        public int GetHashCode(KeyValuePair<TKey, TValue> obj)
        {
            return ObjectExtends.EqualsDefault(obj.Key) ? 0 : obj.Key.GetHashCode();
        }
    }
}