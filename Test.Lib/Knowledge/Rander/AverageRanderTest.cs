using Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Lib
{
    [TestClass]
    public class AverageRanderTest
    {
        [TestMethod]
        public void Test()
        {
            AverageRander<int> instance = new AverageRander<int>(new int[] {
                1, 2, 3
            });
            instance.Next();
        }
    }
}