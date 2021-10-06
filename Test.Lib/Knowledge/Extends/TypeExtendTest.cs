using System;
using Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Lib
{
    [TestClass]
    public class TypeExtendTest
    {
        [TestMethod]
        public void TestHasAttribute()
        {
            Type type = GetType();
            Assert.IsTrue(type.HasAttribute<TestClassAttribute>());
        }
    }
}