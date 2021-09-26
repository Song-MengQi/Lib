using Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Test.Lib;

namespace Test
{
    [TestClass]
    public class ObjectExtendsTest : TestBase
    {
        private class ObjectExtendsTestClassA { }
        private class ObjectExtendsTestClassB : ObjectExtendsTestClassA { }
        [TestMethod]
        public void Test()
        {
            Assert.IsTrue(ObjectExtends.EqualsDefault(0));
            Assert.IsFalse(ObjectExtends.EqualsDefault(1));
            Assert.IsTrue(ObjectExtends.EqualsDefault(default(string)));
            Assert.IsFalse(ObjectExtends.EqualsDefault(string.Empty));

            Assert.AreEqual(ObjectExtends.DefaultThen(default(string), ()=>string.Empty), string.Empty);
            Assert.AreEqual(ObjectExtends.DefaultThen(string.Empty, ()=>default(string)), string.Empty);

            Assert.AreNotEqual(ObjectExtends.DefaultThen(default(ObjectExtendsTestClassA)), default(ObjectExtendsTestClassA));
            Assert.AreNotEqual(ObjectExtends.DefaultThen<ObjectExtendsTestClassB, ObjectExtendsTestClassA>(default(ObjectExtendsTestClassA)), default(ObjectExtendsTestClassA));
        }
    }
}