using System.IO;
using Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Lib
{
    [TestClass]
    public class DirectoryExtendsTest : TestBase
    {
        [TestMethod]
        public void Test()
        {
            string str1 = "asdfasdf";
            string str2 = "asdas";
            Directory.CreateDirectory("A");
            
            #region 需要管理员权限
            //DirectoryExtends.SetUsersFullControl("A");
            #endregion

            File.WriteAllText("A/1.txt", str1);
            Directory.CreateDirectory("A/AA");
            File.WriteAllText("A/AA/2.txt", str2);


            DirectoryExtends.DeleteIfExists("B");
            Assert.AreEqual(DirectoryExtends.GetSize("A"), str1.Length + str2.Length);
            Assert.AreEqual(DirectoryExtends.GetSize("B"), 0L);
            Assert.IsFalse(Directory.Exists("B"));
            DirectoryExtends.Copy("B", "C");
            Assert.IsFalse(Directory.Exists("C"));

            DirectoryExtends.Copy("A", "B");
            Assert.IsTrue(Directory.Exists("A"));
            Assert.IsTrue(Directory.Exists("B"));

            DirectoryExtends.Move("A", "B");
            Assert.IsFalse(Directory.Exists("A"));
            Assert.IsTrue(Directory.Exists("B"));

            DirectoryExtends.SafeMove("B", "A");
            Assert.IsFalse(Directory.Exists("B"));
            Assert.IsTrue(Directory.Exists("A"));

            DirectoryExtends.DeleteIfExists("A");
            Assert.IsFalse(Directory.Exists("A"));
        }
    }
}