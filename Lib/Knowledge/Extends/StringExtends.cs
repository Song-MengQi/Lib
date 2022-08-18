using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

namespace Lib
{
    #region 拓展方法的静态方法
    public static partial class StringExtends
    {
        public static int Count(string str, Func<char, bool> func)
        {
            if (default(string) == str) return 0;
            return str.Count(func);
        }
        public static bool Any(string str, Func<char, bool> func)
        {
            return default(string) != str && str.Any(func);
        }
        public static bool All(string str, Func<char, bool> func)
        {
            return default(string) != str && str.All(func);
        }
        public static bool AnyWhiteSpace(string str)
        {
            return default(string) != str && str.AnyWhiteSpace();
        }
        public static bool AllWhiteSpace(string str)
        {
            return default(string) != str && str.AllWhiteSpace();
        }
        public static bool All_zh(string str)
        {
            return default(string) != str && str.All_zh();
        }
        public static bool AllDigit(string str)
        {
            return default(string) != str && str.AllDigit();
        }
        public static bool AllLetter(string str)
        {
            return default(string) != str && str.AllLetter();
        }
        public static bool AllSimpleChar(string str)
        {
            return default(string) != str && str.AllSimpleChar();
        }
        public static bool AllHexNumber(string str)
        {
            return default(string) != str && str.AllHexNumber();
        }
        public static bool IsInteger(string str)
        {
            return default(string) != str && str.IsInteger();
        }
        public static bool IsSInteger(string str)
        {
            return default(string) != str && str.IsSInteger();
        }
        public static bool IsHexNumber(string str)
        {
            return default(string) != str && str.IsHexNumber();
        }
        public static bool IsUlong(string str)
        {
            return default(string) != str && str.IsUlong();
        }
        public static bool IsUint(string str)
        {
            return default(string) != str && str.IsUint();
        }
        public static bool IsUshort(string str)
        {
            return default(string) != str && str.IsUshort();
        }
        public static bool IsByte(string str)
        {
            return default(string) != str && str.IsByte();
        }
        public static bool IsLong(string str)
        {
            return default(string) != str && str.IsLong();
        }
        public static bool IsInt(string str)
        {
            return default(string) != str && str.IsInt();
        }
        public static bool IsShort(string str)
        {
            return default(string) != str && str.IsShort();
        }
        public static bool IsSbyte(string str)
        {
            return default(string) != str && str.IsSbyte();
        }
        public static bool IsDecimal(string str)
        {
            return default(string) != str && str.IsDecimal();
        }
        public static bool IsDouble(string str)
        {
            return default(string) != str && str.IsDouble();
        }
        public static bool IsFloat(string str)
        {
            return default(string) != str && str.IsFloat();
        }
        public static bool IsTrue(string str)
        {
            return default(string) != str && str.IsTrue();
        }
        public static bool IsFalse(string str)
        {
            return default(string) != str && str.IsFalse();
        }
        public static bool IsBase64(string str)
        {
            return default(string) != str && str.IsBase64();
        }
        public static bool IsId(string str)
        {
            return default(string) != str && str.IsId();
        }
        public static bool IsPositiveId(string str)
        {
            return default(string) != str && str.IsPositiveId();
        }
        public static bool IsEmail(string str)
        {
            return default(string) != str && str.IsEmail();
        }
        public static bool IsTel(string str)
        {
            return default(string) != str && str.IsTel();
        }
        public static bool IsDate(string str)
        {
            return default(string) != str && str.IsDate();
        }
        public static bool IsLanguageCode(string str)
        {
            return default(string) != str && str.IsLanguageCode();
        }
        public static bool IsDistrictCode(string str)
        {
            return default(string) != str && str.IsDistrictCode();
        }
        public static bool IsDistrictCodes(string str)
        {
            return default(string) != str && str.IsDistrictCodes();
        }
        public static bool IsDistrictCodes(string[] districtCodes)
        {
            if (default(string[]) == districtCodes) return false;
            int length = districtCodes.Length;
            if (length > 6 || length == 0) return false;
            int[] maxDistrictCodeLength = new int[] { 2, 6, 8, 10, 13, 16 };
            for (int i = 0; i < length; ++i)
            {
                if (string.IsNullOrWhiteSpace(districtCodes[i])) return false;
                int districtCodeLength = districtCodes[i].Length;
                if (districtCodeLength > maxDistrictCodeLength[i] || districtCodeLength == 0)
                    return false;
            }
            return true;
        }
        public static string[] Split(string str, string separator, StringSplitOptions options = StringSplitOptions.RemoveEmptyEntries)
        {
            return default(string) == str ? default(string[]) : str.Split(separator, options);
        }
        public static string ToFormatDateString(string str)
        {
            return default(string) == str ? string.Empty : str.ToFormatDateString();
        }
        public static string ToUpperFirst(string str)
        {
            return default(string) == str ? string.Empty : str.ToUpperFirst();
        }
        public static string ToLowerFirst(string str)
        {
            return default(string) == str ? string.Empty : str.ToLowerFirst();
        }
        public static string[] ToStrings(string str, char separator = ',')
        {
            return default(string) == str ? default(string[]) : str.ToStrings(separator);
        }
        public static string[] ToStrings(string str, string separator)
        {
            return default(string) == str ? default(string[]) : str.ToStrings(separator);
        }
        public static byte[] ToBytes(string str)
        {
            return default(string) == str ? default(byte[]) : str.ToBytes();
        }
        public static ulong[] ToUlongs(string str)
        {
            return default(string) == str ? default(ulong[]) : str.ToUlongs();
        }
        public static byte ToBoolByte(string str)
        {
            return default(string) == str ? (byte)0 : str.ToBoolByte();
        }
        public static string Trancate(string str, int length = 80, string suffix = ""/*"..."*/)
        {
            return default(string) == str ? string.Empty : str.Trancate(length, suffix);
        }
        public static string TrimOnceStart(string str, string start)
        {
            return default(string) == str ? string.Empty : str.TrimOnceStart(start);
        }
        public static string TrimOnceEnd(string str, string end)
        {
            return default(string) == str ? string.Empty : str.TrimOnceEnd(end);
        }
        public static string TrimOnce(string str, string trimStr)
        {
            return default(string) == str ? string.Empty : str.TrimOnce(trimStr);
        }
        public static string TrimStart(string str, string start)
        {
            return default(string) == str ? string.Empty : str.TrimStart(start);
        }
        public static string TrimEnd(string str, string end)
        {
            return default(string) == str ? string.Empty : str.TrimEnd(end);
        }
        public static string Trim(string str, string trimStr)
        {
            return default(string) == str ? string.Empty : str.Trim(trimStr);
        }
        public static string Wrap(string str, char start, char end)
        {
            return default(string) == str ? string.Empty : str.Wrap(start, end);
        }
        public static string Wrap(string str, string start, string end)
        {
            return default(string) == str ? string.Empty : str.Wrap(start, end);
        }
        public static string WrapArray(string str)
        {
            return default(string) == str ? string.Empty : str.WrapArray();
        }
        public static string WrapDic(string str)
        {
            return default(string) == str ? string.Empty : str.WrapDic();
        }
    }
    #endregion
    #region 静态方法
    public static partial class StringExtends
    {
        public static string Join<T>(char separator, IEnumerable<T> ts)
        {
            return string.Join(separator.ToString(), ts.Select(t => t.ToString()));
        }
        public static string Join<T>(IEnumerable<T> ts, string separator=",")
        {
            return string.Join(separator, ts.Select(t => t.ToString()));
        }
        #region QueryString
        public static string ToQueryString(IEnumerable<string> strs)
        {
            return string.Join("&", strs);
        }
        public static string ToQueryString(IDictionary<string, object> kvDictionary)
        {
            return string.Join("&", kvDictionary.Select(kv => kv.Key + "=" + kv.Value));
        }
        public static string ToQueryString(ListDictionary kvDictionary)
        {
            return string.Join("&", kvDictionary.Generalize().Select(kv => kv.Key + "=" + kv.Value));
        }
        public static string ToQueryString(string[] keys, object[] values)
        {
            return string.Join("&", ArrayExtends.GetArray(keys.Length, i => keys[i] + "=" + values[i]));
        }
        public static string ToQueryString(string url, string queryString)
        {
            return string.IsNullOrEmpty(queryString) ? url : url + "?" + queryString;
        }
        public static string ToQueryString(string url, IEnumerable<string> strs)
        {
            return ToQueryString(url, ToQueryString(strs));
        }
        public static string ToQueryString(string url, IDictionary<string, object> kvDictionary)
        {
            return ToQueryString(url, ToQueryString(kvDictionary));
        }
        public static string ToQueryString(string url, ListDictionary kvDictionary)
        {
            return ToQueryString(url, ToQueryString(kvDictionary));
        }
        public static string ToQueryString(string url, string[] keys, object[] values)
        {
            return ToQueryString(url, ToQueryString(keys, values));
        }
        #endregion

