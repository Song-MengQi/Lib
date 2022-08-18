using Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Lib
{
    [TestClass]
    public class ILockableExtendTest : TestBase
    {
        [TestMethod]
        public void TestIsEmptyObject()
        {
            ILockable lockable = new Lockable();
            lockable.Wait();
        }
    }
}
