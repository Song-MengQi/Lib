using System;
using System.Collections.Generic;

namespace Lib
{
    public class HungryDictionaryTree<TKey, TValue> : DictionaryTreeBase<HungryDictionaryTree<TKey, TValue>, TKey, TValue>
    {
        public HungryDictionaryTree(TValue value, Func<TValue, Dictionary<TKey, TValue>>[] funcs) : base(value)
        {
            LoadChildren(funcs);
        }
        protected override HungryDictionaryTree<TKey, TValue> CreateChildFunc(TValue childValue, Func<TValue, Dictionary<TKey, TValue>>[] childFuncs)
        {
            return new HungryDictionaryTree<TKey, TValue>(childValue, childFuncs);
        }
    }
}