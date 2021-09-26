using System;
using System.Collections.Generic;
using System.Linq;

namespace Lib
{
    public abstract class DictionaryTreeBase<T, TKey, TValue> : IDictionaryTree<T, TKey, TValue>
        where T : DictionaryTreeBase<T, TKey, TValue>
    {
        public TValue Value { get; private set; }
        protected Dictionary<TKey, T> childrenDic { get; set; }
        public virtual Dictionary<TKey, T> ChildrenDic { get { return childrenDic; } }
        public int Count
        {
            get
            {
                Dictionary<TKey, T> c = ChildrenDic;
                return default(Dictionary<TKey, T>) == c ? 0 : c.Count;
            }
        }
        protected DictionaryTreeBase(TValue value)
        {
            Value = value;
            childrenDic = default(Dictionary<TKey, T>);
        }
        protected void LoadChildren(Func<TValue, Dictionary<TKey, TValue>>[] funcs)
        {
            if (ArrayExtends.IsNullOrEmpty(funcs)) return;
            Dictionary<TKey, TValue> childrenValueDic = funcs[0](Value);
            if (ICollectionExtends.IsNullOrEmpty(childrenValueDic)) return;

            funcs = funcs.Skip(1).ToArray();
            if (0 == funcs.Length) funcs = default(Func<TValue, Dictionary<TKey, TValue>>[]);
            childrenDic = childrenValueDic.ToDictionary(kv => kv.Key, kv => CreateChildFunc(kv.Value, funcs));
        }
        protected abstract T CreateChildFunc(TValue childValue, Func<TValue, Dictionary<TKey, TValue>>[] childFuncs);
    }
}