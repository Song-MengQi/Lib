using System;
using System.Collections.Generic;

namespace Lib
{
    public class LazyDictionaryTree<TKey, TValue> : LazyDictionaryTreeBase<LazyDictionaryTree<TKey, TValue>, TKey, TValue>
    {
        public LazyDictionaryTree(TValue value, Func<TValue, Dictionary<TKey, TValue>>[] funcs) : base(value, funcs)
        {
        }
        protected override LazyDictionaryTree<TKey, TValue> CreateChildFunc(TValue childValue, Func<TValue, Dictionary<TKey, TValue>>[] childFuncs)
        {
            return new LazyDictionaryTree<TKey, TValue>(childValue, childFuncs);
        }
        protected override void EnsureLoadChildren()
        {
            if (default(Func<TValue, Dictionary<TKey, TValue>>[]) == Funcs) return;//加载过了
            LoadChildren(Funcs);
            Funcs = default(Func<TValue, Dictionary<TKey, TValue>>[]);
        }
    }
}