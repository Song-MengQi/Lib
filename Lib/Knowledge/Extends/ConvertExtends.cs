using System;

namespace Lib
{
    public static class ConvertExtends
    {
        public static T ChangeType<T>(object obj)
        {
            return (T)Convert.ChangeType(obj, typeof(T));
        }

        private static object Negate(Type type, object t)
        {
            if (typeof(sbyte) == type) return -ChangeType<sbyte>(t);
            if (typeof(short) == type) return -ChangeType<short>(t);
            if (typeof(int) == type) return -ChangeType<int>(t);
            if (typeof(long) == type) return -ChangeType<long>(t);
            if (typeof(float) == type) return -ChangeType<float>(t);
            if (typeof(double) == type) return -ChangeType<double>(t);
            if (typeof(decimal) == type) return -ChangeType<decimal>(t);
            return default(object);
        }
        public static T Negate<T>(T t)
        {
            return ChangeType<T>(Negate(typeof(T), t));
        }

        private static object Add(Type type, object t1, object t2)
        {
            if (typeof(byte) == type) return ChangeType<byte>(t1) + ChangeType<byte>(t2);
            if (typeof(sbyte) == type) return ChangeType<sbyte>(t1) + ChangeType<sbyte>(t2);
            if (typeof(ushort) == type) return ChangeType<ushort>(t1) + ChangeType<ushort>(t2);
            if (typeof(short) == type) return ChangeType<short>(t1) + ChangeType<short>(t2);
            if (typeof(uint) == type) return ChangeType<uint>(t1) + ChangeType<uint>(t2);
            if (typeof(int) == type) return ChangeType<int>(t1) + ChangeType<int>(t2);
            if (typeof(ulong) == type) return ChangeType<ulong>(t1) + ChangeType<ulong>(t2);
            if (typeof(long) == type) return ChangeType<long>(t1) + ChangeType<long>(t2);
            if (typeof(float) == type) return ChangeType<float>(t1) + ChangeType<float>(t2);
            if (typeof(double) == type) return ChangeType<double>(t1) + ChangeType<double>(t2);
            if (typeof(decimal) == type) return ChangeType<decimal>(t1) + ChangeType<decimal>(t2);
            return default(object);
        }
        public static T Add<T>(T t1, T t2)
        {
            return ChangeType<T>(Add(typeof(T), t1, t2));
        }

        private static object Subtract(Type type, object t1, object t2)
        {
            if (typeof(byte) == type) return ChangeType<byte>(t1) - ChangeType<byte>(t2);
            if (typeof(sbyte) == type) return ChangeType<sbyte>(t1) - ChangeType<sbyte>(t2);
            if (typeof(ushort) == type) return ChangeType<ushort>(t1) - ChangeType<ushort>(t2);
            if (typeof(short) == type) return ChangeType<short>(t1) - ChangeType<short>(t2);
            if (typeof(uint) == type) return ChangeType<uint>(t1) - ChangeType<uint>(t2);
            if (typeof(int) == type) return ChangeType<int>(t1) - ChangeType<int>(t2);
            if (typeof(ulong) == type) return ChangeType<ulong>(t1) - ChangeType<ulong>(t2);
            if (typeof(long) == type) return ChangeType<long>(t1) - ChangeType<long>(t2);
            if (typeof(float) == type) return ChangeType<float>(t1) - ChangeType<float>(t2);
            if (typeof(double) == type) return ChangeType<double>(t1) - ChangeType<double>(t2);
            if (typeof(decimal) == type) return ChangeType<decimal>(t1) - ChangeType<decimal>(t2);
            return default(object);
        }
        public static T Subtract<T>(T t1, T t2)
        {
            return ChangeType<T>(Subtract(typeof(T), t1, t2));
        }

        public static T Multiply<T>(T t, double d)
        {
            return ChangeType<T>(ChangeType<double>(t) * d);
        }
        public static T Multiply<T>(T t, decimal d)
        {
            return ChangeType<T>(ChangeType<decimal>(t) * d);
        }
        public static T Divide<T>(T t, double d)
        {
            return ChangeType<T>(ChangeType<double>(t) / d);
        }
        public static T Divide<T>(T t, decimal d)
        {
            return ChangeType<T>(ChangeType<decimal>(t) / d);
        }

        public static Result ConvertStateToResult(int state)
        {
            return new Result(state);
        }
        public static Func<Result> ConvertStateToResult(Func<int> func)
        {
            return default(Func<int>)==func ? default(Func<Result>) : ()=>new Result(func());
        }

        public static string ToBase64String(byte[] bytes)
        {
            return Convert.ToBase64String(bytes).Replace('+', '-').Replace('/', '_').Replace('=', '*');
        }
        public static byte[] FromBase64String(string str)
        {
            return Convert.FromBase64String(str.Replace('*', '=').Replace('_', '/').Replace('-', '+'));
        }
    }
}