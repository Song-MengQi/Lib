using System;

namespace Lib
{
    public static class FuncExtends
    {
        public static TResult Invoke<TResult>(Func<TResult> func)
        {
            return default(Func<TResult>) == func ? default(TResult) : func();
        }
        public static TResult Invoke<T, TResult>(Func<T, TResult> func, T t)
        {
            return default(Func<T, TResult>) == func ? default(TResult) : func(t);
        }
        public static TResult Invoke<T1, T2, TResult>(Func<T1, T2, TResult> func, T1 t1, T2 t2)
        {
            return default(Func<T1, T2, TResult>) == func ? default(TResult) : func(t1, t2);
        }
        public static TResult Invoke<T1, T2, T3, TResult>(Func<T1, T2, T3, TResult> func, T1 t1, T2 t2, T3 t3)
        {
            return default(Func<T1, T2, T3, TResult>) == func ? default(TResult) : func(t1, t2, t3);
        }
        public static TResult Invoke<T1, T2, T3, T4, TResult>(Func<T1, T2, T3, T4, TResult> func, T1 t1, T2 t2, T3 t3, T4 t4)
        {
            return default(Func<T1, T2, T3, T4, TResult>) == func ? default(TResult) : func(t1, t2, t3, t4);
        }
        public static TResult Invoke<T1, T2, T3, T4, T5, TResult>(Func<T1, T2, T3, T4, T5, TResult> func, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5)
        {
            return default(Func<T1, T2, T3, T4, T5, TResult>) == func ? default(TResult) : func(t1, t2, t3, t4, t5);
        }
        public static TResult Invoke<T1, T2, T3, T4, T5, T6, TResult>(Func<T1, T2, T3, T4, T5, T6, TResult> func, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6)
        {
            return default(Func<T1, T2, T3, T4, T5, T6, TResult>) == func ? default(TResult) : func(t1, t2, t3, t4, t5, t6);
        }
        public static TResult Invoke<T1, T2, T3, T4, T5, T6, T7, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, TResult> func, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7)
        {
            return default(Func<T1, T2, T3, T4, T5, T6, T7, TResult>) == func ? default(TResult) : func(t1, t2, t3, t4, t5, t6, t7);
        }
        public static TResult Invoke<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> func, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8)
        {
            return default(Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult>) == func ? default(TResult) : func(t1, t2, t3, t4, t5, t6, t7, t8);
        }
    }
}