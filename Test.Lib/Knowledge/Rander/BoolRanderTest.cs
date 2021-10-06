using Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Lib
{
    [TestClass]
    public class BoolRanderTest
    {
        [TestMethod]
        public void Test()
        {
            BoolRander instance = new BoolRander();
            instance.Next();
        }
    }
}