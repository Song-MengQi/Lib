using Lib;
using Lib.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Windows.Media;

namespace Test.Lib.UI
{
    [TestClass]
    public class ColorExtendsTest
    {
        private void TestRGBToHSL(byte r, byte g, byte b, double hue, double saturation, double lightness)
        {
            HSL x = ColorExtends.RGBToHSL(new RGB(r, g, b));
            HSL y = new HSL(hue, saturation, lightness);
            Assert.AreEqual(Math.Round(x.H), Math.Round(y.H));
            Assert.AreEqual(Math.Round(x.S), Math.Round(y.S));
            Assert.AreEqual(Math.Round(x.L), Math.Round(y.L));
        }
        [TestMethod]
        public void TestRGBToHSL()
        {
            TestRGBToHSL(0x00, 0x00, 0x00, 0d, 0d, 0d);
            TestRGBToHSL(0xff, 0x00, 0x00, 0d, 1d, 0.5d);
            TestRGBToHSL(0x00, 0xff, 0x00, 120d, 1d, 0.5d);
            TestRGBToHSL(0x00, 0x00, 0xff, 240d, 1d, 0.5d);
            TestRGBToHSL(0xff, 0xff, 0xff, 0d, 0d, 1d);
        }

        private void TestHSLToRGB(double hue, double saturation, double lightness, byte r, byte g, byte b)
        {
            Assert.AreEqual(ColorExtends.HSLToRGB(new HSL(hue, saturation, lightness)), new RGB(r, g, b));
        }
        [TestMethod]
        public void TestHSLToRGB()
        {
            TestHSLToRGB(0d, 0d, 0d, 0x00, 0x00, 0x00);
            TestHSLToRGB(0d, 1d, 0.5d, 0xff, 0x00, 0x00);
            TestHSLToRGB(120d, 1d, 0.5d, 0x00, 0xff, 0x00);
            TestHSLToRGB(240d, 1d, 0.5d, 0x00, 0x00, 0xff);
            TestHSLToRGB(0d, 0d, 1d, 0xff, 0xff, 0xff);
        }
        [TestMethod]
        public void TestDee()
        {
            Color color = Color.FromArgb(255, 120, 148, 64);
            Color color004 = color.Deepen(0.04d, 0.04d);
            Assert.IsTrue(MathExtends.InRangeClose(color004.R, 107-3, 107+3));
            Assert.IsTrue(MathExtends.InRangeClose(color004.G, 129-3, 129+3));
            Assert.IsTrue(MathExtends.InRangeClose(color004.B, 61-3, 61+3));
        }
    }
}