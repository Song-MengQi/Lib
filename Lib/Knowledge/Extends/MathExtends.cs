using System;
using System.Linq;

namespace Lib
{
    public static class MathExtends
    {
        public static T Max<T>(params T[] source) { return source.Max(); }
        public static T Min<T>(params T[] source) { return source.Min(); }

        public static T Max<T>(T t1, T t2)
            where T : IComparable<T>
        {
            return t1.CompareTo(t2) > 0 ? t1 : t2;
        }
        public static T Min<T>(T t1, T t2)
            where T : IComparable<T>
        {
            return t1.CompareTo(t2) < 0 ? t1 : t2;
        }
        public static Range<T> Range<T>(T t1, T t2)
            where T : IComparable<T>
        {
            return new Range<T>(Min(t1, t2), Max(t1, t2));
        }
        #region Clip
        #region 这样实现太啰嗦
        //private static T Clip<T>(T t, T min, T max, Func<T, T, T> minFunc, Func<T, T, T> maxFunc) { return minFunc(maxFunc(t, min), max); }
        //public static sbyte Clip(sbyte t, sbyte min, sbyte max) { return Clip(t, min, max, Math.Min, Math.Max); }
        //public static byte Clip(byte t, byte min, byte max) { return Clip(t, min, max, Math.Min, Math.Max); }
        //public static short Clip(short t, short min, short max) { return Clip(t, min, max, Math.Min, Math.Max); }
        //public static ushort Clip(ushort t, ushort min, ushort max) { return Clip(t, min, max, Math.Min, Math.Max); }
        //public static int Clip(int t, int min, int max) { return Clip(t, min, max, Math.Min, Math.Max); }
        //public static uint Clip(uint t, uint min, uint max) { return Clip(t, min, max, Math.Min, Math.Max); }
        //public static long Clip(long t, long min, long max) { return Clip(t, min, max, Math.Min, Math.Max); }
        //public static ulong Clip(ulong t, ulong min, ulong max) { return Clip(t, min, max, Math.Min, Math.Max); }
        ////public static Single Clip(Single t, Single min, Single max) { return Clip(t, min, max, Math.Min, Math.Max); }
        //public static float Clip(float t, float min, float max) { return Clip(t, min, max, Math.Min, Math.Max); }
        //public static double Clip(double t, double min, double max) { return Clip(t, min, max, Math.Min, Math.Max); }
        //public static decimal Clip(decimal t, decimal min, decimal max) { return Clip(t, min, max, Math.Min, Math.Max); }
        #endregion
        public static T Clip<T>(T t, T min, T max)
            where T : IComparable<T>
        {
            return Min(Max(t, min), max);
        }
        public static T Clip<T>(T t, Range<T> range)
            where T : IComparable<T>
        {
            return Clip(t, range.Min, range.Max);
        }
        #endregion
        #region InRange
        //在开区间
        public static bool InRangeOpen<T>(T t, T min, T max)
            where T : IComparable<T>
        {
            return t.CompareTo(min) > 0 && t.CompareTo(max) < 0;
        }
        public static bool InRangeOpen<T>(T t, Range<T> range)
            where T : IComparable<T>
        {
            return InRangeOpen(t, range.Min, range.Max);
        }
        public static bool InRangeOpenX<T>(T t, T t1, T t2)
            where T : IComparable<T>
        {
            return InRangeOpen(t, Min(t1, t2), Max(t1, t2));
        }
        //在闭区间
        public static bool InRangeClose<T>(T t, T min, T max)
            where T : IComparable<T>
        {
            return t.CompareTo(min) >= 0 && t.CompareTo(max) <= 0;
        }
        public static bool InRangeClose<T>(T t, Range<T> range)
            where T : IComparable<T>
        {
            return InRangeClose(t, range.Min, range.Max);
        }
        public static bool InRangeCloseX<T>(T t, T t1, T t2)
            where T : IComparable<T>
        {
            return InRangeClose(t, Min(t1, t2), Max(t1, t2));
        }
        //在前开后闭区间
        public static bool InRangeOpenClose<T>(T t, T min, T max)
            where T : IComparable<T>
        {
            return t.CompareTo(min) > 0 && t.CompareTo(max) <= 0;
        }
        public static bool InRangeOpenClose<T>(T t, Range<T> range)
            where T : IComparable<T>
        {
            return InRangeOpenClose(t, range.Min, range.Max);
        }
        public static bool InRangeOpenCloseX<T>(T t, T t1, T t2)
            where T : IComparable<T>
        {
            return InRangeOpenClose(t, Min(t1, t2), Max(t1, t2));
        }
        //在前闭后开区间
        public static bool InRangeCloseOpen<T>(T t, T min, T max)
            where T : IComparable<T>
        {
            return t.CompareTo(min) >= 0 && t.CompareTo(max) < 0;
        }
        public static bool InRangeCloseOpen<T>(T t, Range<T> range)
            where T : IComparable<T>
        {
            return InRangeCloseOpen(t, range.Min, range.Max);
        }
        public static bool InRangeCloseOpenX<T>(T t, T t1, T t2)
            where T : IComparable<T>
        {
            return InRangeCloseOpen(t, Min(t1, t2), Max(t1, t2));
        }
        #endregion
        #region ToRangeString
        public static string ToRangeStringOpen(object min, object max)
        {
            return string.Format("({0},{1})", min, max);
        }
        public static string ToRangeStringClose(object min, object max)
        {
            return string.Format("[{0},{1}]", min, max);
        }
        public static string ToRangeStringOpenClose(object min, object max)
        {
            return string.Format("({0},{1}]", min, max);
        }
        public static string ToRangeStringCloseOpen(object min, object max)
        {
            return string.Format("[{0},{1})", min, max);
        }
        #endregion
        #region Angle
        public static double AngleToRadian(double x)
        {
            return x / 180d * Math.PI;
        }
        public static double RadianToAngle(double x)
        {
            return x * 180d / Math.PI;
        }
        #endregion
        #region DiscardAccuracy
        public static double DiscardAccuracy(double d, long l)
        {
            return Math.Round(d / l) * l;
        }
        //public static decimal DiscardAccuracy(decimal d, long l)
        //{
        //    return decimal.Round(d / l) * l;
        //}
        #endregion
        #region IEEERemainder
        public static double IEEERemainder(double x, double min, double max)
        {
            double period = max - min;
            double mid = (max + min) / 2;
            #region 发现上下限都能取到
            //return Math.IEEERemainder(x - mid, period) + mid;
            #endregion
            double result = Math.IEEERemainder(x - mid, period) + mid;
            return result == max ? min : result;
        }
        public static double IEEERemainder(double x, Range<double> range)
        {
            return IEEERemainder(x, range.Min, range.Max);
        }
        public static double IEEERemainderPositive(double x, double period)
        {
            return IEEERemainder(x, 0d, period);
        }
        #endregion
    }
}