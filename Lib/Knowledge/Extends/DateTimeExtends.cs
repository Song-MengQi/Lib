using System;

namespace Lib
{
    public static class DateTimeExtends
    {
        public const string DateFormat = "yyyy-MM-dd";
        public const string DateTimeFormat = "yyyy-MM-dd HH:mm:ss";
        public const string DateTime6Format = "yyyy-MM-dd HH:mm:ss.ffffff";
        public const string TimeFormat = "HH:mm:ss";
        public const string Time6Format = "HH:mm:ss ffffff";
        public const string DefaultDateTimeString = "0000-00-00 00:00:00";
        public const string DefaultDateTime6String = "0000-00-00 00:00:00.000000";
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
