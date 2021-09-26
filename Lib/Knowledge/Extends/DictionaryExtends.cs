using System.Collections.Generic;
using System.Linq;

namespace Lib
{
    public static class DictionaryExtends
    {
        public static TDictionary FromKVs<TDictionary, TKey, TValue>(IEnumerable<TKey> keys, IEnumerable<TValue> values)
            where TDictionary : IDictionary<TKey, TValue>, new()
        {
            TDictionary dictionary = new TDictionary();
            TKey[] keyArray = keys.ToArray();
            TValue[] valueArray = values.ToArray();
            for (int i = 0; i < keyArray.Length; ++i)
            {
                dictionary.Add(keyArray[i], valueArray[i]);
            }
            return dictionary;
        }
        public static Dictionary<TKey, TValue> FromKVs<TKey, TValue>(IEnumerable<TKey> keys, IEnumerable<TValue> values)
        {
            return FromKVs<Dictionary<TKey, TValue>, TKey, TValue>(keys, values);
        }
    }
}