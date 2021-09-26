﻿using Lib;
using Lib.Json;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Lib.Json
{
    [TestClass]
    public class ConfigPathManagerTest : PathManagerTestBase<ConfigPathManager>
    {
        [TestMethod]
        public void Test()
        {
            PathManager.SubDirectory = "A";

            Assert.AreEqual(@"Data\A\Config\x.json", Instance.GetFileName("x"));
            Assert.AreEqual(@"Data\A\Config\Test.Lib.TestBase.json", Instance.GetFileName(typeof(TestBase)));
            Assert.AreEqual(@"Data\A\Config\Test.Lib.TestBase.json", Instance.GetFileName<TestBase>());
            Assert.AreEqual(@"Data\A\Config\Test.Lib.TestBase\ABC.json", Instance.GetFileNameByKey("ABC", typeof(TestBase)));
            Assert.AreEqual(@"Data\A\Config\Test.Lib.TestBase\ABC.json", Instance.GetFileNameByKey<TestBase>("ABC"));

            Assert.AreEqual(@"Data\Default\Config\x.json", Instance.GetFileNameDefault("x"));
            Assert.AreEqual(@"Data\Default\Config\Test.Lib.TestBase.json", Instance.GetFileNameDefault(typeof(TestBase)));
            Assert.AreEqual(@"Data\Default\Config\Test.Lib.TestBase.json", Instance.GetFileNameDefault<TestBase>());
            //Assert.AreEqual(@"Data\Default\Config\Test.Lib.TestBase\ABC.json", Instance.GetFileNameDefaultByKey("ABC", typeof(TestBase)));
            //Assert.AreEqual(@"Data\Default\Config\Test.Lib.TestBase\ABC.json", Instance.GetFileNameDefaultByKey<TestBase>("ABC"));

            PathManager.SubDirectory = PathManager.SubDirectoryDefault;
        }
    }
}
