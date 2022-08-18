using System;

namespace Lib
{
    public static class ObjectExtends
    {
        public static bool EqualsDefault<T>(T t) { return object.Equals(default(T), t); }
        public static bool NotEqualsDefault<T>(T t) { return false == EqualsDefault<T>(t); }
        #region DefaultThen
        public static T DefaultThen<T>(T t, Func<T> func) { return EqualsDefault(t) ? func() : t; }
        public static T DefaultThen<T>(T t, T tThen) { return DefaultThen(t, ()=>tThen); }

        public static T DefaultThen<T>(T t) where T : new() { return DefaultThen(t, ()=>new T()); }
        public static IT DefaultThen<T, IT>(IT t) where T : IT, new() { return DefaultThen(t, ()=>new T()); }
        #endregion
        #region NotDefaultThen
        public static T NotDefaultThen<T>(T t, Func<T> func) { return EqualsDefault(t) ? t : func(); }
        public static T NotDefaultThen<T>(T t, T tThen) { return NotDefaultThen(t, () =>tThen); }

        public static T NotDefaultThen<T>(T t) where T : new() { return NotDefaultThen(t, ()=>new T()); }
        public static IT NotDefaultThen<T, IT>(IT t) where T : IT, new() { return NotDefaultThen(t, ()=>new T()); }
        #endregion
        //若失败则default，没有class限制
        public static T As<T>(object t)
        {
            try { return (T)t; }
            catch { return default(T); }
        }
    }
}