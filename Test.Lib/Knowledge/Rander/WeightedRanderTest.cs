using Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Lib
{
    [TestClass]
    public class WeightedRanderTest
    {
        [TestMethod]
        public void Test()
        {
            WeightedRander<int> instance = new WeightedRander<int>(
                new int[] { 1, 2, 3 },
                new uint[] { 1u, 2u, 3u });
            instance.Next();
        }
    }
}