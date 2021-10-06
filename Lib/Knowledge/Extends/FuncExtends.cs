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
        public static TResult Invoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> func, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9)
        {
            return default(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>) == func ? default(TResult) : func(t1, t2, t3, t4, t5, t6, t7, t8, t9);
        }
        public static TResult Invoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> func, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10)
        {
            return default(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>) == func ? default(TResult) : func(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10);
        }
        public static TResult Invoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> func, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11)
        {
            return default(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>) == func ? default(TResult) : func(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11);
        }
        public static TResult Invoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> func, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12)
        {
            return default(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>) == func ? default(TResult) : func(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12);
        }
        public static TResult Invoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> func, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13)
        {
            return default(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>) == func ? default(TResult) : func(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13);
        }
        public static TResult Invoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> func, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14)
        {
            return default(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>) == func ? default(TResult) : func(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14);
        }
        public static TResult Invoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> func, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12, T13 t13, T14 t14, T15 t15)
        {
            return default(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>) == func ? default(TResult) : func(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15);
        }
    }
}