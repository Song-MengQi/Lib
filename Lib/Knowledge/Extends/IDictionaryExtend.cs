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
        public static void Unsets<TKey, TValue>(this IDictionary<TKey, TValue> source, IEnumerable<TKey> keys)
        {
            foreach (var key in keys)
            {
                source.Remove(key);
            }
        }
        public static void Unsets<TKey, TValue>(this IDictionary<TKey, TValue> source, IEnumerable<KeyValuePair<TKey, TValue>> kvs)
        {
            source.Unsets(kvs.Select(kv=>kv.Key));
        }
        public static void Unsets(this IDictionary source, IEnumerable keys)
        {
            foreach (object key in keys)
            {
                source.Remove(key);
            }
        }
        public static void Unsets(this IDictionary source, IDictionary dic)
        {
            source.Unsets(dic.Keys);
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
        
        public static TValue TryGetValue<TKey, TValue>(this IDictionary<TKey, TValue> dic, TKey key)
        {
            TValue value = default(TValue);
            dic.TryGetValue(key, out value);
            return value;
        }
        
        public static TValue GetValueOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> dic, TKey key, Func<TValue> func)
        {
            TValue value = default(TValue);
            return dic.TryGetValue(key, out value) ? value : func();
        }
        public static TValue GetValueOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> dic, TKey key, TValue defaultValue = default(TValue))
        {
            return dic.GetValueOrDefault(key, ()=>defaultValue);
        }

        public static IEnumerable<DictionaryEntry> Generalize(this IDictionary source)
        {
            foreach (DictionaryEntry de in source)
            {
                yield return de;
            }
        }
        public static object GetValueOrDefault(this IDictionary dic, object key, Func<object> func)
        {
            //dic[key]没有则为null
            return dic.Contains(key) ? dic[key] : func();
        }
        public static object GetValueOrDefault(this IDictionary dic, object key, object defaultValue = default(object))
        {
            return dic.GetValueOrDefault(key, ()=>defaultValue);
        }
        public static void AddHead(this IDictionary dic, object key, object value)
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
        public static void SetIf<TSrc, TDest>(this IDictionary dic, object key, TSrc value, Func<TSrc, bool> func, Func<TSrc, TDest> to)
        {
            if (func(value)) dic[key] = to(value);
        }
        public static void SetIf<T>(this IDictionary dic, object key, T value, Func<T, bool> func)
        {
            SetIf(dic, key, value, func, v=>v);
        }
        public static void SetIf<T>(this IDictionary dic, object key, T value)
        {
            SetIf(dic, key, value, v=>false==ObjectExtends.EqualsDefault(v));
        }
        public static void SetIfNotEmpty(this IDictionary dic, object key, string value)
        {
            SetIf(dic, key, value, str=>false==string.IsNullOrEmpty(value));
        }
        public static void SetIfNotEmptyAnd(this IDictionary dic, object key, string value, Func<string, bool> func)
        {
            SetIf(dic, key, value, str => false == string.IsNullOrEmpty(value) && func(value));
        }
        public static void SetIfByte(this IDictionary dic, object key, string value)
        {
            SetIf(dic, key, value, StringExtends.IsByte, byte.Parse);
        }
        public static void SetIfUshort(this IDictionary dic, object key, string value)
        {
            SetIf(dic, key, value, StringExtends.IsUshort, ushort.Parse);
        }
        public static void SetIfUint(this IDictionary dic, object key, string value)
        {
            SetIf(dic, key, value, StringExtends.IsUint, uint.Parse);
        }
        public static void SetIfUlong(this IDictionary dic, object key, string value)
        {
            SetIf(dic, key, value, StringExtends.IsUlong, ulong.Parse);
        }
        public static void SetIfId(this IDictionary dic, object key, string value)
        {
            SetIf(dic, key, value, StringExtends.IsId, ulong.Parse);
        }
        public static void SetIfPositiveId(this IDictionary dic, object key, string value)
        {
            SetIf(dic, key, value, StringExtends.IsPositiveId, ulong.Parse);
        }
    }
}