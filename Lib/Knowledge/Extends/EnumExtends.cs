using System;

namespace Lib
{
    public static class EnumExtends
    {
        public static TEnum Parse<TEnum>(string str)
            where TEnum : struct
        {
            TEnum t;
            if (Enum.TryParse<TEnum>(str, true, out t)) return t;
            return default(TEnum);
        }
        public static TEnum ToObject<TEnum>(int i)
        {
            if (Enum.IsDefined(typeof(TEnum), i)) return (TEnum)Enum.ToObject(typeof(TEnum), i);
            return default(TEnum);
        }
        public static TEnum ToObject<TEnum>(string str)
        {
            return StringExtends.IsInt(str) ? ToObject<TEnum>(int.Parse(str)) : default(TEnum);
        }
        public static bool IsDefined<TEnum>(int i)
        {
            return Enum.IsDefined(typeof(TEnum), i);
        }
        public static bool IsDefined<TEnum>(string str)
        {
            return StringExtends.IsInt(str) && Enum.IsDefined(typeof(TEnum), int.Parse(str));
        }
    }
}