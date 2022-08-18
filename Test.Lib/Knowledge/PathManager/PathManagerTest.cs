using Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Test.Lib
{
    [TestClass]
    public class PathManagerTest
    {
        [TestMethod]
        public void Test()
        {
            Assert.AreEqual(PathManager.Directory, PathManager.DirectoryDefault);

            string dataDirectory = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            PathManager.DataDirectory = dataDirectory;
            Assert.AreEqual(PathManager.DataDirectory, dataDirectory);

            PathManager.DataDirectory = PathManager.DataDirectoryDefault;

            int x = 0;
            PathManager.DirectoryChangedAction += () => ++x;
            PathManager.SubDirectory = "B";
            Assert.AreEqual(PathManager.Directory, @"Data\B");
            Assert.AreEqual(PathManager.DirectoryChangedAction, default(Action));
            Assert.AreEqual(x, 1);

            PathManager.SubDirectory = "\\";
            Assert.AreEqual(PathManager.Directory, PathManager.DataDirectory);
            Assert.AreEqual(x, 1);

            PathManager.SubDirectory = string.Empty;
            Assert.AreEqual(PathManager.Directory, PathManager.DataDirectory);

            PathManager.SubDirectory = default(string);
            Assert.AreEqual(PathManager.Directory, PathManager.DirectoryDefault);
            Assert.AreEqual(PathManager.SubDirectory, PathManager.SubDirectoryDefault);
        }
    }
}