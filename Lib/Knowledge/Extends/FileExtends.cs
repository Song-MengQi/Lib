using System.IO;
using System.Security.AccessControl;
using System.Text;

namespace Lib
{
    public static class FileExtends
    {
        public static byte[] ReadBytes(string fileName) { return File.ReadAllBytes(fileName); }
        public static string ReadText(string fileName) { return File.ReadAllText(fileName, Encoding.UTF8); }
        public static string[] ReadLines(string fileName) { return File.ReadAllLines(fileName, Encoding.UTF8); }
        public static void ReadBytes(string fileName, long offset, int length, out long fileLength, out byte[] content)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read/*, FileShare.Read, 1 << 16*/);
            fileLength = fs.Length;
            if (offset >= 0 && offset < fileLength)
            {
                fs.Position = offset;
                if (offset + length >= fileLength)
                {
                    length = (int)(fileLength - offset);
                }
                content = new byte[length];
                fs.Read(content, 0, length);
            }
            else
            {
                content = new byte[0];
            }
            fs.Close();
        }
        //public static void EnsureDirectoryExist(string fileName) { Directory.CreateDirectory(Path.GetDirectoryName(fileName)); }
        public static void EnsureDirectoryExist(string fileName) { Directory.GetParent(fileName).Create(); }

        public static void WriteText(string fileName, string str)
        {
            EnsureDirectoryExist(fileName);
            File.WriteAllText(fileName, str, Encoding.UTF8);
        }
        public static void WriteLine(string fileName, string str) { WriteText(fileName, str + System.Environment.NewLine); }
        public static void WriteLines(string fileName, string[] strs)
        {
            EnsureDirectoryExist(fileName);
            File.WriteAllLines(fileName, strs, Encoding.UTF8);
        }
        public static void WriteBytes(string fileName, byte[] bytes)
        {
            EnsureDirectoryExist(fileName);
            File.WriteAllBytes(fileName, bytes);
        }
        public static void AppendText(string fileName, string str)
        {
            EnsureDirectoryExist(fileName);
            File.AppendAllText(fileName, str);
        }
        public static void AppendLine(string fileName, string str) { AppendText(fileName, str + System.Environment.NewLine); }
        public static void AppendLines(string fileName, string[] strs)
        {
            EnsureDirectoryExist(fileName);
            File.AppendAllLines(fileName, strs, Encoding.UTF8);
        }
        public static void AppendBytes(string fileName, byte[] bytes)
        {
            EnsureDirectoryExist(fileName);
            FileStream fs = new FileStream(fileName, FileMode.Append);
            fs.Write(bytes, 0, bytes.Length);
            fs.Close();
        }
        public static void Copy(string sourceFileName, string destFileName)
        {
            if (false == File.Exists(sourceFileName)) throw new FileNotFoundException();
            EnsureDirectoryExist(destFileName);
            File.Copy(sourceFileName, destFileName, true);
        }
        public static void Move(string sourceFileName, string destFileName)
        {
            if (false == File.Exists(sourceFileName)) throw new FileNotFoundException();
            if (File.Exists(destFileName)) File.Delete(destFileName);
            EnsureDirectoryExist(destFileName);
            File.Move(sourceFileName, destFileName);
        }
        //先Copy再Delete
        public static void SafeMove(string sourceFileName, string destFileName)
        {
            Copy(sourceFileName, destFileName);
            File.Delete(sourceFileName);
        }
        public static long GetSize(string fileName)
        {
            return File.Exists(fileName) ? new FileInfo(fileName).Length : 0L;
        }

        public static void SetUsersFullControl(string fileName)
        {
            FileSecurity fileSecurity = File.GetAccessControl(fileName, AccessControlSections.All);
            fileSecurity.AddAccessRule(new FileSystemAccessRule(
                "Users",
                FileSystemRights.FullControl,
                AccessControlType.Allow));
            File.SetAccessControl(fileName, fileSecurity);
        }
    }
}