        #region KeyValues
        #region Dictionary<TKey, TValue>多接口实现取舍问题
        private static string KeyValues(IDictionary dic, Func<object, object, string> func)
        {
            return string.Concat(dic.Generalize().Select(kv => func(kv.Key, kv.Value)));
        }
        public static string KeyValues(ListDictionary dic, Func<object, object, string> func) { return KeyValues(dic as IDictionary, func); }
        public static string KeyValues<TKey, TValue>(ListDictionary<TKey, TValue> dic, Func<TKey, TValue, string> func) { return KeyValues(dic as IEnumerable<KeyValuePair<TKey, TValue>>, func); }
        #endregion
        public static string KeyValues<TKey, TValue>(IEnumerable<KeyValuePair<TKey, TValue>> kvs, Func<TKey, TValue, string> func)
        {
            return string.Concat(kvs.Select(kv => func(kv.Key, kv.Value)));
        }
        public static string KeyValues(object[] keys, object[] values, Func<object, object, string> func)
        {
            return string.Concat(ArrayExtends.GetArray(keys.Length, i => func(keys[i], values[i])));
        }
        #region Dictionary<TKey, TValue>多接口实现取舍问题
        private static string KeyValues(IDictionary dic, Func<object, object, string> func, string separator)
        {
            return string.Join(separator, dic.Generalize().Select(kv => func(kv.Key, kv.Value)));
        }
        public static string KeyValues(ListDictionary dic, Func<object, object, string> func, string separator) { return KeyValues(dic as IDictionary, func, separator); }
        public static string KeyValues<TKey, TValue>(ListDictionary<TKey, TValue> dic, Func<TKey, TValue, string> func, string separator) { return KeyValues(dic as IEnumerable<KeyValuePair<TKey, TValue>>, func, separator); }
        #endregion
        public static string KeyValues<TKey, TValue>(IEnumerable<KeyValuePair<TKey, TValue>> kvs, Func<TKey, TValue, string> func, string separator)
        {
            return string.Join(separator, kvs.Select(kv => func(kv.Key, kv.Value)));
        }
        public static string KeyValues(object[] keys, object[] values, Func<object, object, string> func, string separator)
        {
            return string.Join(separator, ArrayExtends.GetArray(keys.Length, i => func(keys[i], values[i])));
        }
        #endregion

