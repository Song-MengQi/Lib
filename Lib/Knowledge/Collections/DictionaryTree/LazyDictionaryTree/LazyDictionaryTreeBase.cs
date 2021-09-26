using System;
using System.Collections.Generic;

namespace Lib
{
    public abstract class LazyDictionaryTreeBase<T, TKey, TValue> : DictionaryTreeBase<T, TKey, TValue>
        where T : LazyDictionaryTreeBase<T, TKey, TValue>
    {
        protected Func<TValue, Dictionary<TKey, TValue>>[] Funcs { get; set; }
        public override Dictionary<TKey, T> ChildrenDic
        {
            get
            {
                EnsureLoadChildren();
                return base.ChildrenDic;
            }
        }
        protected LazyDictionaryTreeBase(TValue value, Func<TValue, Dictionary<TKey, TValue>>[] funcs)
            : base(value)
        {
            Funcs = funcs;
        }
        protected abstract void EnsureLoadChildren();
    }
}