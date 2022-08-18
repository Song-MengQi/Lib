using Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace Test.Lib
{
    [TestClass]
    public class FileExtendsTest : TestBase
    {
        [TestMethod]
        public void Test()
        {
            string fileName = "FileExtendsTest/test";
            string fileName2 = "FileExtendsTest/test2";
            FileExtends.EnsureNotExist("fileName");
            DirectoryExtends.EnsureNotExist("FileExtendsTest");
            FileExtends.EnsureDirectoryExist(fileName);
            Assert.IsTrue(Directory.Exists("FileExtendsTest"));

            string[] lines;
            string text;
            byte[] bytes;

            Assert.AreEqual(FileExtends.GetSize(fileName), 0L);

            FileExtends.AppendLines(fileName, new string[]{
                "0",
                "1"
            });

            #region 需要管理员权限
            //FileExtends.SetUsersFullControl(fileName);
            #endregion

            lines = FileExtends.ReadLines(fileName);
            Assert.AreEqual(lines.Length, 2);
            Assert.AreEqual(lines[0], "0");
            Assert.AreEqual(lines[1], "1");

            FileExtends.AppendLine(fileName, "2");
            lines = FileExtends.ReadLines(fileName);
            Assert.AreEqual(lines.Length, 3);
            Assert.AreEqual(lines[0], "0");
            Assert.AreEqual(lines[1], "1");
            Assert.AreEqual(lines[2], "2");

            FileExtends.EnsureNotExist(fileName);
            FileExtends.AppendText(fileName, "X");
            text = FileExtends.ReadText(fileName);
            Assert.AreEqual(text, "X");



            FileExtends.WriteLines(fileName, new string[]{
                "0",
                "1"
            });
            lines = FileExtends.ReadLines(fileName);
            Assert.AreEqual(lines.Length, 2);
            Assert.AreEqual(lines[0], "0");
            Assert.AreEqual(lines[1], "1");

            FileExtends.WriteLine(fileName, "2");
            lines = FileExtends.ReadLines(fileName);
            Assert.AreEqual(lines.Length, 1);
            Assert.AreEqual(lines[0], "2");

            FileExtends.WriteText(fileName, "X");
            text = FileExtends.ReadText(fileName);
            Assert.AreEqual(text, "X");


            FileExtends.EnsureNotExist(fileName);
            FileExtends.WriteBytes(fileName, new byte[]{0, 1});
            Assert.AreEqual(FileExtends.GetSize(fileName), 2L);

            bytes = FileExtends.ReadBytes(fileName);
            Assert.AreEqual(bytes.Length, 2);
            Assert.AreEqual(bytes[0], (byte)0);
            Assert.AreEqual(bytes[1], (byte)1);

            FileExtends.AppendBytes(fileName, new byte[]{ 2 });
            long length;
            FileExtends.ReadBytes(fileName, 2, 1, out length, out bytes);
            Assert.AreEqual(length, 3);
            Assert.AreEqual(bytes.Length, 1);
            Assert.AreEqual(bytes[0], (byte)2);

            FileExtends.ReadBytes(fileName, -1, 1, out length, out bytes);
            Assert.AreEqual(length, 3);
            Assert.AreEqual(bytes.Length, 0);
            FileExtends.ReadBytes(fileName, 4, 1, out length, out bytes);
            Assert.AreEqual(length, 3);
            Assert.AreEqual(bytes.Length, 0);

            FileExtends.Move(fileName, fileName);
            FileExtends.Copy(fileName, fileName);

            FileExtends.Copy(fileName, fileName2);
            FileExtends.Move(fileName, fileName2);
            Assert.IsFalse(File.Exists(fileName));
            Assert.IsTrue(File.Exists(fileName2));

            FileExtends.SafeMove(fileName2, fileName);
            Assert.IsFalse(File.Exists(fileName2));
            Assert.IsTrue(File.Exists(fileName));

            DirectoryExtends.EnsureNotExist("FileExtendsTest");
            Assert.IsFalse(Directory.Exists("FileExtendsTest"));
        }
        [TestMethod]
        public void TestException()
        {
            try { FileExtends.Copy("ABCDEFG", "A"); }
            catch (Exception e) { Assert.IsInstanceOfType(e, typeof(FileNotFoundException)); }

            try { FileExtends.Move("ABCDEFG", "A"); }
            catch (Exception e) { Assert.IsInstanceOfType(e, typeof(FileNotFoundException)); }
        }
    }
}