        #region ip <=> x16
        public static string IpToX16(string ip)
        {
            return string.Concat(ip.Split('.').Select(str => byte.Parse(str).ToString("x2")));
        }
        public static string X16ToIp(string x16)
        {
            return string.Join(".", ArrayExtends.GetArray(4, i=>byte.Parse(x16.Substring(i << 1, 2), System.Globalization.NumberStyles.HexNumber).ToString()));
        }
        #endregion

        #region bytes <=> x16
        public static string BytesToX16(byte[] bytes, string format="x2")
        {
            return string.Concat(bytes.Select(b => b.ToString(format)));
        }
        public static byte[] X16ToBytes(string x16)
        {
            if ((x16.Length & 1) != 0) return default(byte[]);//如果是奇数个
            //return ArrayExtends.GetArray((x16.Length + 1) >> 1, i=>byte.Parse(x16.Substring(i << 1, 2), System.Globalization.NumberStyles.HexNumber));
            return ArrayExtends.GetArray(x16.Length >> 1, i=>byte.Parse(x16.Substring(i << 1, 2), System.Globalization.NumberStyles.HexNumber));        
        }
        #endregion

        #region asciiString <=> bytes
        public static byte[] AsciiStringToBytes(string str)
        {
            return str.Select(ch => (byte)ch).ToArray();
        }
        public static string BytesToAsciiString(byte[] bytes)
        {
            return new string(bytes.Select(b => (char)b).ToArray());
        }
        #endregion

        #region string <=> bytes
        public static byte[] StringToBytes(string str)
        {
            return Encodings.UTF8.GetBytes(str);
        }
        public static string BytesToString(byte[] bytes)
        {
            return Encodings.UTF8.GetString(bytes);
        }
        #endregion
        #region Base64
        public static string Base64Encode(string str)
        {
            return ConvertExtends.ToBase64String(StringToBytes(str));
        }
        public static string Base64Decode(string str)
        {
            return BytesToString(ConvertExtends.FromBase64String(str));
        }
        public static bool TryBase64Decode(string str, out string result)
        {
            try { result = Base64Decode(str); }
            catch
            {
                result = default(string);
                return false;
            }
            return true;
        }
        #endregion
    }
    #endregion
}