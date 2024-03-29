﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Lib
{
    public static class IEnumerableExtends
    {
        public static bool IsNullOrEmpty(IEnumerable enumerable)
        {
            return default(IEnumerable) == enumerable || enumerable.Generalize().Count() == 0;
        }
        public static bool IsNullOrEmpty<TSource>(IEnumerable<TSource> enumerable)
        {
            return default(IEnumerable<TSource>) == enumerable || enumerable.Count() == 0;
        }
        public static bool Contains<TSource>(IEnumerable<TSource> enumerable, TSource value)
        {
            return false == IsNullOrEmpty(enumerable) && enumerable.Contains(value);
        }
        private static IEnumerable<TSource> Cascade<TSource>(IEnumerable<IEnumerable<TSource>> enumerables,
            Func<IEnumerable<TSource>, IEnumerable<TSource>, IEnumerable<TSource>> func)
        {
            //IEnumerable<TSource> result = new TSource[0];
            //foreach(IEnumerable<TSource> enumerable in enumerables)
            //{
            //    result = func(result, enumerable);
            //}
            //return result;
            IEnumerable<TSource> result = default(IEnumerable<TSource>);
            foreach (IEnumerable<TSource> enumerable in enumerables)
            {
                result = default(IEnumerable<TSource>) == result ? enumerable : func(result, enumerable);
            }
            return result;
        }
        //连接
        //public static IEnumerable<TSource> Concat<TSource>(IEnumerable<IEnumerable<TSource>> enumerables) { return Cascade(enumerables, Enumerable.Concat); }
        public static IEnumerable<TSource> Concat<TSource>(IEnumerable<IEnumerable<TSource>> enumerables) { return enumerables.SelectMany(enumerable=>enumerable); }
        public static IEnumerable<TSource> ConcatParams<TSource>(params IEnumerable<TSource>[] enumerables) { return Concat(enumerables); }

        //交集
        public static IEnumerable<TSource> Intersect<TSource>(IEnumerable<IEnumerable<TSource>> enumerables) { return Cascade(enumerables, Enumerable.Intersect); }
        //并集
        //public static IEnumerable<TSource> Union<TSource>(IEnumerable<IEnumerable<TSource>> enumerables) { return Cascade(enumerables, Enumerable.Union); }
        public static IEnumerable<TSource> Union<TSource>(IEnumerable<IEnumerable<TSource>> enumerables) { return enumerables.SelectMany(enumerable=>enumerable).Distinct(); }
        public static bool SequenceEqual<TSource>(IEnumerable<TSource> first, IEnumerable<TSource> second)
        {
            return default(IEnumerable<TSource>) == first || default(IEnumerable<TSource>) == second
                ? default(IEnumerable<TSource>) == first && default(IEnumerable<TSource>) == second
                : Enumerable.SequenceEqual(first, second);
        }
        public static bool SequenceEqual<TSource>(IEnumerable<TSource> first, IEnumerable<TSource> second, IEqualityComparer<TSource> comparer)
        {
            return default(IEnumerable<TSource>) == first || default(IEnumerable<TSource>) == second
                ? default(IEnumerable<TSource>) == first && default(IEnumerable<TSource>) == second
                : Enumerable.SequenceEqual(first, second, comparer);
        }
        public static void For(int from, int to, Action<int> action)
        {
            for (int i = from; i < to; ++i)
            {
                action(i);
            }
        }
        public static TResult[] For<TResult>(int from, int to, Func<int, TResult> func)
        {
            TResult[] results = new TResult[to - from];
            For(from, to, i=>{
                results[i - from] = func(i);
            });
            return results;
        }
    }
}