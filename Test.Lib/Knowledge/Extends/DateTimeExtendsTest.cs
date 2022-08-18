using Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Lib
{
    [TestClass]
    public class DateTimeExtendsTest : TestBase
    {
        [TestMethod]
        public void Test()
        {
            DateTimeExtends.GetNowDateString();
            DateTimeExtends.GetNowDateTimeString();
            DateTimeExtends.GetNowDateTime6String();

            DateTimeExtends.GetNowTimeString();
            DateTimeExtends.GetNowTime6String();

            DateTimeExtends.GetYesterdayDateString();


            Assert.AreEqual(DateTimeExtends.DefaultDateTimeString, "0000-00-00 00:00:00");
            Assert.AreEqual(DateTimeExtends.DefaultDateTime6String, "0000-00-00 00:00:00.000000");
        }
    }
}