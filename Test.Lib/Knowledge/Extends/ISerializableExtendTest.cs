using Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Lib
{
    [TestClass]
    public class ISerializableExtendTest : TestBase
    {
        [TestMethod]
        public void TestIsEmptyObject()
        {
            ISerializable serializable = new Serializable();
            serializable.Wait();
            serializable.WaitAsync().Wait();
        }
    }
}
