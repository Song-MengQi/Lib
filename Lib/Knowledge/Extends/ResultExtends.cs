using System;
using System.Linq;

namespace Lib
{
    public static class ResultExtends
    {
        #region check
        public static int Check(params Func<int>[] funcs)
        {
            int result = ResultState.Success;
            foreach (Func<int> func in funcs)
            {
                result = func();
                if (result != ResultState.Success) return result;
            }
            return ResultState.Success;
        }
        public static Result GetResult(params Func<int>[] funcs)
        {
            return new Result(Check(funcs));
        }
        #region func直接返回T
        public static Result GetResult(Func<int> checkFunc, Action action)
        {
            return GetResult(checkFunc(), action);
        }
        public static Result<T> GetResult<T>(Func<int> checkFunc, Func<T> func)
        {
            return GetResult(checkFunc(), func);
        }
        public static Result GetResult(Func<int> f1, Func<int> f2, Action action)
        {
            return GetResult(Check(f1, f2), action);
        }
        public static Result<T> GetResult<T>(Func<int> f1, Func<int> f2, Func<T> func)
        {
            return GetResult(Check(f1, f2), func);
        }
        public static Result GetResult(Func<int> f1, Func<int> f2, Func<int> f3, Action action)
        {
            return GetResult(Check(f1, f2, f3), action);
        }
        public static Result<T> GetResult<T>(Func<int> f1, Func<int> f2, Func<int> f3, Func<T> func)
        {
            return GetResult(Check(f1, f2, f3), func);
        }
        public static Result GetResult(Func<int> f1, Func<int> f2, Func<int> f3, Func<int> f4, Action action)
        {
            return GetResult(Check(f1, f2, f3, f4), action);
        }
        public static Result<T> GetResult<T>(Func<int> f1, Func<int> f2, Func<int> f3, Func<int> f4, Func<T> func)
        {
            return GetResult(Check(f1, f2, f3, f4), func);
        }
        public static Result GetResult(Func<int> f1, Func<int> f2, Func<int> f3, Func<int> f4, Func<int> f5, Action action)
        {
            return GetResult(Check(f1, f2, f3, f4, f5), action);
        }
        public static Result<T> GetResult<T>(Func<int> f1, Func<int> f2, Func<int> f3, Func<int> f4, Func<int> f5, Func<T> func)
        {
            return GetResult(Check(f1, f2, f3, f4, f5), func);
        }
        public static Result GetResult(Func<int> f1, Func<int> f2, Func<int> f3, Func<int> f4, Func<int> f5, Func<int> f6, Action action)
        {
            return GetResult(Check(f1, f2, f3, f4, f5, f6), action);
        }
        public static Result<T> GetResult<T>(Func<int> f1, Func<int> f2, Func<int> f3, Func<int> f4, Func<int> f5, Func<int> f6, Func<T> func)
        {
            return GetResult(Check(f1, f2, f3, f4, f5, f6), func);
        }
        public static Result GetResult(Func<int> f1, Func<int> f2, Func<int> f3, Func<int> f4, Func<int> f5, Func<int> f6, Func<int> f7, Action action)
        {
            return GetResult(Check(f1, f2, f3, f4, f5, f6, f7), action);
        }
        public static Result<T> GetResult<T>(Func<int> f1, Func<int> f2, Func<int> f3, Func<int> f4, Func<int> f5, Func<int> f6, Func<int> f7, Func<T> func)
        {
            return GetResult(Check(f1, f2, f3, f4, f5, f6, f7), func);
        }
        public static Result GetResult(Func<int> f1, Func<int> f2, Func<int> f3, Func<int> f4, Func<int> f5, Func<int> f6, Func<int> f7, Func<int> f8, Action action)
        {
            return GetResult(Check(f1, f2, f3, f4, f5, f6, f7, f8), action);
        }
        public static Result<T> GetResult<T>(Func<int> f1, Func<int> f2, Func<int> f3, Func<int> f4, Func<int> f5, Func<int> f6, Func<int> f7, Func<int> f8, Func<T> func)
        {
            return GetResult(Check(f1, f2, f3, f4, f5, f6, f7, f8), func);
        }
        public static Result GetResult(Func<int> f1, Func<int> f2, Func<int> f3, Func<int> f4, Func<int> f5, Func<int> f6, Func<int> f7, Func<int> f8, Func<int> f9, Action action)
        {
            return GetResult(Check(f1, f2, f3, f4, f5, f6, f7, f8, f9), action);
        }
        public static Result<T> GetResult<T>(Func<int> f1, Func<int> f2, Func<int> f3, Func<int> f4, Func<int> f5, Func<int> f6, Func<int> f7, Func<int> f8, Func<int> f9, Func<T> func)
        {
            return GetResult(Check(f1, f2, f3, f4, f5, f6, f7, f8, f9), func);
        }
        public static Result GetResult(Func<int> f1, Func<int> f2, Func<int> f3, Func<int> f4, Func<int> f5, Func<int> f6, Func<int> f7, Func<int> f8, Func<int> f9, Func<int> f10, Action action)
        {
            return GetResult(Check(f1, f2, f3, f4, f5, f6, f7, f8, f9, f10), action);
        }
        public static Result<T> GetResult<T>(Func<int> f1, Func<int> f2, Func<int> f3, Func<int> f4, Func<int> f5, Func<int> f6, Func<int> f7, Func<int> f8, Func<int> f9, Func<int> f10, Func<T> func)
        {
            return GetResult(Check(f1, f2, f3, f4, f5, f6, f7, f8, f9, f10), func);
        }
        public static Result GetResult(Func<int> f1, Func<int> f2, Func<int> f3, Func<int> f4, Func<int> f5, Func<int> f6, Func<int> f7, Func<int> f8, Func<int> f9, Func<int> f10, Func<int> f11, Action action)
        {
            return GetResult(Check(f1, f2, f3, f4, f5, f6, f7, f8, f9, f10, f11), action);
        }
        public static Result<T> GetResult<T>(Func<int> f1, Func<int> f2, Func<int> f3, Func<int> f4, Func<int> f5, Func<int> f6, Func<int> f7, Func<int> f8, Func<int> f9, Func<int> f10, Func<int> f11, Func<T> func)
        {
            return GetResult(Check(f1, f2, f3, f4, f5, f6, f7, f8, f9, f10, f11), func);
        }
        public static Result GetResult(Func<int> f1, Func<int> f2, Func<int> f3, Func<int> f4, Func<int> f5, Func<int> f6, Func<int> f7, Func<int> f8, Func<int> f9, Func<int> f10, Func<int> f11, Func<int> f12, Action action)
        {
            return GetResult(Check(f1, f2, f3, f4, f5, f6, f7, f8, f9, f10, f11, f12), action);
        }
        public static Result<T> GetResult<T>(Func<int> f1, Func<int> f2, Func<int> f3, Func<int> f4, Func<int> f5, Func<int> f6, Func<int> f7, Func<int> f8, Func<int> f9, Func<int> f10, Func<int> f11, Func<int> f12, Func<T> func)
        {
            return GetResult(Check(f1, f2, f3, f4, f5, f6, f7, f8, f9, f10, f11, f12), func);
        }
        public static Result GetResult(Func<int> f1, Func<int> f2, Func<int> f3, Func<int> f4, Func<int> f5, Func<int> f6, Func<int> f7, Func<int> f8, Func<int> f9, Func<int> f10, Func<int> f11, Func<int> f12, Func<int> f13, Action action)
        {
            return GetResult(Check(f1, f2, f3, f4, f5, f6, f7, f8, f9, f10, f11, f12, f13), action);
        }
        public static Result<T> GetResult<T>(Func<int> f1, Func<int> f2, Func<int> f3, Func<int> f4, Func<int> f5, Func<int> f6, Func<int> f7, Func<int> f8, Func<int> f9, Func<int> f10, Func<int> f11, Func<int> f12, Func<int> f13, Func<T> func)
        {
            return GetResult(Check(f1, f2, f3, f4, f5, f6, f7, f8, f9, f10, f11, f12, f13), func);
        }
        public static Result GetResult(Func<int> f1, Func<int> f2, Func<int> f3, Func<int> f4, Func<int> f5, Func<int> f6, Func<int> f7, Func<int> f8, Func<int> f9, Func<int> f10, Func<int> f11, Func<int> f12, Func<int> f13, Func<int> f14, Action action)
        {
            return GetResult(Check(f1, f2, f3, f4, f5, f6, f7, f8, f9, f10, f11, f12, f13, f14), action);
        }
        public static Result<T> GetResult<T>(Func<int> f1, Func<int> f2, Func<int> f3, Func<int> f4, Func<int> f5, Func<int> f6, Func<int> f7, Func<int> f8, Func<int> f9, Func<int> f10, Func<int> f11, Func<int> f12, Func<int> f13, Func<int> f14, Func<T> func)
        {
            return GetResult(Check(f1, f2, f3, f4, f5, f6, f7, f8, f9, f10, f11, f12, f13, f14), func);
        }
        public static Result GetResult(Func<int> f1, Func<int> f2, Func<int> f3, Func<int> f4, Func<int> f5, Func<int> f6, Func<int> f7, Func<int> f8, Func<int> f9, Func<int> f10, Func<int> f11, Func<int> f12, Func<int> f13, Func<int> f14, Func<int> f15, Action action)
        {
            return GetResult(Check(f1, f2, f3, f4, f5, f6, f7, f8, f9, f10, f11, f12, f13, f14, f15), action);
        }
        public static Result<T> GetResult<T>(Func<int> f1, Func<int> f2, Func<int> f3, Func<int> f4, Func<int> f5, Func<int> f6, Func<int> f7, Func<int> f8, Func<int> f9, Func<int> f10, Func<int> f11, Func<int> f12, Func<int> f13, Func<int> f14, Func<int> f15, Func<T> func)
        {
            return GetResult(Check(f1, f2, f3, f4, f5, f6, f7, f8, f9, f10, f11, f12, f13, f14, f15), func);
        }
        public static Result GetResult(int resultState, Action action)
        {
            if (ResultState.Success != resultState) return new Result(resultState);
            action();
            return new Result();
        }
        public static Result<T> GetResult<T>(int resultState, Func<T> func)
        {
            return ResultState.Success == resultState ? new Result<T>(func()) : new Result<T>(resultState);
        }
        #endregion
        #region func返回Result
        public static Result GetResult(Func<int> checkFunc, Func<Result> func)
        {
            return GetResult(checkFunc(), func);
        }
        public static Result<T> GetResult<T>(Func<int> checkFunc, Func<Result<T>> func)
        {
            return GetResult(checkFunc(), func);
        }
        public static Result GetResult(Func<int> f1, Func<int> f2, Func<Result> func)
        {
            return GetResult(Check(f1, f2), func);
        }
        public static Result<T> GetResult<T>(Func<int> f1, Func<int> f2, Func<Result<T>> func)
        {
            return GetResult(Check(f1, f2), func);
        }
        public static Result GetResult(Func<int> f1, Func<int> f2, Func<int> f3, Func<Result> func)
        {
            return GetResult(Check(f1, f2, f3), func);
        }
        public static Result<T> GetResult<T>(Func<int> f1, Func<int> f2, Func<int> f3, Func<Result<T>> func)
        {
            return GetResult(Check(f1, f2, f3), func);
        }
        public static Result GetResult(Func<int> f1, Func<int> f2, Func<int> f3, Func<int> f4, Func<Result> func)
        {
            return GetResult(Check(f1, f2, f3, f4), func);
        }
        public static Result<T> GetResult<T>(Func<int> f1, Func<int> f2, Func<int> f3, Func<int> f4, Func<Result<T>> func)
        {
            return GetResult(Check(f1, f2, f3, f4), func);
        }
        public static Result GetResult(Func<int> f1, Func<int> f2, Func<int> f3, Func<int> f4, Func<int> f5, Func<Result> func)
        {
            return GetResult(Check(f1, f2, f3, f4, f5), func);
        }
        public static Result<T> GetResult<T>(Func<int> f1, Func<int> f2, Func<int> f3, Func<int> f4, Func<int> f5, Func<Result<T>> func)
        {
            return GetResult(Check(f1, f2, f3, f4, f5), func);
        }
        public static Result GetResult(Func<int> f1, Func<int> f2, Func<int> f3, Func<int> f4, Func<int> f5, Func<int> f6, Func<Result> func)
        {
            return GetResult(Check(f1, f2, f3, f4, f5, f6), func);
        }
        public static Result<T> GetResult<T>(Func<int> f1, Func<int> f2, Func<int> f3, Func<int> f4, Func<int> f5, Func<int> f6, Func<Result<T>> func)
        {
            return GetResult(Check(f1, f2, f3, f4, f5, f6), func);
        }
        public static Result GetResult(Func<int> f1, Func<int> f2, Func<int> f3, Func<int> f4, Func<int> f5, Func<int> f6, Func<int> f7, Func<Result> func)
        {
            return GetResult(Check(f1, f2, f3, f4, f5, f6, f7), func);
        }
        public static Result<T> GetResult<T>(Func<int> f1, Func<int> f2, Func<int> f3, Func<int> f4, Func<int> f5, Func<int> f6, Func<int> f7, Func<Result<T>> func)
        {
            return GetResult(Check(f1, f2, f3, f4, f5, f6, f7), func);
        }
        public static Result GetResult(Func<int> f1, Func<int> f2, Func<int> f3, Func<int> f4, Func<int> f5, Func<int> f6, Func<int> f7, Func<int> f8, Func<Result> func)
        {
            return GetResult(Check(f1, f2, f3, f4, f5, f6, f7, f8), func);
        }
        public static Result<T> GetResult<T>(Func<int> f1, Func<int> f2, Func<int> f3, Func<int> f4, Func<int> f5, Func<int> f6, Func<int> f7, Func<int> f8, Func<Result<T>> func)
        {
            return GetResult(Check(f1, f2, f3, f4, f5, f6, f7, f8), func);
        }
        public static Result GetResult(Func<int> f1, Func<int> f2, Func<int> f3, Func<int> f4, Func<int> f5, Func<int> f6, Func<int> f7, Func<int> f8, Func<int> f9, Func<Result> func)
        {
            return GetResult(Check(f1, f2, f3, f4, f5, f6, f7, f8, f9), func);
        }
        public static Result<T> GetResult<T>(Func<int> f1, Func<int> f2, Func<int> f3, Func<int> f4, Func<int> f5, Func<int> f6, Func<int> f7, Func<int> f8, Func<int> f9, Func<Result<T>> func)
        {
            return GetResult(Check(f1, f2, f3, f4, f5, f6, f7, f8, f9), func);
        }
        public static Result GetResult(Func<int> f1, Func<int> f2, Func<int> f3, Func<int> f4, Func<int> f5, Func<int> f6, Func<int> f7, Func<int> f8, Func<int> f9, Func<int> f10, Func<Result> func)
        {
            return GetResult(Check(f1, f2, f3, f4, f5, f6, f7, f8, f9, f10), func);
        }
        public static Result<T> GetResult<T>(Func<int> f1, Func<int> f2, Func<int> f3, Func<int> f4, Func<int> f5, Func<int> f6, Func<int> f7, Func<int> f8, Func<int> f9, Func<int> f10, Func<Result<T>> func)
        {
            return GetResult(Check(f1, f2, f3, f4, f5, f6, f7, f8, f9, f10), func);
        }
        public static Result GetResult(Func<int> f1, Func<int> f2, Func<int> f3, Func<int> f4, Func<int> f5, Func<int> f6, Func<int> f7, Func<int> f8, Func<int> f9, Func<int> f10, Func<int> f11, Func<Result> func)
        {
            return GetResult(Check(f1, f2, f3, f4, f5, f6, f7, f8, f9, f10, f11), func);
        }
        public static Result<T> GetResult<T>(Func<int> f1, Func<int> f2, Func<int> f3, Func<int> f4, Func<int> f5, Func<int> f6, Func<int> f7, Func<int> f8, Func<int> f9, Func<int> f10, Func<int> f11, Func<Result<T>> func)
        {
            return GetResult(Check(f1, f2, f3, f4, f5, f6, f7, f8, f9, f10, f11), func);
        }
        public static Result GetResult(Func<int> f1, Func<int> f2, Func<int> f3, Func<int> f4, Func<int> f5, Func<int> f6, Func<int> f7, Func<int> f8, Func<int> f9, Func<int> f10, Func<int> f11, Func<int> f12, Func<Result> func)
        {
            return GetResult(Check(f1, f2, f3, f4, f5, f6, f7, f8, f9, f10, f11, f12), func);
        }
        public static Result<T> GetResult<T>(Func<int> f1, Func<int> f2, Func<int> f3, Func<int> f4, Func<int> f5, Func<int> f6, Func<int> f7, Func<int> f8, Func<int> f9, Func<int> f10, Func<int> f11, Func<int> f12, Func<Result<T>> func)
        {
            return GetResult(Check(f1, f2, f3, f4, f5, f6, f7, f8, f9, f10, f11, f12), func);
        }
        public static Result GetResult(Func<int> f1, Func<int> f2, Func<int> f3, Func<int> f4, Func<int> f5, Func<int> f6, Func<int> f7, Func<int> f8, Func<int> f9, Func<int> f10, Func<int> f11, Func<int> f12, Func<int> f13, Func<Result> func)
        {
            return GetResult(Check(f1, f2, f3, f4, f5, f6, f7, f8, f9, f10, f11, f12, f13), func);
        }
        public static Result<T> GetResult<T>(Func<int> f1, Func<int> f2, Func<int> f3, Func<int> f4, Func<int> f5, Func<int> f6, Func<int> f7, Func<int> f8, Func<int> f9, Func<int> f10, Func<int> f11, Func<int> f12, Func<int> f13, Func<Result<T>> func)
        {
            return GetResult(Check(f1, f2, f3, f4, f5, f6, f7, f8, f9, f10, f11, f12, f13), func);
        }
        public static Result GetResult(Func<int> f1, Func<int> f2, Func<int> f3, Func<int> f4, Func<int> f5, Func<int> f6, Func<int> f7, Func<int> f8, Func<int> f9, Func<int> f10, Func<int> f11, Func<int> f12, Func<int> f13, Func<int> f14, Func<Result> func)
        {
            return GetResult(Check(f1, f2, f3, f4, f5, f6, f7, f8, f9, f10, f11, f12, f13, f14), func);
        }
        public static Result<T> GetResult<T>(Func<int> f1, Func<int> f2, Func<int> f3, Func<int> f4, Func<int> f5, Func<int> f6, Func<int> f7, Func<int> f8, Func<int> f9, Func<int> f10, Func<int> f11, Func<int> f12, Func<int> f13, Func<int> f14, Func<Result<T>> func)
        {
            return GetResult(Check(f1, f2, f3, f4, f5, f6, f7, f8, f9, f10, f11, f12, f13, f14), func);
        }
        public static Result GetResult(Func<int> f1, Func<int> f2, Func<int> f3, Func<int> f4, Func<int> f5, Func<int> f6, Func<int> f7, Func<int> f8, Func<int> f9, Func<int> f10, Func<int> f11, Func<int> f12, Func<int> f13, Func<int> f14, Func<int> f15, Func<Result> func)
        {
            return GetResult(Check(f1, f2, f3, f4, f5, f6, f7, f8, f9, f10, f11, f12, f13, f14, f15), func);
        }
        public static Result<T> GetResult<T>(Func<int> f1, Func<int> f2, Func<int> f3, Func<int> f4, Func<int> f5, Func<int> f6, Func<int> f7, Func<int> f8, Func<int> f9, Func<int> f10, Func<int> f11, Func<int> f12, Func<int> f13, Func<int> f14, Func<int> f15, Func<Result<T>> func)
        {
            return GetResult(Check(f1, f2, f3, f4, f5, f6, f7, f8, f9, f10, f11, f12, f13, f14, f15), func);
        }
        public static Result GetResult(int resultState, Func<Result> func)
        {
            return ResultState.Success == resultState ? func() : new Result(resultState);
        }
        public static Result<T> GetResult<T>(int resultState, Func<Result<T>> func)
        {
            return ResultState.Success == resultState ? func() : new Result<T>(resultState);
        }
        #endregion
        #endregion

