using System;

namespace Lib
{
    public static class ActionExtends
    {
        public static void Invoke(Action action)
        {
            if (default(Action) != action) action();
        }
        public static void Invoke<T>(Action<T> action, T t)
        {
            if (default(Action<T>) != action) action(t);
        }
        public static void Invoke<T1, T2>(Action<T1, T2> action, T1 t1, T2 t2)
        {
            if (default(Action<T1, T2>) != action) action(t1, t2);
        }
        public static void Invoke<T1, T2, T3>(Action<T1, T2, T3> action, T1 t1, T2 t2, T3 t3)
        {
            if (default(Action<T1, T2, T3>) != action) action(t1, t2, t3);
        }
        public static void Invoke<T1, T2, T3, T4>(Action<T1, T2, T3, T4> action, T1 t1, T2 t2, T3 t3, T4 t4)
        {
            if (default(Action<T1, T2, T3, T4>) != action) action(t1, t2, t3, t4);
        }
        public static void Invoke<T1, T2, T3, T4, T5>(Action<T1, T2, T3, T4, T5> action, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5)
        {
            if (default(Action<T1, T2, T3, T4, T5>) != action) action(t1, t2, t3, t4, t5);
        }
        public static void Invoke<T1, T2, T3, T4, T5, T6>(Action<T1, T2, T3, T4, T5, T6> action, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6)
        {
            if (default(Action<T1, T2, T3, T4, T5, T6>) != action) action(t1, t2, t3, t4, t5, t6);
        }
        public static void Invoke<T1, T2, T3, T4, T5, T6, T7>(Action<T1, T2, T3, T4, T5, T6, T7> action, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7)
        {
            if (default(Action<T1, T2, T3, T4, T5, T6, T7>) != action) action(t1, t2, t3, t4, t5, t6, t7);
        }
        public static void Invoke<T1, T2, T3, T4, T5, T6, T7, T8>(Action<T1, T2, T3, T4, T5, T6, T7, T8> action, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8)
        {
            if (default(Action<T1, T2, T3, T4, T5, T6, T7, T8>) != action) action(t1, t2, t3, t4, t5, t6, t7, t8);
        }
    }
}