using Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Lib
{
    [TestClass]
    public class RangeTest
    {
        [TestMethod]
        public void Test()
        {
            Range<int> range = new Range<int>();

            range = new Range<int>(3, 1);
            Assert.AreEqual(range.Min, 3);
            Assert.AreEqual(range.Max, 1);

            range.Min = 1;
            range.Max = 3;
            Assert.AreEqual(range.Min, 1);
            Assert.AreEqual(range.Max, 3);
        }
    }
}