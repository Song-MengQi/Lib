using System.Collections.Generic;
using Lib;

namespace Test.Lib
{
    public abstract class DictionaryTreeMockBase<T, TKey, TValue> : MockBase, IDictionaryTree<T, TKey, TValue>
        where T : DictionaryTreeMockBase<T, TKey, TValue>
    {
        public TValue Value
        {
            get
            {
                return GetValue<TValue>();
            }
        }
        public Dictionary<TKey, T> ChildrenDic
        {
            get
            {
                return GetValue<Dictionary<TKey, T>>();
            }
        }
        public int Count
        {
            get
            {
                return GetValue<int>();
            }
        }
    }
}