using System.Collections.Generic;

namespace Lib
{
    public interface IDictionaryTree<T, TKey, TValue>
    {
        TValue Value { get; }
        Dictionary<TKey, T> ChildrenDic { get; }
        int Count { get; }
    }
}