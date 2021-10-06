using System.Threading;
using Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Lib
{
    [TestClass]
    public class IDisposableExtendsTest : TestBase
    {
        [TestMethod]
        public void TestDispose()
        {
            IDisposableExtends.Dispose(default(AutoResetEvent));
            IDisposableExtends.Dispose(new AutoResetEvent(false));
            IDisposableExtends.Dispose(default(object));
            IDisposableExtends.Dispose(new AutoResetEvent(false) as object);
        }
    }
}