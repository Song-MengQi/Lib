using Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;

namespace Test.Lib
{
    [TestClass]
    public class AssemblyExtendsTest : TestBase
    {
        [TestMethod]
        public void Test()
        {
            AssemblyExtends.Load();
            AssemblyExtends.GetAssembliesByReferenced(Assembly.GetAssembly(typeof(Result)));
        }
    }
}