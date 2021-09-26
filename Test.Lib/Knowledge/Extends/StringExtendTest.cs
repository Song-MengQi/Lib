using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lib;
using System;

namespace Test.Lib
{
    [TestClass]
    public class StringExtendTest : TestBase
    {
        [TestMethod]
        public void TestCount()
        {
            Assert.AreEqual("".Count(ch => true), 0);
            Assert.AreEqual("1".Count(ch => false), 0);
            Assert.AreEqual("1".Count(ch => true), 1);
            Assert.AreEqual("12".Count(ch => ch > '1'), 1);
        }
        [TestMethod]
        public void TestAny()
        {
            Assert.IsFalse("".Any(ch=>true));
            Assert.IsFalse("1".Any(ch=>false));
            Assert.IsTrue("1".Any(ch=>true));
            Assert.IsTrue("12".Any(ch=>ch>'1'));
        }
        [TestMethod]
        public void TestAll()
        {
            Assert.IsTrue("".All(ch => true));
            Assert.IsFalse("1".All(ch => false));
            Assert.IsTrue("1".All(ch => true));
            Assert.IsFalse("12".All(ch => ch > '1'));
        }
        [TestMethod]
        public void TestAnyWhiteSpace()
        {
            Assert.IsFalse("1".AnyWhiteSpace());
            Assert.IsFalse("a张".AnyWhiteSpace());
            Assert.IsTrue("\n".AnyWhiteSpace());
            Assert.IsTrue("张 三".AnyWhiteSpace());
        }
        [TestMethod]
        public void TestAllWhiteSpace()
        {
            Assert.IsFalse("1".AllWhiteSpace());
            Assert.IsFalse("张".AllWhiteSpace());
            Assert.IsTrue("\t\n".AllWhiteSpace());
            Assert.IsFalse("张 三".AllWhiteSpace());
        }
        [TestMethod]
        public void TestAll_zh()
        {
            Assert.IsFalse("1".All_zh());
            Assert.IsFalse("a张".All_zh());
            Assert.IsFalse("张3".All_zh());
            Assert.IsTrue("张三".All_zh());
        }
        [TestMethod]
        public void TestAllDigit()
        {
            Assert.IsTrue("1".AllDigit());
            Assert.IsFalse("a张".AllDigit());
            Assert.IsFalse("张3".AllDigit());
            Assert.IsFalse("张三".AllDigit());
        }
        [TestMethod]
        public void TestAllLetter()
        {
            Assert.IsTrue("asd".AllLetter());
            Assert.IsFalse("a张".AllLetter());
            Assert.IsFalse("张3".AllLetter());
            Assert.IsFalse("张三".AllLetter());
        }
        [TestMethod]
        public void TestAllSimpleChar()
        {
            Assert.IsTrue("".AllSimpleChar());
            Assert.IsTrue("1".AllSimpleChar());
            Assert.IsTrue("999999999999".AllSimpleChar());
            Assert.IsTrue(ulong.MaxValue.ToString().AllSimpleChar());
            Assert.IsTrue("0".AllSimpleChar());
            Assert.IsTrue("abc".AllSimpleChar());
            Assert.IsTrue("abc123".AllSimpleChar());
            Assert.IsTrue("123abc".AllSimpleChar());
            Assert.IsTrue("ABC123abc".AllSimpleChar());
            Assert.IsFalse("-1".AllSimpleChar());
            Assert.IsFalse("+".AllSimpleChar());
            Assert.IsFalse("*".AllSimpleChar());
            Assert.IsFalse("/".AllSimpleChar());
            Assert.IsFalse("@".AllSimpleChar());
            Assert.IsFalse("\\".AllSimpleChar());
            Assert.IsFalse("{".AllSimpleChar());
        }
        [TestMethod]
        public void TestAllHexNumber()
        {
            Assert.IsTrue("".AllHexNumber());
            Assert.IsTrue("1".AllHexNumber());
            Assert.IsTrue("999999999999".AllHexNumber());
            Assert.IsTrue(ulong.MaxValue.ToString().AllHexNumber());
            Assert.IsTrue("0".AllHexNumber());
            Assert.IsTrue("abc".AllHexNumber());
            Assert.IsTrue("abc123".AllHexNumber());
            Assert.IsTrue("123abc".AllHexNumber());
            Assert.IsTrue("ABC123abc".AllHexNumber());
            Assert.IsFalse("0x11".AllHexNumber());
            Assert.IsFalse("g".AllHexNumber());
            Assert.IsFalse("z".AllHexNumber());
            Assert.IsFalse("G".AllHexNumber());
            Assert.IsFalse("Z".AllHexNumber());
            Assert.IsFalse("+".AllHexNumber());
            Assert.IsFalse("*".AllHexNumber());
            Assert.IsFalse("/".AllHexNumber());
            Assert.IsFalse("@".AllHexNumber());
        }
        [TestMethod]
        public void TestIsInteger()
        {
            Assert.IsFalse("".IsInteger());
            Assert.IsTrue("1".IsInteger());
            Assert.IsTrue("999999999999".IsInteger());
            Assert.IsTrue(ulong.MaxValue.ToString().IsInteger());
            Assert.IsTrue("0".IsInteger());
            Assert.IsFalse("-1".IsInteger());
            Assert.IsFalse("abc".IsInteger());
        }
        [TestMethod]
        public void TestIsSInteger()
        {
            Assert.IsFalse("".IsSInteger());
            Assert.IsTrue("1".IsSInteger());
            Assert.IsTrue("999999999999".IsSInteger());
            Assert.IsTrue(ulong.MaxValue.ToString().IsSInteger());
            Assert.IsTrue("0".IsSInteger());
            Assert.IsTrue("-1".IsSInteger());
            Assert.IsFalse("abc".IsSInteger());
        }
        [TestMethod]
        public void TestIsHexNumber()
        {
            Assert.IsFalse("".IsHexNumber());
            Assert.IsTrue("1".IsHexNumber());
        }
        [TestMethod]
        public void TestIsUlong()
        {
            Assert.IsFalse("".IsUlong());
            Assert.IsTrue("1".IsUlong());
            Assert.IsTrue("0".IsUlong());
            Assert.IsFalse("-1".IsUlong());
            Assert.IsFalse("999999999999999999999999999999999999".IsUlong());
            Assert.IsFalse("abc".IsUlong());
            Assert.IsFalse("18446744073709551616".IsUlong());
        }
        [TestMethod]
        public void TestIsUint()
        {
            Assert.IsFalse("".IsUint());
            Assert.IsTrue("1".IsUint());
            Assert.IsTrue("0".IsUint());
            Assert.IsFalse("-1".IsUint());
            Assert.IsFalse("9999999999999999999999999999".IsUint());
            Assert.IsFalse("abc".IsUint());
            Assert.IsFalse("4294967296".IsUint());
        }
        [TestMethod]
        public void TestIsUshort()
        {
            Assert.IsFalse("".IsUshort());
            Assert.IsTrue("1".IsUshort());
            Assert.IsTrue("0".IsUshort());
            Assert.IsFalse("-1".IsUshort());
            Assert.IsFalse("65537".IsUshort());
            Assert.IsFalse("1111111".IsUshort());
            Assert.IsFalse("abc".IsUshort());
        }
        [TestMethod]
        public void TestIsByte()
        {
            Assert.IsFalse("".IsByte());
            Assert.IsTrue("1".IsByte());
            Assert.IsTrue("0".IsByte());
            Assert.IsFalse("-1".IsByte());
            Assert.IsFalse("999".IsByte());
            Assert.IsFalse("1234".IsByte());
            Assert.IsFalse("abc".IsByte());
        }
        [TestMethod]
        public void TestIsLong()
        {
            Assert.IsFalse("".IsLong());
            Assert.IsTrue("1".IsLong());
            Assert.IsTrue("0".IsLong());
            Assert.IsTrue("-1".IsLong());
            Assert.IsFalse("999999999999999999999999999999999999".IsLong());
            Assert.IsFalse("abc".IsLong());
            Assert.IsFalse("9223372036854775808".IsLong());
            Assert.IsTrue("9223372036854775807".IsLong());
        }
        [TestMethod]
        public void TestIsInt()
        {
            Assert.IsFalse("".IsInt());
            Assert.IsTrue("1".IsInt());
            Assert.IsTrue("0".IsInt());
            Assert.IsTrue("-1".IsInt());
            Assert.IsFalse("9999999999999999999999999999".IsInt());
            Assert.IsFalse("abc".IsInt());
            Assert.IsFalse("33333333333".IsInt());
            Assert.IsTrue("1111111111".IsInt());
        }
        [TestMethod]
        public void TestIsShort()
        {
            Assert.IsFalse("".IsShort());
            Assert.IsTrue("1".IsShort());
            Assert.IsTrue("0".IsShort());
            Assert.IsTrue("-1".IsShort());
            Assert.IsFalse("abc".IsShort());
            Assert.IsFalse("1111111".IsShort());
            Assert.IsFalse("32768".IsShort());
            Assert.IsTrue("32767".IsShort());
        }
        [TestMethod]
        public void TestIsSbyte()
        {
            Assert.IsFalse("".IsSbyte());
            Assert.IsTrue("1".IsSbyte());
            Assert.IsTrue("0".IsSbyte());
            Assert.IsTrue("-1".IsSbyte());
            Assert.IsFalse("999".IsSbyte());
            Assert.IsFalse("11111".IsSbyte());
            Assert.IsFalse("abc".IsSbyte());
            Assert.IsFalse("128".IsSbyte());
            Assert.IsTrue("127".IsSbyte());
        }
        [TestMethod]
        public void TestIsDecimal()
        {
            Assert.IsFalse("".IsDecimal());
            Assert.IsTrue("1".IsDecimal());
            Assert.IsTrue("0".IsDecimal());
            Assert.IsTrue("-1".IsDecimal());
            Assert.IsFalse("abc".IsDecimal());
            Assert.IsFalse((decimal.MaxValue.ToString()+"0").IsDecimal());
        }
        [TestMethod]
        public void TestIsDouble()
        {
            Assert.IsFalse("".IsDouble());
            Assert.IsTrue("1".IsDouble());
            Assert.IsTrue("0".IsDouble());
            Assert.IsTrue("-1".IsDouble());
            Assert.IsFalse("abc".IsDouble());
            //Assert.IsFalse((double.MaxValue.ToString() + "0").IsDouble());
        }
        [TestMethod]
        public void TestIsFloat()
        {
            Assert.IsFalse("".IsFloat());
            Assert.IsTrue("1".IsFloat());
            Assert.IsTrue("0".IsFloat());
            Assert.IsTrue("-1".IsFloat());
            Assert.IsFalse("abc".IsFloat());
            //Assert.IsFalse((float.MaxValue.ToString() + "0").IsFloat());
        }
        [TestMethod]
        public void TestIsTrue()
        {
            Assert.IsFalse("".IsTrue());
            Assert.IsFalse("0".IsTrue());
            Assert.IsTrue("1".IsTrue());
            Assert.IsTrue("a".IsTrue());
            Assert.IsFalse("f".IsTrue());
            Assert.IsFalse("fAlse".IsTrue());
        }
        [TestMethod]
        public void TestIsFalse()
        {
            Assert.IsTrue("".IsFalse());
            Assert.IsTrue("0".IsFalse());
            Assert.IsFalse("1".IsFalse());
            Assert.IsFalse("a".IsFalse());
            Assert.IsTrue("f".IsFalse());
            Assert.IsTrue("fAlse".IsFalse());
        }
        [TestMethod]
        public void TestIsBase64()
        {
            Assert.IsFalse("".IsBase64());
            Assert.IsFalse("1".IsBase64());
            Assert.IsTrue("0000".IsBase64());
            Assert.IsTrue("abcd".IsBase64());
            Assert.IsTrue("ab12".IsBase64());
            Assert.IsTrue("12ab".IsBase64());
            Assert.IsTrue("ABC123ab".IsBase64());
            Assert.IsTrue("0x11".IsBase64());
            Assert.IsTrue("+++=".IsBase64());
            Assert.IsTrue("//==".IsBase64());
            Assert.IsFalse("/===".IsBase64());
            Assert.IsFalse("@".IsBase64());
            Assert.IsFalse("1=2=".IsBase64());
        }
        [TestMethod]
        public void TestIsId()
        {
            Assert.IsFalse("".IsId());
            Assert.IsTrue("1".IsId());
            Assert.IsTrue("0".IsId());
            Assert.IsFalse("-1".IsId());
            Assert.IsFalse(ulong.MaxValue.ToString().IsId());
            Assert.IsFalse("abc".IsId());
        }
        [TestMethod]
        public void TestIsEmail()
        {
            Assert.IsFalse("".IsEmail());
            Assert.IsTrue("fengshiqibie@hotmail.com".IsEmail());
            Assert.IsTrue("1@1.cn".IsEmail());
            Assert.IsTrue("2@3@asd.cn".IsEmail());
            Assert.IsFalse("-1".IsEmail());
            Assert.IsFalse("12345".IsEmail());
            Assert.IsFalse("abcdef".IsEmail());
            Assert.IsFalse("abcf@".IsEmail());
            Assert.IsFalse("@asd".IsEmail());
            Assert.IsFalse("23@asd.".IsEmail());
        }
        [TestMethod]
        public void TestIsTel()
        {
            Assert.IsFalse("".IsTel());
            Assert.IsTrue("15001270050".IsTel());
            Assert.IsFalse("1500127005".IsTel());
            Assert.IsFalse("2345".IsTel());
            Assert.IsFalse("12345678901".IsTel());
            Assert.IsFalse("22345678901".IsTel());
            Assert.IsFalse("abc".IsTel());
        }
        [TestMethod]
        public void TestIsDate()
        {
            Assert.IsFalse("".IsDate());
            Assert.IsFalse("150".IsDate());
            Assert.IsTrue("2018-11-16".IsDate());
            Assert.IsTrue("2018 11 16".IsDate());
            Assert.IsTrue("2018/11/16".IsDate());
            Assert.IsFalse("2018-11-161".IsDate());
            Assert.IsFalse("18-11-16".IsDate());
            Assert.IsFalse("2018-333-8".IsDate());
            Assert.IsTrue("2018-3-8".IsDate());
        }
        [TestMethod]
        public void TestIsLanguageCode()
        {
            Assert.IsFalse("".IsLanguageCode());
            Assert.IsFalse("123456".IsLanguageCode());
            Assert.IsTrue("zh-CN".IsLanguageCode());
        }
        [TestMethod]
        public void TestIsDistrictCode()
        {
            Assert.IsFalse("".IsDistrictCode());
            Assert.IsFalse("123456789012345678901234567890123".IsDistrictCode());
            Assert.IsFalse("CN,CN-37,CN-3706".IsDistrictCode());
            Assert.IsTrue("CN-3706".IsDistrictCode());
        }
        [TestMethod]
        public void TestIsDistrictCodes()
        {
            Assert.IsFalse("".IsDistrictCodes());
            Assert.IsFalse("123456789012345678901234567890123".IsDistrictCodes());
            Assert.IsTrue("CN,CN-37,CN-3706".IsDistrictCodes());
        }
        [TestMethod]
        public void TestSplit()
        {
            string[] strs;
            strs = "".Split("");
            Assert.AreEqual(strs.Length, 0);

            strs = " a , b , ".Split(",", StringSplitOptions.RemoveEmptyEntries);
            Assert.AreEqual(strs.Length, 3);
            Assert.AreEqual(strs[0], " a ");
            Assert.AreEqual(strs[1], " b ");
        }
        [TestMethod]
        public void TestToFormatDateString()
        {
            Assert.AreEqual(string.Empty, "".ToFormatDateString());
            Assert.AreEqual(string.Empty, "150".ToFormatDateString());
            Assert.AreEqual(string.Empty, "2018-11-161".ToFormatDateString());
            Assert.AreEqual(string.Empty, "18-11-16".ToFormatDateString());
            Assert.AreEqual(string.Empty, "2018-333-8".ToFormatDateString());
            Assert.AreEqual(string.Empty, "9999-99-99".ToFormatDateString());
            Assert.AreEqual("2018-11-16", "2018-11-16".ToFormatDateString());
            Assert.AreEqual("2018-11-16", "2018 11 16".ToFormatDateString());
            Assert.AreEqual("2018-11-16", "2018/11/16".ToFormatDateString());
            Assert.AreEqual("2018-03-08", "2018-3-8".ToFormatDateString());
        }
        [TestMethod]
        public void TestToUpperFirst()
        {
            Assert.AreEqual("".ToUpperFirst(), string.Empty);
            Assert.AreEqual("A".ToUpperFirst(), "A");
            Assert.AreEqual("a".ToUpperFirst(), "A");
            Assert.AreEqual("aa".ToUpperFirst(), "Aa");
            Assert.AreEqual("AA".ToUpperFirst(), "AA");
        }
        [TestMethod]
        public void TestToLowerFirst()
        {
            Assert.AreEqual("".ToLowerFirst(), string.Empty);
            Assert.AreEqual("A".ToLowerFirst(), "a");
            Assert.AreEqual("a".ToLowerFirst(), "a");
            Assert.AreEqual("aa".ToLowerFirst(), "aa");
            Assert.AreEqual("AA".ToLowerFirst(), "aA");
        }
        [TestMethod]
        public void TestToStrings()
        {
            string[] strs;
            strs = "".ToStrings();
            Assert.AreEqual(strs.Length, 0);

            strs = " a , b , ".ToStrings();
            Assert.AreEqual(strs.Length, 2);
            Assert.AreEqual(strs[0], "a");
            Assert.AreEqual(strs[1], "b");

            strs = " a ,_, b ,_, ".ToStrings(",_,");
            Assert.AreEqual(strs.Length, 2);
            Assert.AreEqual(strs[0], "a");
            Assert.AreEqual(strs[1], "b");
        }
        [TestMethod]
        public void TestToBytes()
        {
            byte[] bytes;
            bytes = "".ToBytes();
            Assert.AreEqual(bytes.Length, 0);

            bytes = "1 , 2 , ,".ToBytes();
            Assert.AreEqual(bytes.Length, 2);
            Assert.AreEqual(bytes[0], (byte)1);
            Assert.AreEqual(bytes[1], (byte)2);
        }
        [TestMethod]
        public void TestToUlongs()
        {
            ulong[] uls;
            uls = "".ToUlongs();
            Assert.AreEqual(uls.Length, 0);

            uls = "1 , 2 , ,".ToUlongs();
            Assert.AreEqual(uls.Length, 2);
            Assert.AreEqual(uls[0], 1ul);
            Assert.AreEqual(uls[1], 2ul);
        }
        [TestMethod]
        public void TestToBoolByte()
        {
            Assert.AreEqual("".ToBoolByte(), (byte)0);
            Assert.AreEqual("0".ToBoolByte(), (byte)0);
            Assert.AreEqual("1".ToBoolByte(), (byte)1);
            Assert.AreEqual("a".ToBoolByte(), (byte)1);
            Assert.AreEqual("f".ToBoolByte(), (byte)0);
            Assert.AreEqual("fAlse".ToBoolByte(), (byte)0);
        }
        [TestMethod]
        public void TestTrancate()
        {
            string str = "123456789";
            Assert.AreEqual(str.Trancate(1, "..."), str);
            Assert.AreEqual(str.Trancate(3, "..."), "...");
            Assert.AreEqual(str.Trancate(4, "..."), "1...");
            Assert.AreEqual(str.Trancate(4, "~"), "123~");
            Assert.AreEqual(str.Trancate(9, "..."), str);
            Assert.AreEqual(str.Trancate(10, "..."), str);
        }
        [TestMethod]
        public void TestTrimOnceStart()
        {
            Assert.AreEqual("".TrimOnceStart("abc"), "");
            Assert.AreEqual("bcdef".TrimOnceStart("abc"), "bcdef");
            Assert.AreEqual("abcdef".TrimOnceStart("abc"), "def");
            Assert.AreEqual("abcabcdef".TrimOnceStart("abc"), "abcdef");
        }
        [TestMethod]
        public void TestTrimOnceEnd()
        {
            Assert.AreEqual("".TrimOnceEnd("def"), "");
            Assert.AreEqual("abcde".TrimOnceEnd("def"), "abcde");
            Assert.AreEqual("abcdef".TrimOnceEnd("def"), "abc");
            Assert.AreEqual("abcdefdef".TrimOnceEnd("def"), "abcdef");
        }
        [TestMethod]
        public void TestTrimOnce()
        {
            Assert.AreEqual("".TrimOnce("abc"), "");
            Assert.AreEqual("def".TrimOnce("abc"), "def");
            Assert.AreEqual("abcdef".TrimOnce("abc"), "def");
            Assert.AreEqual("defabc".TrimOnce("abc"), "def");
            Assert.AreEqual("abcdefabc".TrimOnce("abc"), "def");
            Assert.AreEqual("abcabcdefabcabc".TrimOnce("abc"), "abcdefabc");
        }
        [TestMethod]
        public void TestTrimStart()
        {
            Assert.AreEqual("".TrimStart("abc"), "");
            Assert.AreEqual("bcdef".TrimStart("abc"), "bcdef");
            Assert.AreEqual("abcdef".TrimStart("abc"), "def");
            Assert.AreEqual("abcabcdef".TrimStart("abc"), "def");
        }
        [TestMethod]
        public void TestTrimEnd()
        {
            Assert.AreEqual("".TrimEnd("def"), "");
            Assert.AreEqual("abcde".TrimEnd("def"), "abcde");
            Assert.AreEqual("abcdef".TrimEnd("def"), "abc");
            Assert.AreEqual("abcdefdef".TrimEnd("def"), "abc");
        }
        [TestMethod]
        public void TestTrim()
        {
            Assert.AreEqual("".Trim("abc"), "");
            Assert.AreEqual("def".Trim("abc"), "def");
            Assert.AreEqual("abcdef".Trim("abc"), "def");
            Assert.AreEqual("defabc".Trim("abc"), "def");
            Assert.AreEqual("abcdefabc".Trim("abc"), "def");
            Assert.AreEqual("abcabcdefabcabc".Trim("abc"), "def");
        }

