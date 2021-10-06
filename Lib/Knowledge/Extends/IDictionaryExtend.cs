using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Lib
{
    public static class IDictionaryExtend
    {
        #region Sets
        public static void Sets<TKey, TValue>(this IDictionary<TKey, TValue> source, IEnumerable<KeyValuePair<TKey, TValue>> kvs)
        {
            foreach (var kv in kvs)
            {
                source[kv.Key] = kv.Value;
            }
        }
        public static void Sets(this IDictionary source, IDictionary dic)
        {
            foreach (DictionaryEntry kv in dic)
            {
                source[kv.Key] = kv.Value;
            }
        }
        #endregion
        #region Unsets
        public static void Unsets<TKey, TValue>(this IDictionary<TKey, TValue> source, IEnumerable<KeyValuePair<TKey, TValue>> kvs)
        {
            foreach (var kv in kvs)
            {
                source.Remove(kv.Key);
            }
        }
        public static void Unsets(this IDictionary source, IDictionary dic)
        {
            foreach (DictionaryEntry kv in dic)
            {
                source.Remove(kv.Key);
            }
        }
        #endregion
        #region Gets
        public static void Gets<TKey, TValue>(this IDictionary<TKey, TValue> source, IDictionary<TKey, TValue> dic)
        {
            foreach (TKey key in dic.Keys.ToArray())
            {
                TValue value;
                source.TryGetValue(key, out value);
                dic[key] = value;
            }
        }
        public static void Gets(this IDictionary source, IDictionary dic)
        {
            foreach (object key in dic.Keys.Generalize().ToArray())
            {
                dic[key] = source.Contains(key) ? source[key] : default(object);
            }
        }
        #endregion
        public static IEnumerable<DictionaryEntry> Generalize(this IDictionary source)
        {
            foreach (DictionaryEntry de in source)
            {
                yield return de;
            }
        }
        public static void AddHead<TDictionary>(this TDictionary dic, object key, object value)
            where TDictionary : IDictionary, new()
        {
            DictionaryEntry[] des = new DictionaryEntry[dic.Count];
            dic.CopyTo(des, 0);
            dic.Clear();
            dic.Add(key, value);
            foreach (DictionaryEntry de in des)
            {
                dic.Add(de.Key, de.Value);
            }
        }
        public static DictionaryEntry GetHead(this IDictionary dic)
        {
            foreach (DictionaryEntry value in dic)
            {
                return value;
            }
            return default(DictionaryEntry);
        }
        public static object GetHeadValue(this IDictionary dic)
        {
            foreach (object value in dic.Values)
            {
                return value;
            }
            return default(object);
        }
        public static void AddIf<TSrc, TDest>(this IDictionary dic, object key, TSrc value, Func<TSrc, bool> func, Func<TSrc, TDest> to)
        {
            if (func(value)) dic.Add(key, to(value));
        }
        public static void AddIf<T>(this IDictionary dic, object key, T value, Func<T, bool> func)
        {
            AddIf(dic, key, value, func, v=>v);
        }
        public static void AddIf<T>(this IDictionary dic, object key, T value)
        {
            AddIf(dic, key, value, v=>false==ObjectExtends.EqualsDefault(v));
        }
        public static void AddIfNotEmpty(this IDictionary dic, object key, string value)
        {
            AddIf(dic, key, value, str=>false==string.IsNullOrEmpty(value));
        }
        public static void AddIfNotEmptyAnd(this IDictionary dic, object key, string value, Func<string, bool> func)
        {
            AddIf(dic, key, value, str => false == string.IsNullOrEmpty(value) && func(value));
        }
        public static void AddIfByte(this IDictionary dic, object key, string value)
        {
            AddIf(dic, key, value, StringExtends.IsByte, byte.Parse);
        }
        public static void AddIfUshort(this IDictionary dic, object key, string value)
        {
            AddIf(dic, key, value, StringExtends.IsUshort, ushort.Parse);
        }
        public static void AddIfUint(this IDictionary dic, object key, string value)
        {
            AddIf(dic, key, value, StringExtends.IsUint, uint.Parse);
        }
        public static void AddIfUlong(this IDictionary dic, object key, string value)
        {
            AddIf(dic, key, value, StringExtends.IsUlong, ulong.Parse);
        }
        public static void AddIfId(this IDictionary dic, object key, string value)
        {
            AddIf(dic, key, value, StringExtends.IsId, ulong.Parse);
        }
        public static void AddIfPositiveId(this IDictionary dic, object key, string value)
        {
            AddIf(dic, key, value, StringExtends.IsPositiveId, ulong.Parse);
        }
    }
}