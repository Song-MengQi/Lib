using Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Security.Principal;

namespace Test.Lib
{
    [TestClass]
    public class PrincipalExtendsTest
    {
        [TestMethod]
        public void TestInAdministrator()
        {
            Assert.AreEqual(PrincipalExtends.InAdministrator(), new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator));
        }
    }
}