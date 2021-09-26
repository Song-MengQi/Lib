using System;

namespace Lib
{
    public static class DateTimeExtend
    {
        public static long GetMillisecond(this DateTime dateTime) { return dateTime.Ticks / TimeSpan.TicksPerMillisecond; }
    }
}