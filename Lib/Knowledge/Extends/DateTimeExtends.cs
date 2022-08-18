using System;

namespace Lib
{
    public static class DateTimeExtends
    {
        public const string DateFormat = "yyyy-MM-dd";
        public const string TimeFormat = "HH:mm:ss";//注意：TimeSpan用它会报错，应该用"hh\:mm\:ss"
        public const string Time6Format = "HH:mm:ss.ffffff";
        public static string DateTimeFormat { get { return string.Join(" ", DateFormat, TimeFormat); } }
        public static string DateTime6Format { get { return string.Join(" ", DateFormat, Time6Format); } }

        public const string DefaultDateString = "0000-00-00";
        public const string DefaultTimeString = "00:00:00";
        public const string DefaultTime6String = "00:00:00.000000";
        public static string DefaultDateTimeString { get { return string.Join(" ", DefaultDateString, DefaultTimeString); } }
        public static string DefaultDateTime6String { get { return string.Join(" ", DefaultDateString, DefaultTime6String); } }
        public static string GetNowDateString()
        {
            return DateTime.Today.ToString(DateFormat);
        }
        public static string GetNowDateTimeString()
        {
            return DateTime.Now.ToString(DateTimeFormat);
        }
        public static string GetNowDateTime6String()
        {
            return DateTime.Now.ToString(DateTime6Format);
        }
        public static string GetNowTimeString()
        {
            return DateTime.Now.ToString(TimeFormat);
        }
        public static string GetNowTime6String()
        {
            return DateTime.Now.ToString(Time6Format);
        }
        public static string GetYesterdayDateString()
        {
            return DateTime.Today.AddDays(-1).ToString(DateFormat);
        }
    }
}
