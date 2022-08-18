using Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Lib
{
    [TestClass]
    public class ObjectExtendsTest : TestBase
    {
        private class ObjectExtendsTestClassA { }
        private class ObjectExtendsTestClassB : ObjectExtendsTestClassA { }
        [TestMethod]
        public void TestEqualsDefault()
        {
            Assert.IsTrue(ObjectExtends.EqualsDefault(0));
            Assert.IsFalse(ObjectExtends.EqualsDefault(1));
            Assert.IsTrue(ObjectExtends.EqualsDefault(default(string)));
            Assert.IsFalse(ObjectExtends.EqualsDefault(string.Empty));
        }
        [TestMethod]
        public void TestNotEqualsDefault()
        {
            Assert.IsFalse(ObjectExtends.NotEqualsDefault(0));
            Assert.IsTrue(ObjectExtends.NotEqualsDefault(1));
            Assert.IsFalse(ObjectExtends.NotEqualsDefault(default(string)));
            Assert.IsTrue(ObjectExtends.NotEqualsDefault(string.Empty));
        }
        [TestMethod]
        public void TestDefaultThen()
        {
            Assert.AreNotEqual(ObjectExtends.DefaultThen(default(string), string.Empty), default(string));
            Assert.AreNotEqual(ObjectExtends.DefaultThen(string.Empty, default(string)), default(string));

            Assert.AreNotEqual(ObjectExtends.DefaultThen(default(ObjectExtendsTestClassA)), default(ObjectExtendsTestClassA));
            Assert.IsInstanceOfType(ObjectExtends.DefaultThen(default(ObjectExtendsTestClassA)), typeof(ObjectExtendsTestClassA));
            Assert.AreNotEqual(ObjectExtends.DefaultThen<ObjectExtendsTestClassB, ObjectExtendsTestClassA>(default(ObjectExtendsTestClassA)), default(ObjectExtendsTestClassA));
            Assert.IsInstanceOfType(ObjectExtends.DefaultThen<ObjectExtendsTestClassB, ObjectExtendsTestClassA>(default(ObjectExtendsTestClassA)), typeof(ObjectExtendsTestClassA));
        }
        [TestMethod]
        public void TestNotDefaultThen()
        {
            Assert.AreEqual(ObjectExtends.NotDefaultThen(default(string), string.Empty), default(string));
            Assert.AreEqual(ObjectExtends.NotDefaultThen(string.Empty, default(string)), default(string));

            Assert.AreEqual(ObjectExtends.NotDefaultThen(default(ObjectExtendsTestClassA)), default(ObjectExtendsTestClassA));
            Assert.IsInstanceOfType(ObjectExtends.NotDefaultThen(new ObjectExtendsTestClassA()), typeof(ObjectExtendsTestClassA));
            Assert.AreEqual(ObjectExtends.NotDefaultThen<ObjectExtendsTestClassB, ObjectExtendsTestClassA>(default(ObjectExtendsTestClassA)), default(ObjectExtendsTestClassA));
            Assert.IsInstanceOfType(ObjectExtends.NotDefaultThen<ObjectExtendsTestClassB, ObjectExtendsTestClassA>(new ObjectExtendsTestClassA()), typeof(ObjectExtendsTestClassA));
        }
        [TestMethod]
        public void TestAs()
        {
            Assert.AreEqual(ObjectExtends.As<ObjectExtendsTestClassB>(new ObjectExtendsTestClassA()), default(ObjectExtendsTestClassB));
            Assert.AreNotEqual(ObjectExtends.As<ObjectExtendsTestClassA>(new ObjectExtendsTestClassB()), default(ObjectExtendsTestClassA));
        }
    }
}