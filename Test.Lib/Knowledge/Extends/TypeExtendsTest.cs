using System;
using System.Collections;
using System.Collections.Specialized;
using System.Reflection;
using System.Threading.Tasks;
using Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Lib
{
    [TestClass]
    public class TypeExtendsTest
    {
        [TestMethod]
        public void Test()
        {
            Type[] types = TypeExtends.GetTypes(new Assembly[] { Assembly.GetExecutingAssembly() });

            Type type = GetType();
            Assert.AreEqual(type, TypeExtends.FindTypeByName(type.FullName, types));
            Assert.AreEqual(type, TypeExtends.FindTypeByNameOrDefault(type.FullName, types));
            Assert.AreEqual(default(Type), TypeExtends.FindTypeByNameOrDefault(type.FullName+"2", types));
        }
        [TestMethod]
        public void TestIsAssignable()
        {
            Assert.IsTrue(TypeExtends.IsAssignable(typeof(IDictionary), typeof(ListDictionary)));
            Assert.IsTrue(TypeExtends.IsAssignable(typeof(Task), typeof(Task<int>)));
            Assert.IsFalse(TypeExtends.IsAssignable(typeof(Action), typeof(Func<int>)));

            Assert.IsTrue(TypeExtends.IsAssignable(new Type[] { typeof(Task) }, new Type[] { typeof(Task<int>) }));
            Assert.IsFalse(TypeExtends.IsAssignable(new Type[] { typeof(Task) }, new Type[] { }));
        }
    }
}
