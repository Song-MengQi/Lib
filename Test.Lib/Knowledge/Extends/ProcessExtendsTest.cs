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
            string cmd = string.Join(" ", "echo", str);
            Assert.AreEqual(ProcessExtends.CMDInteract(cmd, TimeSpan.FromSeconds(0.1), s=>s.Contains(str)), str);
            Assert.AreEqual(ProcessExtends.CMDInteract(cmd, TimeSpan.FromSeconds(0.1), s=>false), default(string));
        }
    }
}