using System;

namespace Lib.Timer
{
    public class TimingOptions
    {
        //public int Year { get; set; }//也没有精确到某年的场景
        public int Month { get; set; }
        public int Day { get; set; }
        public int DayOfWeek { get; set; }
        public int Hour { get; set; }
        public int Minute { get; set; }
        public int Second { get; set; }
        //public int Millisecond { get; set; }//不支持这么精细的限制
        public TimingOptions()
        {
            Month = Day = DayOfWeek = Hour = Minute = Second = -1;//-1表示不限制
        }
    }
    public static class TimingOptionsExtends
    {
        public static TimeSpan GetPeriod(this TimingOptions timingOptions)
        {
            if (timingOptions.Second != -1) return Config.Instance.PeriodDuration;
            if (timingOptions.Minute != -1) return TimeSpan.FromSeconds(1d);
            if (timingOptions.Hour != -1) return TimeSpan.FromMinutes(1d);
            if (timingOptions.DayOfWeek != -1) return TimeSpan.FromHours(1d);
            if (timingOptions.Day != -1) return TimeSpan.FromHours(1d);
            if (timingOptions.Month != -1) return TimeSpan.FromDays(1d);
            return Config.Instance.PeriodDuration;
        }
        public static TimeSpan GetCoolingTime(this TimingOptions timingOptions)
        {
            if (timingOptions.Month != -1) return TimeSpan.FromDays(365d);
            if (timingOptions.Day != -1) return TimeSpan.FromDays(28d);
            if (timingOptions.DayOfWeek != -1) return TimeSpan.FromDays(7d);
            if (timingOptions.Hour != -1) return TimeSpan.FromDays(1d);
            if (timingOptions.Minute != -1) return TimeSpan.FromHours(1d);
            if (timingOptions.Second != -1) return TimeSpan.FromMinutes(1d);
            return TimeSpan.FromSeconds(1d);
        }
        public static bool Meet(this TimingOptions timingOptions, DateTime dateTime)
        {
            Func<int, int, bool> meetFunc = (due, now) => due == -1 || due == now;
            return //meetFunc(dateTimeOptions.Year, dateTime.Year) &&
                meetFunc(timingOptions.Month, dateTime.Month) &&
                meetFunc(timingOptions.DayOfWeek, (int)dateTime.DayOfWeek) &&
                meetFunc(timingOptions.Day, dateTime.Day) &&
                meetFunc(timingOptions.Hour, dateTime.Hour) &&
                meetFunc(timingOptions.Minute, dateTime.Minute) &&
                meetFunc(timingOptions.Second, dateTime.Second);
        }
    }
}
