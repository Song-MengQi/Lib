using Lib.Json;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Test.Lib.Json
{
    [TestClass]
    public class FileExtendsTest : TestBase
    {
        private class FileExtendsTestClass
        {
            public int X { get; set; }
            public string Y { get; set; }
        }
        [TestMethod]
        public void Test()
        {
            FileExtendsTestClass fetc = new FileExtendsTestClass {
                X = 1,
                Y = "2"
            };
            string fileName = "FileExtendsTest.json";
            FileExtends.SaveJson(fileName, fetc);
            FileExtendsTestClass fetc1 = FileExtends.LoadJson<FileExtendsTestClass>(fileName);
            Assert.IsNotNull(fetc1);
            Assert.AreEqual(fetc.X, fetc1.X);
            Assert.AreEqual(fetc.Y, fetc1.Y);

            File.Delete(fileName);
        }
    }
}