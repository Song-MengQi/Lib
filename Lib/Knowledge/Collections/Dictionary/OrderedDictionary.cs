﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.Serialization;

namespace Lib
{
    [Serializable]
    public class OrderedDictionary<TKey, TValue> : OrderedDictionary, IDictionary<TKey, TValue>
    {
        public OrderedDictionary() : base() { }
        protected OrderedDictionary(SerializationInfo info, StreamingContext context) : base(info, context) { }
        public OrderedDictionary(int capacity) : base(capacity) { }
        public OrderedDictionary(IEqualityComparer comparer) : base(comparer) { }
        public OrderedDictionary(int capacity, IEqualityComparer comparer) : base(capacity, comparer) { }
        public TValue this[TKey key] { get { return (TValue)base[key]; } set { base[key] = value; } }
        public new ICollection<TKey> Keys { get { return base.Keys.Generalize<TKey>().ToArray(); } }
        public new ICollection<TValue> Values { get { return base.Values.Generalize<TValue>().ToArray(); } }
        public void Add(TKey key, TValue value) { base.Add(key, value); }
        public bool ContainsKey(TKey key) { return Contains(key); }
        public bool Remove(TKey key)
        {
            if (false == ContainsKey(key)) return false;
            base.Remove(key);
            return true;
        }
        public bool TryGetValue(TKey key, out TValue value)
        {
            if (ContainsKey(key))
            {
                value = this[key];
                return true;
            }
            value = default(TValue);
            return false;
        }
        public void Add(KeyValuePair<TKey, TValue> item) { Add(item.Key, item.Value); }
        public bool Contains(KeyValuePair<TKey, TValue> item) { return ContainsKey(item.Key) && this[item.Key].Equals(item.Value); }
        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            foreach (var kv in this)
            {
                array.SetValue(new KeyValuePair<TKey, TValue>(kv.Key, kv.Value), arrayIndex++);
            }
        }
        public bool Remove(KeyValuePair<TKey, TValue> item) { return Remove(item.Key); }
        public new IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return this.Generalize().Select(de => new KeyValuePair<TKey, TValue>((TKey)de.Key, (TValue)de.Value)).GetEnumerator();
        }
    }
}