using Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace Test.Lib
{
    [TestClass]
    public class StringExtendsTest : TestBase
    {
        #region 拓展方法的静态方法
        [TestMethod]
        public void TestCount()
        {
            Assert.AreEqual(StringExtends.Count(default(string), default(Func<char, bool>)), 0);
            Assert.AreEqual(StringExtends.Count(default(string), ch => true), 0);
            Assert.AreEqual(StringExtends.Count("1", ch => true), 1);
        }
        [TestMethod]
        public void TestAny()
        {
            Assert.IsFalse(StringExtends.Any(default(string), default(Func<char, bool>)));
            Assert.IsFalse(StringExtends.Any(default(string), ch=>true));
            Assert.IsTrue(StringExtends.Any("1", ch=>true));
        }
        [TestMethod]
        public void TestAll()
        {
            Assert.IsFalse(StringExtends.All(default(string), default(Func<char, bool>)));
            Assert.IsFalse(StringExtends.All(default(string), ch=>true));
            Assert.IsTrue(StringExtends.All("1", ch=>true));
        }
        [TestMethod]
        public void TestAnyWhiteSpace()
        {
            Assert.IsFalse(StringExtends.AnyWhiteSpace(default(string)));
            Assert.IsTrue(StringExtends.AnyWhiteSpace(" "));
        }
        [TestMethod]
        public void TestAllWhiteSpace()
        {
            Assert.IsFalse(StringExtends.AllWhiteSpace(default(string)));
            Assert.IsTrue(StringExtends.AllWhiteSpace("  "));
        }
        [TestMethod]
        public void TestAll_zh()
        {
            Assert.IsFalse(StringExtends.All_zh(default(string)));
            Assert.IsTrue(StringExtends.All_zh("是"));
        }
        [TestMethod]
        public void TestAllDigit()
        {
            Assert.IsFalse(StringExtends.AllDigit(default(string)));
            Assert.IsTrue(StringExtends.AllDigit("1"));
        }
        [TestMethod]
        public void TestAllLetter()
        {
            Assert.IsFalse(StringExtends.AllLetter(default(string)));
            Assert.IsTrue(StringExtends.AllLetter("a"));
        }
        [TestMethod]
        public void TestAllSimpleChar()
        {
            Assert.IsFalse(StringExtends.AllSimpleChar(default(string)));
            Assert.IsTrue(StringExtends.AllSimpleChar("a"));
        }
        [TestMethod]
        public void TestAllHexNumber()
        {
            Assert.IsFalse(StringExtends.AllHexNumber(default(string)));
            Assert.IsTrue(StringExtends.AllHexNumber("a"));
        }
        [TestMethod]
        public void TestIsInteger()
        {
            Assert.IsFalse(StringExtends.IsInteger(default(string)));
            Assert.IsTrue(StringExtends.IsInteger("1"));
        }
        [TestMethod]
        public void TestIsSInteger()
        {
            Assert.IsFalse(StringExtends.IsSInteger(default(string)));
            Assert.IsTrue(StringExtends.IsSInteger("1"));
        }
        [TestMethod]
        public void TestIsHexNumber()
        {
            Assert.IsFalse(StringExtends.IsHexNumber(default(string)));
            Assert.IsFalse(StringExtends.IsHexNumber(string.Empty));
        }
        [TestMethod]
        public void TestIsUlong()
        {
            Assert.IsFalse(StringExtends.IsUlong(default(string)));
            Assert.IsTrue(StringExtends.IsUlong("1"));
        }
        [TestMethod]
        public void TestIsUint()
        {
            Assert.IsFalse(StringExtends.IsUint(default(string)));
            Assert.IsTrue(StringExtends.IsUint("1"));
        }
        [TestMethod]
        public void TestIsUshort()
        {
            Assert.IsFalse(StringExtends.IsUshort(default(string)));
            Assert.IsTrue(StringExtends.IsUshort("1"));
        }
        [TestMethod]
        public void TestIsByte()
        {
            Assert.IsFalse(StringExtends.IsByte(default(string)));
            Assert.IsTrue(StringExtends.IsByte("1"));
        }
        [TestMethod]
        public void TestIsLong()
        {
            Assert.IsFalse(StringExtends.IsLong(default(string)));
            Assert.IsTrue(StringExtends.IsLong("1"));
        }
        [TestMethod]
        public void TestIsInt()
        {
            Assert.IsFalse(StringExtends.IsInt(default(string)));
            Assert.IsTrue(StringExtends.IsInt("1"));
        }
        [TestMethod]
        public void TestIsShort()
        {
            Assert.IsFalse(StringExtends.IsShort(default(string)));
            Assert.IsTrue(StringExtends.IsShort("1"));
        }
        [TestMethod]
        public void TestIsSbyte()
        {
            Assert.IsFalse(StringExtends.IsSbyte(default(string)));
            Assert.IsTrue(StringExtends.IsSbyte("1"));
        }
        [TestMethod]
        public void TestIsDecimal()
        {
            Assert.IsFalse(StringExtends.IsDecimal(default(string)));
            Assert.IsTrue(StringExtends.IsDecimal("1"));
        }
        [TestMethod]
        public void TestIsDouble()
        {
            Assert.IsFalse(StringExtends.IsDouble(default(string)));
            Assert.IsTrue(StringExtends.IsDouble("1"));
        }
        [TestMethod]
        public void TestIsIsFloat()
        {
            Assert.IsFalse(StringExtends.IsFloat(default(string)));
            Assert.IsTrue(StringExtends.IsFloat("1"));
        }
        [TestMethod]
        public void TestIsTrue()
        {
            Assert.IsFalse(StringExtends.IsTrue(default(string)));
            Assert.IsTrue(StringExtends.IsTrue("1"));
        }
        [TestMethod]
        public void TestIsFalse()
        {
            Assert.IsFalse(StringExtends.IsFalse(default(string)));
            Assert.IsTrue(StringExtends.IsFalse("0"));
        }
        [TestMethod]
        public void TestIsBase64()
        {
            Assert.IsFalse(StringExtends.IsBase64(default(string)));
            Assert.IsTrue(StringExtends.IsBase64("abcd"));
        }
        [TestMethod]
        public void TestIsId()
        {
            Assert.IsFalse(StringExtends.IsId(default(string)));
            Assert.IsTrue(StringExtends.IsId("1"));
        }
        [TestMethod]
        public void TestIsPositiveId()
        {
            Assert.IsFalse(StringExtends.IsPositiveId(default(string)));
            Assert.IsTrue(StringExtends.IsPositiveId("1"));
        }
        [TestMethod]
        public void TestIsEmail()
        {
            Assert.IsFalse(StringExtends.IsEmail(default(string)));
            Assert.IsTrue(StringExtends.IsEmail("fengshiqibie@hotmail.com"));
        }
        [TestMethod]
        public void TestIsTel()
        {
            Assert.IsFalse(StringExtends.IsTel(default(string)));
            Assert.IsTrue(StringExtends.IsTel("15001270050"));
        }
        [TestMethod]
        public void TestIsDate()
        {
            Assert.IsFalse(StringExtends.IsDate(default(string)));
            Assert.IsTrue(StringExtends.IsDate("2018-11-16"));
        }
        [TestMethod]
        public void TestIsLanguageCode()
        {
            Assert.IsFalse(StringExtends.IsLanguageCode(default(string)));
            Assert.IsTrue(StringExtends.IsLanguageCode("zh-CN"));
        }
        [TestMethod]
        public void TestIsDistrictCode()
        {
            Assert.IsFalse(StringExtends.IsDistrictCode(default(string)));
            Assert.IsTrue(StringExtends.IsDistrictCode("CN"));
        }
        [TestMethod]
        public void TestIsDistrictCodes()
        {
            string str;
            str = default(string);
            Assert.IsFalse(StringExtends.IsDistrictCodes(str));
            str = "123456789012345678901234567890123";
            Assert.IsFalse(StringExtends.IsDistrictCodes(str));
            str = "CN,CN-37,CN-3706";
            Assert.IsTrue(StringExtends.IsDistrictCodes(str));

            string[] strs;
            strs = default(string[]);
            Assert.IsFalse(StringExtends.IsDistrictCodes(strs));

            strs = new string[] { "1", "2", "3", "4", "5", "6", "7" };
            Assert.IsFalse(StringExtends.IsDistrictCodes(strs));

            strs = new string[] { "12", "123456", "12345678", "1234567890", "1234567890123", "1234567890123456" };
            Assert.IsTrue(StringExtends.IsDistrictCodes(strs));

            strs = new string[] { "12", "123456", "12345678", "1234567890" };
            Assert.IsTrue(StringExtends.IsDistrictCodes(strs));

            strs = new string[] { "123456", "12345678", "1234567890", "1234567890123", "1234567890123456" };
            Assert.IsFalse(StringExtends.IsDistrictCodes(strs));
        }
        [TestMethod]
        public void TestSplit()
        {
            string[] strs;
            string str;

            str = default(string);
            strs = StringExtends.Split(str, ",");
            Assert.AreEqual(strs, default(string[]));

            str = "";
            strs = StringExtends.Split(str, ",");
            Assert.AreEqual(strs.Length, 0);
        }
        [TestMethod]
        public void TestToFormatDateString()
        {
            Assert.AreEqual(StringExtends.ToFormatDateString(default(string)), string.Empty);
            Assert.AreEqual(StringExtends.ToFormatDateString(""), string.Empty);
        }
        [TestMethod]
        public void TestToUpperFirst()
        {
            Assert.AreEqual(StringExtends.ToUpperFirst(default(string)), string.Empty);
            Assert.AreEqual(StringExtends.ToUpperFirst("a"), "A");
        }
        [TestMethod]
        public void TestToLowerFirst()
        {
            Assert.AreEqual(StringExtends.ToLowerFirst(default(string)), string.Empty);
            Assert.AreEqual(StringExtends.ToLowerFirst("A"), "a");
        }
        [TestMethod]
        public void TestToStrings()
        {
            string[] strs;
            string str;

            str = default(string);
            strs = StringExtends.ToStrings(str);
            Assert.AreEqual(strs, default(string[]));
            strs = StringExtends.ToStrings(str, ",");
            Assert.AreEqual(strs, default(string[]));


            str = "";
            strs = StringExtends.ToStrings(str);
            Assert.AreEqual(strs.Length, 0);
            strs = StringExtends.ToStrings(str, ",");
            Assert.AreEqual(strs.Length, 0);
        }
        [TestMethod]
        public void TestToBytes()
        {
            byte[] bytes;
            string str;

            str = default(string);
            bytes = StringExtends.ToBytes(str);
            Assert.AreEqual(bytes, default(string));

            str = "";
            bytes = StringExtends.ToBytes(str);
            Assert.AreEqual(bytes.Length, 0);
        }
        [TestMethod]
        public void TestToUlongs()
        {
            ulong[] uls;
            string str;

            str = default(string);
            uls = StringExtends.ToUlongs(str);
            Assert.AreEqual(uls, default(string));

            str = "";
            uls = StringExtends.ToUlongs(str);
            Assert.AreEqual(uls.Length, 0);
        }
        [TestMethod]
        public void TestToBoolByte()
        {
            Assert.AreEqual(StringExtends.ToBoolByte(default(string)), (byte)0);
            Assert.AreEqual(StringExtends.ToBoolByte("1"), (byte)1);
        }
        [TestMethod]
        public void TestTrancate()
        {
            Assert.AreEqual(StringExtends.Trancate(default(string)), string.Empty);
            Assert.AreEqual(StringExtends.Trancate("123456789", 4, "..."), "1...");
        }
        [TestMethod]
        public void TestTrimOnceStart()
        {
            Assert.AreEqual(StringExtends.TrimOnceStart(default(string), "123"), string.Empty);
            Assert.AreEqual(StringExtends.TrimOnceStart("123456", "123"), "456");
        }
        [TestMethod]
        public void TestTrimOnceEnd()
        {
            Assert.AreEqual(StringExtends.TrimOnceEnd(default(string), "456"), string.Empty);
            Assert.AreEqual(StringExtends.TrimOnceEnd("123456", "456"), "123");
        }
        [TestMethod]
        public void TestTrimOnce()
        {
            Assert.AreEqual(StringExtends.TrimOnce(default(string), "123"), string.Empty);
            Assert.AreEqual(StringExtends.TrimOnce("123456123", "123"), "456");
        }
        [TestMethod]
        public void TestTrimStart()
        {
            Assert.AreEqual(StringExtends.TrimStart(default(string), "123"), string.Empty);
            Assert.AreEqual(StringExtends.TrimStart("123456", "123"), "456");
        }
        [TestMethod]
        public void TestTrimEnd()
        {
            Assert.AreEqual(StringExtends.TrimEnd(default(string), "456"), string.Empty);
            Assert.AreEqual(StringExtends.TrimEnd("123456", "456"), "123");
        }
        [TestMethod]
        public void TestTrim()
        {
            Assert.AreEqual(StringExtends.Trim(default(string), "123"), string.Empty);
            Assert.AreEqual(StringExtends.Trim("123123456123123", "123"), "456");
        }
        [TestMethod]
        public void TestWrap()
        {
            Assert.AreEqual(StringExtends.Wrap(default(string), '[', ']'), string.Empty);
            Assert.AreEqual(StringExtends.Wrap("abc", '[', ']'), "[abc]");
            Assert.AreEqual(StringExtends.Wrap(default(string), "[", "]"), string.Empty);
            Assert.AreEqual(StringExtends.Wrap("abc", "{", "}"), "{abc}");
        }
        [TestMethod]
        public void TestWrapArray()
        {
            Assert.AreEqual(StringExtends.WrapArray(default(string)), string.Empty);
            Assert.AreEqual(StringExtends.WrapArray("abc"), "[abc]");
        }
        [TestMethod]
        public void TestWrapDic()
        {
            Assert.AreEqual(StringExtends.WrapDic(default(string)), string.Empty);
            Assert.AreEqual(StringExtends.WrapDic("abc"), "{abc}");
        }
        #endregion

        #region 静态方法
        [TestMethod]
        public void TestJoin()
        {
            Assert.AreEqual(StringExtends.Join(new int[] { 1, 2 }), "1,2");
            Assert.AreEqual(StringExtends.Join(' ', new int[] { 1, 2 }), "1 2");
        }

        #region QueryString
        [TestMethod]
        public void TestToQueryString()
        {
            Assert.AreEqual("a&bb", StringExtends.ToQueryString(new string[] { "a", "bb" }));
            Assert.AreEqual("userId=123&tel=abc", StringExtends.ToQueryString(new Dictionary<string, object> {{"userId", 123},{"tel","abc"}}));
            Assert.AreEqual("userId=123&tel=abc", StringExtends.ToQueryString(new ListDictionary{ {"userId", 123 }, {"tel", "abc" } }));
            Assert.AreEqual("userId=123&tel=abc", StringExtends.ToQueryString(new string[]{"userId","tel"}, new object[]{123, "abc"}));
            Assert.AreEqual("url", StringExtends.ToQueryString("url", ""));
            Assert.AreEqual("url?a", StringExtends.ToQueryString("url", "a"));
            Assert.AreEqual("url?a&bb", StringExtends.ToQueryString("url", new string[] { "a", "bb" }));
            Assert.AreEqual("url?userId=123&tel=abc", StringExtends.ToQueryString("url", new Dictionary<string, object> {{"userId", 123},{"tel","abc"}}));
            Assert.AreEqual("url?userId=123&tel=abc", StringExtends.ToQueryString("url", new ListDictionary{ {"userId", 123 }, {"tel", "abc" }}));
            Assert.AreEqual("url?userId=123&tel=abc", StringExtends.ToQueryString("url", new string[] { "userId", "tel" }, new object[] { 123, "abc" }));
        }
        #endregion

        #region ParasKV
        [TestMethod]
        public void TestParasKV()
        {
            Assert.AreEqual(string.Empty, StringExtends.ParasKV(new ListDictionary(), null));
            ListDictionary listDictionary = new ListDictionary {
                {"name","qi"},
                {"age", "18"}
            };
            Assert.AreEqual("name: qi\nage: 18\n", StringExtends.ParasKV(listDictionary,
                (key, value) => string.Format("{0}: {1}\n", key, value)));

            Assert.AreEqual(string.Empty, StringExtends.ParasKV(new Dictionary<string,string>(), null));
            Dictionary<string, string> dictionary = new Dictionary<string, string> {
                {"name","qi"},
                {"age", "18"}
            };

            Assert.AreEqual("name: qi\nage: 18\n", StringExtends.ParasKV(dictionary,
                (key, value) => { return string.Format("{0}: {1}\n", key, value); }));

            string[] keys = new string[] { "name", "age" };
            string[] values = new string[] { "qi", "18" };
            //Assert.AreEqual(string.Empty, StringExtends.ParasKV(keys, new string[] { }, null));

            Assert.AreEqual("name: qi\nage: 18\n", StringExtends.ParasKV(keys, values,
                (key, value) => string.Format("{0}: {1}\n", key, value)));
        }
        #endregion

        #region ip <=> x16
        [TestMethod]
        public void TestIpToX16()
        {
            Assert.AreEqual(StringExtends.IpToX16("0.0.0.0"), "00000000");
            Assert.AreEqual(StringExtends.IpToX16("255.255.255.255"), "ffffffff");
        }
        [TestMethod]
        public void TestX16ToIp()
        {
            Assert.AreEqual("0.0.0.0", StringExtends.X16ToIp("00000000"));
            Assert.AreEqual("255.255.255.255", StringExtends.X16ToIp("ffffffff"));
        }
        #endregion

        #region bytes <=> x16
        [TestMethod]
        public void TestBytesToX16()
        {
            byte[] b = new byte[] { 0x41, 0x42 };
            byte[] b2 = StringExtends.X16ToBytes(StringExtends.BytesToX16(b));
            Assert.AreEqual(b2.Length, b.Length);
            Assert.AreEqual(b2[0], b[0]);
            Assert.AreEqual(b2[1], b[1]);
        }
        [TestMethod]
        public void TestX16ToBytes()
        {
            Assert.AreEqual(default(byte[]), StringExtends.X16ToBytes("abc"));

            string str = "4142";
            Assert.AreEqual(str, StringExtends.BytesToX16(StringExtends.X16ToBytes(str)));
        }
        #endregion

        #region asciiString <=> bytes
        [TestMethod]
        public void TestAsciiStringToBytes()
        {
            string str = "abc";
            Assert.AreEqual(str, StringExtends.BytesToAsciiString(StringExtends.AsciiStringToBytes(str)));
        }
        [TestMethod]
        public void TestBytesToAsciiString()
        {
            byte[] b = new byte[] { 0x41, 0x42 };
            byte[] b2 = StringExtends.AsciiStringToBytes(StringExtends.BytesToAsciiString(b));
            Assert.AreEqual(b2.Length, b.Length);
            Assert.AreEqual(b2[0], b[0]);
            Assert.AreEqual(b2[1], b[1]);
        }
        #endregion

        #region string <=> bytes
        [TestMethod]
        public void TestStringToBytes()
        {
            string str = "abc";
            Assert.AreEqual(str, StringExtends.BytesToString(StringExtends.StringToBytes(str)));
        }
        [TestMethod]
        public void TestBytesToString()
        {
            byte[] b = new byte[]{0x41, 0x42};
            byte[] b2 = StringExtends.StringToBytes(StringExtends.BytesToString(b));
            Assert.AreEqual(b2.Length, b.Length);
            Assert.AreEqual(b2[0], b[0]);
            Assert.AreEqual(b2[1], b[1]);
        }
        #endregion
        #endregion
    }
}
