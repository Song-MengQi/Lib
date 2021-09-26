using System;

namespace Lib
{
    public static class ObjectExtends
    {
        public static bool EqualsDefault<T>(T t) { return object.Equals(default(T), t); }
        public static T DefaultThen<T>(T t, Func<T> func) { return EqualsDefault(t) ? func() : t; }
        public static T DefaultThen<T>(T t, T tThen) { return DefaultThen(t, () => tThen); }

        public static T DefaultThen<T>(T t) where T : new() { return DefaultThen(t, () => new T()); }
        public static IT DefaultThen<T, IT>(IT t) where T : IT, new() { return DefaultThen(t, ()=>new T()); }
    }
}