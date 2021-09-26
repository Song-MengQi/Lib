using Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Test.Lib
{
    [TestClass]
    public class PathExtendsTest : TestBase
    {
        [TestMethod]
        public void TestEnsureNotEndWithDirectorySeparatorChar()
        {
            string path = "path";
            Assert.AreEqual(path, PathExtends.EnsureNotEndWithDirectorySeparatorChar(path));
            Assert.AreEqual(path, PathExtends.EnsureNotEndWithDirectorySeparatorChar(path + Path.DirectorySeparatorChar));
        }
        [TestMethod]
        public void TestEnsureEndWithDirectorySeparatorChar()
        {
            string path = "path";
            Assert.AreEqual(path + Path.DirectorySeparatorChar, PathExtends.EnsureEndWithDirectorySeparatorChar(path));
            Assert.AreEqual(path + Path.DirectorySeparatorChar, PathExtends.EnsureEndWithDirectorySeparatorChar(path + Path.DirectorySeparatorChar));
        }
    }
}