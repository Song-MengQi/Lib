using Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Lib
{
    [TestClass]
    public class InvokableTest : TestBase
    {
        [TestMethod]
        public void Test()
        {
            Invokable instance = new Invokable();

            int x = 0;
            instance.Invoke(()=>{++x;});
            Assert.AreEqual(x, 1);
            Assert.AreEqual(instance.Invoke(()=>++x), 2);
        }
    }
}