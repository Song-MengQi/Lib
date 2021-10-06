using System;
using Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Lib
{
    [TestClass]
    public class MathExtendsTest : TestBase
    {
        [TestMethod]
        public void TestMax()
        {
            Assert.AreEqual(3, MathExtends.Max(new int[] { 1, 2, 3 }));
            Assert.AreEqual(2, MathExtends.Max(1, 2));
        }
        [TestMethod]
        public void TestMin()
        {
            Assert.AreEqual(1, MathExtends.Min(new int[] { 1, 2, 3 }));
            Assert.AreEqual(1, MathExtends.Min(1, 2));
        }
        [TestMethod]
        public void TestRange()
        {
            Range<int> range;

            range = MathExtends.Range(1, 3);
            Assert.AreEqual(range.Min, 1);
            Assert.AreEqual(range.Max, 3);

            range = MathExtends.Range(3, 1);
            Assert.AreEqual(range.Min, 1);
            Assert.AreEqual(range.Max, 3);
        }
        #region Clip
        [TestMethod]
        public void TestClip()
        {
            Range<int> range = new Range<int>(10, 20);
            Assert.AreEqual(MathExtends.Clip(0, range), 10);
            Assert.AreEqual(MathExtends.Clip(15, range), 15);
            Assert.AreEqual(MathExtends.Clip(30, range), 20);
        }
        #endregion
        #region InRange
        [TestMethod]
        public void TestInRangeOpen()
        {
            Assert.IsTrue(MathExtends.InRangeOpen(2, 1, 3));
            Assert.IsFalse(MathExtends.InRangeOpen(1, 1, 3));
            Assert.IsFalse(MathExtends.InRangeOpen(3, 1, 3));
            Assert.IsFalse(MathExtends.InRangeOpen(0, 1, 3));
            Assert.IsFalse(MathExtends.InRangeOpen(4, 1, 3));


            Assert.IsTrue(MathExtends.InRangeOpen(2, MathExtends.Range(1, 3)));
            Assert.IsFalse(MathExtends.InRangeOpen(1, MathExtends.Range(1, 3)));
            Assert.IsFalse(MathExtends.InRangeOpen(3, MathExtends.Range(1, 3)));
            Assert.IsFalse(MathExtends.InRangeOpen(0, MathExtends.Range(1, 3)));
            Assert.IsFalse(MathExtends.InRangeOpen(4, MathExtends.Range(1, 3)));


            Assert.IsTrue(MathExtends.InRangeOpenX(2, 1, 3));
            Assert.IsFalse(MathExtends.InRangeOpenX(1, 1, 3));
            Assert.IsFalse(MathExtends.InRangeOpenX(3, 1, 3));
            Assert.IsFalse(MathExtends.InRangeOpenX(0, 1, 3));
            Assert.IsFalse(MathExtends.InRangeOpenX(4, 1, 3));

            Assert.IsTrue(MathExtends.InRangeOpenX(2, 3, 1));
            Assert.IsFalse(MathExtends.InRangeOpenX(1, 3, 1));
            Assert.IsFalse(MathExtends.InRangeOpenX(3, 3, 1));
            Assert.IsFalse(MathExtends.InRangeOpenX(0, 3, 1));
            Assert.IsFalse(MathExtends.InRangeOpenX(4, 3, 1));
        }
        [TestMethod]
        public void TestInRangeClose()
        {
            Assert.IsTrue(MathExtends.InRangeClose(2, 1, 3));
            Assert.IsTrue(MathExtends.InRangeClose(1, 1, 3));
            Assert.IsTrue(MathExtends.InRangeClose(3, 1, 3));
            Assert.IsFalse(MathExtends.InRangeClose(0, 1, 3));
            Assert.IsFalse(MathExtends.InRangeClose(4, 1, 3));


            Assert.IsTrue(MathExtends.InRangeClose(2, MathExtends.Range(1, 3)));
            Assert.IsTrue(MathExtends.InRangeClose(1, MathExtends.Range(1, 3)));
            Assert.IsTrue(MathExtends.InRangeClose(3, MathExtends.Range(1, 3)));
            Assert.IsFalse(MathExtends.InRangeClose(0, MathExtends.Range(1, 3)));
            Assert.IsFalse(MathExtends.InRangeClose(4, MathExtends.Range(1, 3)));


            Assert.IsTrue(MathExtends.InRangeCloseX(2, 1, 3));
            Assert.IsTrue(MathExtends.InRangeCloseX(1, 1, 3));
            Assert.IsTrue(MathExtends.InRangeCloseX(3, 1, 3));
            Assert.IsFalse(MathExtends.InRangeCloseX(0, 1, 3));
            Assert.IsFalse(MathExtends.InRangeCloseX(4, 1, 3));

            Assert.IsTrue(MathExtends.InRangeCloseX(2, 3, 1));
            Assert.IsTrue(MathExtends.InRangeCloseX(1, 3, 1));
            Assert.IsTrue(MathExtends.InRangeCloseX(3, 3, 1));
            Assert.IsFalse(MathExtends.InRangeCloseX(0, 3, 1));
            Assert.IsFalse(MathExtends.InRangeCloseX(4, 3, 1));
        }
        [TestMethod]
        public void TestInRangeOpenClose()
        {
            Assert.IsTrue(MathExtends.InRangeOpenClose(2, 1, 3));
            Assert.IsFalse(MathExtends.InRangeOpenClose(1, 1, 3));
            Assert.IsTrue(MathExtends.InRangeOpenClose(3, 1, 3));
            Assert.IsFalse(MathExtends.InRangeOpenClose(0, 1, 3));
            Assert.IsFalse(MathExtends.InRangeOpenClose(4, 1, 3));


            Assert.IsTrue(MathExtends.InRangeOpenClose(2, MathExtends.Range(1, 3)));
            Assert.IsFalse(MathExtends.InRangeOpenClose(1, MathExtends.Range(1, 3)));
            Assert.IsTrue(MathExtends.InRangeOpenClose(3, MathExtends.Range(1, 3)));
            Assert.IsFalse(MathExtends.InRangeOpenClose(0, MathExtends.Range(1, 3)));
            Assert.IsFalse(MathExtends.InRangeOpenClose(4, MathExtends.Range(1, 3)));


            Assert.IsTrue(MathExtends.InRangeOpenCloseX(2, 1, 3));
            Assert.IsFalse(MathExtends.InRangeOpenCloseX(1, 1, 3));
            Assert.IsTrue(MathExtends.InRangeOpenCloseX(3, 1, 3));
            Assert.IsFalse(MathExtends.InRangeOpenCloseX(0, 1, 3));
            Assert.IsFalse(MathExtends.InRangeOpenCloseX(4, 1, 3));

            Assert.IsTrue(MathExtends.InRangeOpenCloseX(2, 3, 1));
            Assert.IsFalse(MathExtends.InRangeOpenCloseX(1, 3, 1));
            Assert.IsTrue(MathExtends.InRangeOpenCloseX(3, 3, 1));
            Assert.IsFalse(MathExtends.InRangeOpenCloseX(0, 3, 1));
            Assert.IsFalse(MathExtends.InRangeOpenCloseX(4, 3, 1));
        }
        [TestMethod]
        public void TestInRangeCloseOpen()
        {
            Assert.IsTrue(MathExtends.InRangeCloseOpen(2, 1, 3));
            Assert.IsTrue(MathExtends.InRangeCloseOpen(1, 1, 3));
            Assert.IsFalse(MathExtends.InRangeCloseOpen(3, 1, 3));
            Assert.IsFalse(MathExtends.InRangeCloseOpen(0, 1, 3));
            Assert.IsFalse(MathExtends.InRangeCloseOpen(4, 1, 3));


            Assert.IsTrue(MathExtends.InRangeCloseOpen(2, MathExtends.Range(1, 3)));
            Assert.IsTrue(MathExtends.InRangeCloseOpen(1, MathExtends.Range(1, 3)));
            Assert.IsFalse(MathExtends.InRangeCloseOpen(3, MathExtends.Range(1, 3)));
            Assert.IsFalse(MathExtends.InRangeCloseOpen(0, MathExtends.Range(1, 3)));
            Assert.IsFalse(MathExtends.InRangeCloseOpen(4, MathExtends.Range(1, 3)));


            Assert.IsTrue(MathExtends.InRangeCloseOpenX(2, 1, 3));
            Assert.IsTrue(MathExtends.InRangeCloseOpenX(1, 1, 3));
            Assert.IsFalse(MathExtends.InRangeCloseOpenX(3, 1, 3));
            Assert.IsFalse(MathExtends.InRangeCloseOpenX(0, 1, 3));
            Assert.IsFalse(MathExtends.InRangeCloseOpenX(4, 1, 3));

            Assert.IsTrue(MathExtends.InRangeCloseOpenX(2, 3, 1));
            Assert.IsTrue(MathExtends.InRangeCloseOpenX(1, 3, 1));
            Assert.IsFalse(MathExtends.InRangeCloseOpenX(3, 3, 1));
            Assert.IsFalse(MathExtends.InRangeCloseOpenX(0, 3, 1));
            Assert.IsFalse(MathExtends.InRangeCloseOpenX(4, 3, 1));
        }
        #endregion
        #region ToRangeString
        [TestMethod]
        public void TestToRangeString()
        {
            Assert.AreEqual(MathExtends.ToRangeStringOpen(1, 2), "(1,2)");
            Assert.AreEqual(MathExtends.ToRangeStringClose(1, 2), "[1,2]");
            Assert.AreEqual(MathExtends.ToRangeStringOpenClose(1, 2), "(1,2]");
            Assert.AreEqual(MathExtends.ToRangeStringCloseOpen(1, 2), "[1,2)");
        }
        #endregion
        #region Angle
        [TestMethod]
        public void TestAngleToRadian()
        {
            Assert.AreEqual(1 / 180d * Math.PI, MathExtends.AngleToRadian(1));
        }
        [TestMethod]
        public void TestRadianToAngle()
        {
            Assert.AreEqual(1 * 180d / Math.PI, MathExtends.RadianToAngle(1));
        }
        #endregion
        #region DiscardAccuracy
        [TestMethod]
        public void TestDiscardAccuracy()
        {
            Assert.AreEqual(110d, MathExtends.DiscardAccuracy(111d, 10L));
            //Assert.AreEqual(110m, MathExtends.DiscardAccuracy(111m, 10L));
        }
        #endregion
        #region IEEERemainder
        [TestMethod]
        public void TestIEEERemainder()
        {
            Range<double> range = new Range<double>(-180d, 180d);
            Assert.AreEqual(MathExtends.IEEERemainder(-181d, range), 179d);
            Assert.AreEqual(MathExtends.IEEERemainder(-180d, range), -180d);
            Assert.AreEqual(MathExtends.IEEERemainder(-179d, range), -179d);
            Assert.AreEqual(MathExtends.IEEERemainder(179d, range), 179d);
            Assert.AreEqual(MathExtends.IEEERemainder(180d, range), -180d);
            Assert.AreEqual(MathExtends.IEEERemainder(181d, range), -179d);
        }
        [TestMethod]
        public void TestIEEERemainderPositive()
        {
            Assert.AreEqual(MathExtends.IEEERemainderPositive(-1d, 360d), 359d);
            Assert.AreEqual(MathExtends.IEEERemainderPositive(0d, 360d), 0d);
            Assert.AreEqual(MathExtends.IEEERemainderPositive(1d, 360d), 1d);
            Assert.AreEqual(MathExtends.IEEERemainderPositive(359d, 360d), 359d);
            Assert.AreEqual(MathExtends.IEEERemainderPositive(360d, 360d), 0d);
            Assert.AreEqual(MathExtends.IEEERemainderPositive(361d, 360d), 1d);
        }
        #endregion
    }
}