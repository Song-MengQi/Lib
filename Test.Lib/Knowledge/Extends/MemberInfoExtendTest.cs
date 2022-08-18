using Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Lib
{
    [TestClass]
    public class MemberInfoExtendTest
    {
        [TestMethod]
        public void TestTryGetCustomAttribute()
        {
            TestClassAttribute tca;
            Assert.IsTrue(GetType().TryGetCustomAttribute(out tca));
            Assert.IsNotNull(tca);
        }
        [TestMethod]
        public void TestIsDefined()
        {
            Assert.IsTrue(GetType().IsDefined<TestClassAttribute>());
        }
    }
}