using System;

namespace Lib
{
    public class TryOptions
    {
        public int Times { get; set; }
        public Action<Exception> CatchAction { get; set; }
        public TryOptions()
        {
            Times = 1;
            CatchAction = TryExtends.DefaultCatchAction;
        }
    }
    public class TryOptions<T> : TryOptions
    {
        public Func<T> DefaultFunc { get; set; }
    }
    public static class TryExtends
    {
        public static Action<Exception> DefaultCatchAction { get; set; }
        public static bool Try(Action action, TryOptions tryOptions = default(TryOptions))
        {
            if (default(TryOptions) == tryOptions) tryOptions = new TryOptions();
            int tryTimes = tryOptions.Times;
            if (tryTimes < 0) tryTimes = int.MaxValue;
            for (int i = 0; i < tryTimes; ++i)
            {
                try { action(); return true; }
                catch (Exception exception) { ActionExtends.Invoke(tryOptions.CatchAction, exception); }
            }
            return false;
        }
        public static bool Try(Action action, int times) { return Try(action, new TryOptions { Times = times }); }
        public static bool Try<T>(Func<T> func, out T t, TryOptions<T> tryOptions = default(TryOptions<T>))
        {
            if (default(TryOptions<T>) == tryOptions) tryOptions = new TryOptions<T>();
            T temp = default(T);
            bool result = Try(()=>temp=func(), tryOptions);
            t = result ? temp : FuncExtends.Invoke(tryOptions.DefaultFunc);
            return result;
        }
        public static bool Try<T>(Func<T> func, out T t, int times) { return Try(func, out t, new TryOptions<T> { Times = times }); }
        public static void Invoke(Action action, TryOptions tryOptions = default(TryOptions))
        {
            Try(action, tryOptions);
        }
        public static void Invoke(Action action, int times) { Invoke(action, new TryOptions { Times = times }); }
        public static T Invoke<T>(Func<T> func, TryOptions<T> tryOptions = default(TryOptions<T>))
        {
            //T t = default(T);
            //Try(()=>t=func(), tryOptions);
            //return t;
            T t = default(T);
            Try(func, out t, tryOptions);
            return t;
        }
        public static T Invoke<T>(Func<T> func, int times) { return Invoke(func, new TryOptions<T> { Times = times }); }
    }
}