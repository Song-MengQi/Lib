using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Lib
{
    public static class StringExtend
    {
        public static int Count(this string str, Func<char, bool> func)
        {
            return str.ToCharArray().Count(func);
        }
        public static bool Any(this string str, Func<char, bool> func)
        {
            return str.ToCharArray().Any(func);
        }
        public static bool All(this string str, Func<char, bool> func)
        {
            return str.ToCharArray().All(func);
        }
        public static bool AnyWhiteSpace(this string str)
        {
            return str.Any(ch=>char.IsWhiteSpace(ch));
        }
        public static bool AllWhiteSpace(this string str)
        {
            return str.All(ch => char.IsWhiteSpace(ch));
        }
        public static bool All_zh(this string str)
        {
            return str.All(ch => ch.Is_zh());
        }
        public static bool AllDigit(this string d)
        {
            return d.All(ch => ch.IsDigit());
        }
        public static bool AllLetter(this string l)
        {
            return l.All(ch => ch.IsLetter());
        }
        public static bool AllSimpleChar(this string str)
        {
            return str.All(ch=>ch.IsSimpleChar());
        }
        public static bool AllHexNumber(this string x)
        {
            return x.All(ch=>ch.IsHexNumber());
        }
        public static bool IsInteger(this string i)
        {
            if (i.Length == 0) return false;
            return i.AllDigit();
        }
        public static bool IsSInteger(this string si)
        {
            if (si.Length == 0) return false;
            return ('-' == si[0] ? si.Substring(1) : si).AllDigit();
        }
        public static bool IsHexNumber(this string x)
        {
            if (x.Length == 0) return false;
            return x.AllHexNumber();
        }
        
        public static bool IsUlong(this string ul)
        {
            int maxUlongLength = 20;
            int length = ul.Length;
            if (length > maxUlongLength) return false;
            if (false == ul.IsInteger()) return false;
            if (length < maxUlongLength) return true;
            return ul.CompareTo(ulong.MaxValue.ToString()) < 1;
        }
        public static bool IsUint(this string ui)
        {
            int maxUintLength = 10;
            int length = ui.Length;
            if (length > maxUintLength) return false;
            if (false == ui.IsInteger()) return false;
            if (length < maxUintLength) return true;
            return ui.CompareTo(uint.MaxValue.ToString()) < 1;
        }
        public static bool IsUshort(this string us)
        {
            int maxUshortLength = 5;
            int length = us.Length;
            if (length > maxUshortLength) return false;
            if (false == us.IsInteger()) return false;
            if (length < maxUshortLength) return true;
            return us.CompareTo(ushort.MaxValue.ToString()) < 1;
        }
        public static bool IsByte(this string b)
        {
            int maxByteLength = 3;
            int length = b.Length;
            if (length > maxByteLength) return false;
            if (false == b.IsInteger()) return false;
            if (length < maxByteLength) return true;
            return b.CompareTo(byte.MaxValue.ToString()) < 1;
        }
        public static bool IsLong(this string l)
        {
            int maxLongLength = 20;
            int length = l.Length;
            if (length > maxLongLength) return false;
            if (false == l.IsSInteger()) return false;
            if (length < maxLongLength - 1) return true;
            try { long.Parse(l); }
            catch { return false; }
            return true;
        }
        public static bool IsInt(this string i)
        {
            int maxIntLength = 11;
            int length = i.Length;
            if (length > maxIntLength) return false;
            if (false == i.IsSInteger()) return false;
            if (length < maxIntLength -1) return true;
            try { int.Parse(i); }
            catch { return false; }
            return true;
        }
        public static bool IsShort(this string s)
        {
            int maxShortLength = 6;
            int length = s.Length;
            if (length > maxShortLength) return false;
            if (false == s.IsSInteger()) return false;
            if (length < maxShortLength - 1) return true;
            try { short.Parse(s); }
            catch { return false; }
            return true;
        }
        public static bool IsSbyte(this string sb)
        {
            int maxByteLength = 4;
            int length = sb.Length;
            if (length > maxByteLength) return false;
            if (false == sb.IsSInteger()) return false;
            if (length < maxByteLength - 1) return true;
            try { sbyte.Parse(sb); }
            catch { return false; }
            return true;
        }
        public static bool IsDecimal(this string d)
        {
            try { decimal.Parse(d); }
            catch { return false; }
            return true;
        }
        public static bool IsDouble(this string d)
        {
            try { double.Parse(d); }
            catch { return false; }
            return true;
        }
        public static bool IsFloat(this string f)
        {
            try { float.Parse(f); }
            catch { return false; }
            return true;
        }
        public static bool IsTrue(this string str)
        {
            return false == IsFalse(str);
        }
        public static bool IsFalse(this string str)
        {
            if (str.Length == 0) return true;
            str = str.Replace("0", "").Trim();
            if (str.Length == 0) return true;
            str = str.ToLower();
            return "f" == str || "false" == str;
        }
        public static bool IsBase64(this string base64)
        {
            int length = base64.Length;
            if (length == 0) return false;
            if ((length & 0x03) != 0) return false;//base64字符串长度必须是4的倍数
            string b64 = base64.TrimEnd('=');//=只能出现在结尾
            if (b64.Length + 2 < length) return false;//=的数量只能是0,1,2
            return b64.All(ch => ch.IsSimpleChar() || '/' == ch || '+' == ch);
            //return b64.All(ch => '/' <= ch && ch <= '9' || 'A' <= ch && ch <= 'Z' || 'a' <= ch && ch <= 'z' || '+' == ch);
            //foreach (var ch in b64)
            //{
            //    if ('/' <= ch && ch <= '9') continue;
            //    if ('A' <= ch && ch <= 'Z') continue;
            //    if ('a' <= ch && ch <= 'z') continue;
            //    if (ch == '+') continue;
            //    return false;
            //}
            //return true;
        }
        public static bool IsId(this string id)
        {
            if (id.Length > 19) return false;
            return id.IsInteger();
        }
        public static bool IsPositiveId(this string positiveId)
        {
            return positiveId.IsId() && ulong.Parse(positiveId) > 0ul;
        }
        public static bool IsEmail(this string email)
        {
            int length = email.Length;
            if (5 > length || 48 < length) return false;
            return Regex.IsMatch(email, @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
        }
        public static bool IsTel(this string tel)
        {
            //注释::只开放中国手机
            int length = tel.Length;
            if (11 != length) return false;
            if ('1' != tel[0]) return false;
            switch (tel[1])
            {
                case '3':
                case '4':
                case '5':
                case '7':
                case '8':
                    return tel.Substring(2).IsInteger();
            }
            return false;
            
            //return Regex.IsMatch(tel, @"^1[34578]\d{9}$");
            /*
            string telecom = @"^1[3578][01379]\d{8}$"; 
            string unicom = @"^1[34578][01256]\d{8}$";               
            string cmcc = @"^(134[012345678]\d{7}|1[34578][012356789]\d{8})$";        
            */
        }
        public static bool IsDate(this string date)
        {
            return date.ToFormatDateString() != string.Empty;
        }
        public static bool IsLanguageCode(this string languageCode)
        {
            int length = languageCode.Length;
            if (length > 5 ||length == 0) return false;
            return true;
        }
        public static bool IsDistrictCode(this string districtCode)
        {
            int length = districtCode.Length;
            if (length > 16 || length == 0) return false;
            if (districtCode.Contains(",")) return false;
            return true;
        }
        public static bool IsDistrictCodes(this string districtCodes)
        {
            return StringExtends.IsDistrictCodes(districtCodes.Split(','));
        }
        public static string[] Split(this string str, string separator, StringSplitOptions options = StringSplitOptions.RemoveEmptyEntries)
        {
            return str.Split(new string[] { separator }, options);
        }
        public static string ToFormatDateString(this string date)
        {
            if (date.Length == 0) return string.Empty;
            string[] strs = date.Split('-', ' ', '/');
            if (3 != strs.Length) return string.Empty;
            if (4 != strs[0].Length) return string.Empty;
            if (2 < strs[1].Length) return string.Empty;
            if (2 < strs[2].Length) return string.Empty;
            DateTime dateTime;
            if (false == DateTime.TryParse(date, out dateTime)) return string.Empty;
            //return dateTime.ToShortDateString();
            return dateTime.ToString("yyyy-MM-dd");
        }
        public static string ToUpperFirst(this string str)
        {
            if (str.Length == 0) return string.Empty;
            return char.ToUpper(str[0]) + str.Substring(1);
        }
        public static string ToLowerFirst(this string str)
        {
            if (str.Length == 0) return string.Empty;
            return char.ToLower(str[0]) + str.Substring(1);
        }
        public static string[] ToStrings(this string str, char separator = ',')
        {
            return str.Split(separator)
                .Where(s => false == string.IsNullOrWhiteSpace(s))
                .Select(s => s.Trim())
                .ToArray();
        }
        public static string[] ToStrings(this string str, string separator)
        {
            return str.Split(separator, StringSplitOptions.RemoveEmptyEntries)
                .Where(s => false == string.IsNullOrWhiteSpace(s))
                .Select(s => s.Trim())
                .ToArray();
        }
        public static byte[] ToBytes(this string str)
        {
            return str.ToStrings().Select(s => byte.Parse(s)).ToArray();
        }
        public static ulong[] ToUlongs(this string str)
        {
            return str.ToStrings().Select(s=>ulong.Parse(s)).ToArray();
        }
        public static byte ToBoolByte(this string str)
        {
            return str.IsTrue().ToByte();
        }
        public static string Trancate(this string str, int length=80, string suffix=""/*"..."*/)
        {
            if (length < suffix.Length) return str;//后缀比length还长，不截了
            return str.Length > length ? str.Substring(0, length - suffix.Length) + suffix : str;
        }
        public static string TrimOnceStart(this string str, string start)
        {
            return str.StartsWith(start) ? str.Substring(start.Length) : str;
        }
        public static string TrimOnceEnd(this string str, string end)
        {
            return str.EndsWith(end) ? str.Substring(0, str.Length - end.Length) : str;
        }
        public static string TrimOnce(this string str, string trimStr)
        {
            return str.TrimOnceStart(trimStr).TrimOnceEnd(trimStr);
        }
        public static string TrimStart(this string str, string start)
        {
            while (str.StartsWith(start)) str = str.Substring(start.Length);
            return str;
        }
        public static string TrimEnd(this string str, string end)
        {
            while (str.EndsWith(end)) str = str.Substring(0, str.Length - end.Length);
            return str;
        }
        public static string Trim(this string str, string trimStr)
        {
            return str.TrimStart(trimStr).TrimEnd(trimStr);
        }
        public static string Wrap(this string str, char start, char end)
        {
            return start + str.Trim().TrimStart(start).TrimEnd(end).Trim() + end;
        }
        public static string Wrap(this string str, string start, string end)
        {
            return start + str.Trim().TrimStart(start).TrimEnd(end).Trim() + end;
        }
        public static string WrapArray(this string str)
        {
            return str.Wrap('[', ']');
        }
        public static string WrapDic(this string str)
        {
            return str.Wrap('{', '}');
        }
        public static string AddPrefixIfNotNullOrEmpty(this string str, string prefix, string separator = "")
        {
            return string.IsNullOrEmpty(prefix)
                ? str
                : prefix + separator + str;
        }
        public static string AddSuffixIfNotNullOrEmpty(this string str, string suffix, string separator = "")
        {
            return string.IsNullOrEmpty(suffix)
                ? str
                : str + separator + suffix;
        }
        #region WithoutCheck
        public static string ToFormatDateTimeStringWithoutCheck(this string dateTime)
        {
            return DateTime.Parse(dateTime).ToString(DateTimeExtends.DateTimeFormat);
        }
        public static string ToFormatDateStringWithoutCheck(this string date)
        {
            return DateTime.Parse(date).ToString(DateTimeExtends.DateFormat);
        }
        #endregion
    }
}