using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lib
{
    public static class ParallelExtends
    {
        public static void Invoke(params Action[] actions)
        {
            Task[] tasks = actions.Select(action=>new Task(()=>action())).ToArray();
            Parallel.ForEach(tasks, task=>task.Start());
            Task.WhenAll(tasks).Wait();
        }
        public static T[] Invoke<T>(params Func<T>[] funcs)
        {
            T[] ts = new T[funcs.Length];
            Invoke(funcs
                .Select((func, i)=>new Action(()=>ts[i] = func()))
                .ToArray());
            return ts;
        }
        public static void ForEach<TSource>(IEnumerable<TSource> source, Action<TSource> action)
        {
            Invoke(source.Select(item=>new Action(()=>action(item))).ToArray());
        }
        public static void ForEach<TSource>(IEnumerable<TSource> source, Action<TSource, int> action)
        {
            Invoke(source.Select((item, i)=>new Action(()=>action(item, i))).ToArray());
        }
        public static TResult[] Select<TSource, TResult>(IEnumerable<TSource> source, Func<TSource, TResult> func)
        {
            return Invoke(source.Select(item=>new Func<TResult>(()=>func(item))).ToArray());
        }
        public static TResult[] Select<TSource, TResult>(IEnumerable<TSource> source, Func<TSource, int, TResult> func)
        {
            return Invoke(source.Select((item, i)=>new Func<TResult>(()=>func(item, i))).ToArray());
        }
        public static void For(int from, int to, Action<int> action)
        {
            Invoke(IEnumerableExtends.For(from, to, i=>new Action(()=>action(i))));
        }
        public static TResult[] For<TResult>(int from, int to, Func<int, TResult> func)
        {
            return Invoke(IEnumerableExtends.For(from, to, i=>new Func<TResult>(()=>func(i))));
        }

        public static int Check(params Func<int>[] funcs)
        {
            int[] states = Invoke(funcs);
            return states.FirstOrDefault(state=>ResultState.Success!=state);
        }
        public static Result GetResult(params Func<Result>[] funcs)
        {
            return new Result(Check(funcs.Select(func=>new Func<int>(()=>func().State)).ToArray()));
        }
    }
}