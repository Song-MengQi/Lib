using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Lib
{
    public static partial class IEnumerableExtend
    {
        public static bool All<TSource>(this IEnumerable<TSource> sources, Func<TSource, int, bool> predicate)
        {
            TSource[] ts = sources.ToArray();
            for (int i = 0; i < ts.Length; ++i)
            {
                if (false == predicate(ts[i], i)) return false;
            }
            return true;
        }
        public static bool Any<TSource>(this IEnumerable<TSource> sources, Func<TSource, int, bool> predicate)
        {
            TSource[] ts = sources.ToArray();
            for (int i = 0; i < ts.Length; ++i)
            {
                if (predicate(ts[i], i)) return true;
            }
            return false;
        }
        #region Order
        public static IOrderedEnumerable<TSource> Order<TSource>(this IEnumerable<TSource> sources)
        {
            return sources.OrderBy(source=>source);
        }
        public static IOrderedEnumerable<TSource> Order<TSource>(this IEnumerable<TSource> sources, IComparer<TSource> comparer)
        {
            return sources.OrderBy(source=>source, comparer);
        }
        public static IOrderedEnumerable<TSource> OrderDescending<TSource>(this IEnumerable<TSource> sources)
        {
            return sources.OrderByDescending(source=>source);
        }
        public static IOrderedEnumerable<TSource> OrderDescending<TSource>(this IEnumerable<TSource> sources, IComparer<TSource> comparer)
        {
            return sources.OrderByDescending(source=>source, comparer);
        }
        public static IOrderedEnumerable<TSource> Order<TSource>(this IEnumerable<TSource> sources, bool desc)
        {
            return desc ? sources.OrderDescending() : sources.Order();
        }
        public static IOrderedEnumerable<TSource> Order<TSource>(this IEnumerable<TSource> sources, IComparer<TSource> comparer, bool desc)
        {
            return desc ? sources.OrderDescending(comparer) : sources.Order(comparer);
        }
        public static IOrderedEnumerable<TSource> OrderBy<TSource, TKey>(this IEnumerable<TSource> sources, Func<TSource, TKey> keySelector, bool desc)
        {
            return desc ? sources.OrderByDescending(keySelector) : sources.OrderBy(keySelector);
        }
        public static IOrderedEnumerable<TSource> OrderBy<TSource, TKey>(this IEnumerable<TSource> sources, Func<TSource, TKey> keySelector, IComparer<TKey> comparer, bool desc)
        {
            return desc ? sources.OrderByDescending(keySelector, comparer) : sources.OrderBy(keySelector, comparer);
        }
        #endregion
        public static TSource Top<TSource>(this IEnumerable<TSource> sources, Func<TSource, TSource, bool> compare)
        {
            if (sources.Count() < 1) return default(TSource);
            TSource top = sources.First();
            foreach (TSource source in sources)
            {
                if (compare(source, top))
                {
                    top = source;
                }
            }
            return top;
        }
        public static TSource Of<TSource, TResult>(this IEnumerable<TSource> sources, Func<TSource, TResult> selector, Func<TResult, TResult, bool> compare)
        {
            return sources.Top((x, y)=>compare(selector(x), selector(y)));
        }
        #region MaxOf
        public static TSource MaxOf<TSource, TResult>(this IEnumerable<TSource> sources, Func<TSource, TResult> selector)
            where TResult : IComparable<TResult>
        {
            return sources.Of(selector, (x, y) => x.CompareTo(y) > 0);
        }
        //public static TSource MaxOf<TSource>(this IEnumerable<TSource> sources, Func<TSource, ulong> selector)
        //{
        //    return sources.Of(selector, (x, y)=>x>y);
        //}
        //public static TSource MaxOf<TSource>(this IEnumerable<TSource> sources, Func<TSource, long> selector)
        //{
        //    return sources.Of(selector, (x, y) => x > y);
        //}
        //public static TSource MaxOf<TSource>(this IEnumerable<TSource> sources, Func<TSource, uint> selector)
        //{
        //    return sources.Of(selector, (x, y) => x > y);
        //}
        //public static TSource MaxOf<TSource>(this IEnumerable<TSource> sources, Func<TSource, int> selector)
        //{
        //    return sources.Of(selector, (x, y) => x > y);
        //}
        //public static TSource MaxOf<TSource>(this IEnumerable<TSource> sources, Func<TSource, ushort> selector)
        //{
        //    return sources.Of(selector, (x, y) => x > y);
        //}
        //public static TSource MaxOf<TSource>(this IEnumerable<TSource> sources, Func<TSource, short> selector)
        //{
        //    return sources.Of(selector, (x, y) => x > y);
        //}
        //public static TSource MaxOf<TSource>(this IEnumerable<TSource> sources, Func<TSource, byte> selector)
        //{
        //    return sources.Of(selector, (x, y) => x > y);
        //}
        //public static TSource MaxOf<TSource>(this IEnumerable<TSource> sources, Func<TSource, sbyte> selector)
        //{
        //    return sources.Of(selector, (x, y) => x > y);
        //}
        //public static TSource MaxOf<TSource>(this IEnumerable<TSource> sources, Func<TSource, decimal> selector)
        //{
        //    return sources.Of(selector, (x, y) => x > y);
        //}
        //public static TSource MaxOf<TSource>(this IEnumerable<TSource> sources, Func<TSource, double> selector)
        //{
        //    return sources.Of(selector, (x, y) => x > y);
        //}
        //public static TSource MaxOf<TSource>(this IEnumerable<TSource> sources, Func<TSource, float> selector)
        //{
        //    return sources.Of(selector, (x, y) => x > y);
        //}
        #endregion
        #region MinOf
        public static TSource MinOf<TSource, TResult>(this IEnumerable<TSource> sources, Func<TSource, TResult> selector)
            where TResult : IComparable<TResult>
        {
            return sources.Of(selector, (x, y) => x.CompareTo(y) < 0);
        }
        //public static TSource MinOf<TSource>(this IEnumerable<TSource> sources, Func<TSource, ulong> selector)
        //{
        //    return sources.Of(selector, (x, y) => x < y);
        //}
        //public static TSource MinOf<TSource>(this IEnumerable<TSource> sources, Func<TSource, long> selector)
        //{
        //    return sources.Of(selector, (x, y) => x < y);
        //}
        //public static TSource MinOf<TSource>(this IEnumerable<TSource> sources, Func<TSource, uint> selector)
        //{
        //    return sources.Of(selector, (x, y) => x < y);
        //}
        //public static TSource MinOf<TSource>(this IEnumerable<TSource> sources, Func<TSource, int> selector)
        //{
        //    return sources.Of(selector, (x, y) => x < y);
        //}
        //public static TSource MinOf<TSource>(this IEnumerable<TSource> sources, Func<TSource, ushort> selector)
        //{
        //    return sources.Of(selector, (x, y) => x < y);
        //}
        //public static TSource MinOf<TSource>(this IEnumerable<TSource> sources, Func<TSource, short> selector)
        //{
        //    return sources.Of(selector, (x, y) => x < y);
        //}
        //public static TSource MinOf<TSource>(this IEnumerable<TSource> sources, Func<TSource, byte> selector)
        //{
        //    return sources.Of(selector, (x, y) => x < y);
        //}
        //public static TSource MinOf<TSource>(this IEnumerable<TSource> sources, Func<TSource, sbyte> selector)
        //{
        //    return sources.Of(selector, (x, y) => x < y);
        //}
        //public static TSource MinOf<TSource>(this IEnumerable<TSource> sources, Func<TSource, decimal> selector)
        //{
        //    return sources.Of(selector, (x, y) => x < y);
        //}
        //public static TSource MinOf<TSource>(this IEnumerable<TSource> sources, Func<TSource, double> selector)
        //{
        //    return sources.Of(selector, (x, y) => x < y);
        //}
        //public static TSource MinOf<TSource>(this IEnumerable<TSource> sources, Func<TSource, float> selector)
        //{
        //    return sources.Of(selector, (x, y) => x < y);
        //}
        #endregion
        public static IEnumerable<TSource> Foreach<TSource>(this IEnumerable<TSource> sources, Action<TSource> action)
        {
            foreach(TSource source in sources)
            {
                action(source);
            }
            return sources;
        }
        public static IEnumerable<TSource> Foreach<TSource>(this IEnumerable<TSource> sources, Action<TSource, int> action)
        {
            TSource[] ts = sources.ToArray();
            for (int i = 0; i < ts.Length; ++i)
            {
                action(ts[i], i);
            }
            return sources;
        }
        public static bool IsUnique<TSource>(this IEnumerable<TSource> sources)
        {
            return sources.Count()==sources.Distinct().Count();
        }
        public static bool IsUnique<TSource>(this IEnumerable<TSource> sources, IEqualityComparer<TSource> comparer)
        {
            return sources.Count() == sources.Distinct(comparer).Count();
        }

        public static uint Sum(this IEnumerable<uint> sources)
        {
            return (uint)sources.Sum(source=>(long)source);
        }
        public static ulong Sum(this IEnumerable<ulong> sources)
        {
            return (ulong)sources.Sum(source => (long)source);
        }
        public static Dictionary<TKey, TSource> ToDictionary<TKey, TSource>(this IEnumerable<KeyValuePair<TKey, TSource>> sources)
        {
            return sources.ToDictionary(kv=>kv.Key, kv=>kv.Value);
        }

        public static IEnumerable<T> Generalize<T>(this IEnumerable source)
        {
            foreach (object item in source)
            {
                yield return (T)item;
            }
        }
        public static IEnumerable<object> Generalize(this IEnumerable source)
        {
            foreach (object item in source)
            {
                yield return item;
            }
        }

        public static ListDictionary<TKey, TSource> ToListDictionary<TKey, TSource>(this IEnumerable<TSource> sources, Func<TSource, TKey> keySelector)
        {
            ListDictionary<TKey, TSource> dic = new ListDictionary<TKey, TSource>();
            foreach (TSource source in sources)
            {
                dic.Add(keySelector(source), source);
            }
            return dic;
        }
        public static ListDictionary<TKey, TValue> ToListDictionary<TKey, TSource, TValue>(this IEnumerable<TSource> sources, Func<TSource, TKey> keySelector, Func<TSource, TValue> elementSelector)
        {
            ListDictionary<TKey, TValue> dic = new ListDictionary<TKey, TValue>();
            foreach (TSource source in sources)
            {
                dic.Add(keySelector(source), elementSelector(source));
            }
            return dic;
        }
        public static ListDictionary<TKey, TSource> ToListDictionary<TKey, TSource>(this IEnumerable<KeyValuePair<TKey, TSource>> sources)
        {
            return sources.ToListDictionary(kv=>kv.Key, kv=>kv.Value);
        }
    }
    //public static partial class EnumerableExtend
    //{
    //    public static IEnumerable<object> Generalize(this IEnumerable source)
    //    {
    //        foreach (object item in source)
    //        {
    //            yield return item;
    //        }
    //    }
    //    public static bool GeneralizeAll(this IEnumerable source, Func<object, bool> predicate)
    //    {
    //        return source.Generalize().All(predicate);
    //    }
    //    public static bool GeneralizeAny(this IEnumerable source, Func<object, bool> predicate)
    //    {
    //        return source.Generalize().Any(predicate);
    //    }
    //    public static bool GeneralizeAny(this IEnumerable source)
    //    {
    //        return source.Generalize().Any();
    //    }
    //    public static int GeneralizeCount(this IEnumerable source)
    //    {
    //        return source.Generalize().Count();
    //    }
    //    public static IEnumerable<TResult> GeneralizeSelect<TResult>(this IEnumerable source, Func<object, TResult> selector)
    //    {
    //        return source.Generalize().Select(selector);
    //    }
    //    public static IEnumerable<TResult> GeneralizeSelect<TResult>(this IEnumerable source, Func<object, int, TResult> selector)
    //    {
    //        return source.Generalize().Select(selector);
    //    }
    //    public static IEnumerable<object> GeneralizeForeach<TResult>(this IEnumerable source, Action<object> action)
    //    {
    //        return source.Generalize().Foreach(action);
    //    }
    //    public static IEnumerable<object> GeneralizeForeach<TResult>(this IEnumerable source, Action<object, int> action)
    //    {
    //        return source.Generalize().Foreach(action);
    //    }
    //    public static Array GeneralizeToArray(this IEnumerable source)
    //    {
    //        return source.Generalize().ToArray();
    //    }
    //    public static List<object> GeneralizeToList(this IEnumerable source)
    //    {
    //        return source.Generalize().ToList();
    //    }
    //}
}