using System;

namespace Lib
{
    public static class TimeSpanExtend
    {
        public static long ToSeconds(this TimeSpan timeSpan)
        {
            return timeSpan.Ticks / TimeSpan.TicksPerSecond;
        }
        public static long ToMinutes(this TimeSpan timeSpan)
        {
            return timeSpan.Ticks / TimeSpan.TicksPerMinute;
        }
        public static long ToHours(this TimeSpan timeSpan)
        {
            return timeSpan.Ticks / TimeSpan.TicksPerHour;
        }
        public static long ToDays(this TimeSpan timeSpan)
        {
            return timeSpan.Ticks / TimeSpan.TicksPerDay;
        }
    }
}