using Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

namespace Test.Lib
{
    [TestClass]
    public class ManualResetEventSlimExtendsTest : TestBase
    {
        [TestMethod]
        public void Test()
        {
            ManualResetEventSlim slim = default(ManualResetEventSlim);
            ManualResetEventSlimExtends.Set(slim);
            ManualResetEventSlimExtends.Reset(slim);

            slim = new ManualResetEventSlim();
            ManualResetEventSlimExtends.Reset(slim);
            ManualResetEventSlimExtends.Set(slim);
            slim.Wait();
            slim.Dispose();
        }
    }
}