        [TestMethod]
        public void TestWrap()
        {
            Assert.AreEqual("".Wrap('[', ']'), "[]");
            Assert.AreEqual("abc".Wrap('[', ']'), "[abc]");
            Assert.AreEqual("[]".Wrap('[', ']'), "[]");
            Assert.AreEqual("[abc]".Wrap('[', ']'), "[abc]");
            Assert.AreEqual("[[]]".Wrap('[', ']'), "[]");
            Assert.AreEqual("[[abc]]".Wrap('[', ']'), "[abc]");

            Assert.AreEqual("".Wrap("[", "]"), "[]");
            Assert.AreEqual("abc".Wrap("[", "]"), "[abc]");
            Assert.AreEqual("[]".Wrap("[", "]"), "[]");
            Assert.AreEqual("[abc]".Wrap("[", "]"), "[abc]");
            Assert.AreEqual("[[]]".Wrap("[", "]"), "[]");
            Assert.AreEqual("[[abc]]".Wrap("[", "]"), "[abc]");

            Assert.AreEqual("abc".WrapArray(), "[abc]");
            Assert.AreEqual("abc".WrapDic(), "{abc}");
        }

        [TestMethod]
        public void TestAddPrefixIfNotNullOrEmpty()
        {
            Assert.AreEqual("".AddPrefixIfNotNullOrEmpty("", ","), "");
            Assert.AreEqual("".AddPrefixIfNotNullOrEmpty("X", ","), "X,");
            Assert.AreEqual("".AddPrefixIfNotNullOrEmpty(" ", ","), " ,");
        }
        [TestMethod]
        public void TestAddSuffixIfNotNullOrEmpty()
        {
            Assert.AreEqual("".AddSuffixIfNotNullOrEmpty("", ","), "");
            Assert.AreEqual("".AddSuffixIfNotNullOrEmpty("X", ","), ",X");
            Assert.AreEqual("".AddSuffixIfNotNullOrEmpty(" ", ","), ", ");
        }
        #region WithoutCheck
        [TestMethod]
        public void TestToFormatDateStringWithoutCheck()
        {
            Assert.AreEqual("1992-11-16 00:01:02".ToFormatDateStringWithoutCheck(), "1992-11-16");
        }
        [TestMethod]
        public void TestToFormatDateTimeStringWithoutCheck()
        {
            Assert.AreEqual("1992-11-16 00:01:02".ToFormatDateTimeStringWithoutCheck(), "1992-11-16 00:01:02");
        }
        #endregion
    }
}