        #region func from Source
        public static Result<TResult> GetResult<TSource, TResult>(TSource source, Func<TSource, TResult> func)
        {
            return new Result<TResult>(func(source));
        }
        public static Result<TResult[]> GetArrayResult<TSource, TResult>(TSource[] sources, Func<TSource, TResult> func)
        {
            return new Result<TResult[]>(sources.Select(func).ToArray());
        }
        public static Result<TResult> GetResult<TSource, TResult>(TSource source, Func<TSource, TResult> func, int state)
        {
            return ObjectExtends.EqualsDefault(source)
                ? new Result<TResult>(state)
                : new Result<TResult>(func(source));
        }
        public static Result<TResult[]> GetArrayResult<TSource, TResult>(TSource[] sources, Func<TSource, TResult> func, int state)
        {
            if (default(TSource[]) == sources) return new Result<TResult[]>(state);
            return new Result<TResult[]>(sources.Select(func).ToArray());
        }
        #endregion

        public static Result Create() { return new Result(); }
        public static Result<T> Create<T>(T t) { return new Result<T>(t); }
        public static Result<Tuple<T1, T2>> Create<T1, T2>(T1 t1, T2 t2) { return Create(Tuple.Create(t1, t2)); }
        public static Result<Tuple<T1, T2, T3>> Create<T1, T2, T3>(T1 t1, T2 t2, T3 t3) { return Create(Tuple.Create(t1, t2, t3)); }
        public static Result<Tuple<T1, T2, T3, T4>> Create<T1, T2, T3, T4>(T1 t1, T2 t2, T3 t3, T4 t4) { return Create(Tuple.Create(t1, t2, t3, t4)); }
        public static Result<Tuple<T1, T2, T3, T4, T5>> Create<T1, T2, T3, T4, T5>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5) { return Create(Tuple.Create(t1, t2, t3, t4, t5)); }
        public static Result<Tuple<T1, T2, T3, T4, T5, T6>> Create<T1, T2, T3, T4, T5, T6>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6) { return Create(Tuple.Create(t1, t2, t3, t4, t5, t6)); }
        public static Result<Tuple<T1, T2, T3, T4, T5, T6, T7>> Create<T1, T2, T3, T4, T5, T6, T7>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7) { return Create(Tuple.Create(t1, t2, t3, t4, t5, t6, t7)); }
        public static Result<Tuple<T1, T2, T3, T4, T5, T6, T7, Tuple<T8>>> Create<T1, T2, T3, T4, T5, T6, T7, T8>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8) { return Create(Tuple.Create(t1, t2, t3, t4, t5, t6, t7, t8)); }
    }
}