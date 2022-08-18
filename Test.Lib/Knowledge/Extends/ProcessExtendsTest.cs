using Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Test.Lib
{
    [TestClass]
    public class ProcessExtendsTest
    {
        [TestMethod]
        public void TestCMDInteract()
        {
            string str = "A";
            string result = ProcessExtends.CMDInteract(string.Join(" ", "echo", str), TimeSpan.FromSeconds(0.1), s=>s.Contains(str));
            Assert.AreEqual(str, result);
        }
    }
}