using System.Collections.Generic;
using System.Linq;

namespace Lib
{
    public static class IDictionaryTreeExtend
    {
        public static bool ContainsKey<T, TKey, TValue>(this IDictionaryTree<T, TKey, TValue> dictionaryTree, TKey key)
        {
            Dictionary<TKey, T> childrenDic = dictionaryTree.ChildrenDic;
            return default(Dictionary<TKey, T>) == childrenDic ? false : childrenDic.ContainsKey(key);
        }
        #region Value
        public static TValue GetChildValue<T, TKey, TValue>(this IDictionaryTree<T, TKey, TValue> dictionaryTree, TKey key)
            where T : IDictionaryTree<T, TKey, TValue>
        {
            T t = dictionaryTree.GetChild(key);
            return ObjectExtends.EqualsDefault(t) ? default(TValue) : t.Value;
        }
        public static Dictionary<TKey, TValue> GetChildrenValueDic<T, TKey, TValue>(this IDictionaryTree<T, TKey, TValue> dictionaryTree)
            where T : IDictionaryTree<T, TKey, TValue>
        {
            Dictionary<TKey, T> childrenDic = dictionaryTree.ChildrenDic;
            return default(Dictionary<TKey, T>) == childrenDic ? default(Dictionary<TKey, TValue>) : childrenDic.ToDictionary(kv => kv.Key, kv => kv.Value.Value);
        }
        public static TValue[] GetChildrenValues<T, TKey, TValue>(this IDictionaryTree<T, TKey, TValue> dictionaryTree)
            where T : IDictionaryTree<T, TKey, TValue>
        {
            Dictionary<TKey, T> childrenDic = dictionaryTree.ChildrenDic;
            return default(Dictionary<TKey, T>) == childrenDic ? default(TValue[]) : childrenDic.Values.Select(t => t.Value).ToArray();
        }
        #endregion
        #region Child
        public static T GetChild<T, TKey, TValue>(this IDictionaryTree<T, TKey, TValue> dictionaryTree, TKey key)
        {
            Dictionary<TKey, T> childrenDic = dictionaryTree.ChildrenDic;
            return default(Dictionary<TKey, T>) == childrenDic || false == childrenDic.ContainsKey(key) ? default(T) : childrenDic[key];
        }
        public static T[] GetChildren<T, TKey, TValue>(this IDictionaryTree<T, TKey, TValue> dictionaryTree)
            where T : IDictionaryTree<T, TKey, TValue>
        {
            Dictionary<TKey, T> childrenDic = dictionaryTree.ChildrenDic;
            return default(Dictionary<TKey, T>) == childrenDic ? default(T[]) : childrenDic.Values.ToArray();
        }
        #endregion
    }
}