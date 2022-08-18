using System.IO;
using System.Linq;
using System.Security.AccessControl;

namespace Lib
{
    public static class DirectoryExtends
    {
        public static void EnsureNotExist(string directoryName)
        {
            if (Directory.Exists(directoryName)) Directory.Delete(directoryName, true);
        }
        public static void EnsureExist(string directoryName)
        {
            if (false == Directory.Exists(directoryName)) Directory.CreateDirectory(directoryName);
        }
        public static void Copy(string src, string dest)
        {
            src = src.TrimEnd(Path.DirectorySeparatorChar);
            dest = dest.TrimEnd(Path.DirectorySeparatorChar);
            if (false == Directory.Exists(src)) return;
            if (Path.GetFullPath(src) == Path.GetFullPath(dest)) return;
            EnsureExist(dest);//if (false == Directory.Exists(dest)) Directory.CreateDirectory(dest);

            string[] subSrcs = Directory.GetDirectories(src);
            foreach (string subSrc in subSrcs)
            {
                Copy(subSrc, dest + subSrc.Substring(src.Length));
            }

            string[] fileSrcs = Directory.GetFiles(src);
            foreach (string fileSrc in fileSrcs)
            {
                //File.Copy(fileSrc, Path.Combine(dest, Path.GetFileName(fileSrc)), true);
                File.Copy(fileSrc, dest + fileSrc.Substring(src.Length), true);
            }

            //或者
            //ProcessExtends.Execute(string.Format("xcopy {0} {1} /e /y", src, dest));
        }
        public static void Move(string src, string dest)
        {
            src = src.TrimEnd(Path.DirectorySeparatorChar);
            dest = dest.TrimEnd(Path.DirectorySeparatorChar);
            if (false == Directory.Exists(src)) return;
            if (Path.GetFullPath(src) == Path.GetFullPath(dest)) return;
            EnsureExist(dest);//if (false == Directory.Exists(dest)) Directory.CreateDirectory(dest);

            string[] subSrcs = Directory.GetDirectories(src);
            foreach (string subSrc in subSrcs)
            {
                Move(subSrc, dest + subSrc.Substring(src.Length));
            }

            string[] fileSrcs = Directory.GetFiles(src);
            foreach (string fileSrc in fileSrcs)
            {
                string destFileName = dest + fileSrc.Substring(src.Length);
                FileExtends.EnsureNotExist(destFileName);//if (File.Exists(destFileName)) File.Delete(destFileName);
                File.Move(fileSrc, destFileName);
            }

            Directory.Delete(src, true);

            //或者
            //并不好使，若目标已存在，拒绝访问
            //ProcessExtends.Execute(string.Format("move /y {0} {1}", src, dest));
        }
        //先Copy再Delete
        public static void SafeMove(string src, string dest)
        {
            Copy(src, dest);
            EnsureNotExist(src);
        }
        public static long GetSize(string directoryName)
        {
            if (false == Directory.Exists(directoryName)) return 0L;

            return Directory.GetDirectories(directoryName).Sum(subDirectoryName=>GetSize(subDirectoryName))
                + Directory.GetFiles(directoryName).Sum(fileName => FileExtends.GetSize(fileName));
        }

        public static void SetUsersFullControl(string directoryName)
        {
            DirectorySecurity directorySecurity = Directory.GetAccessControl(directoryName, AccessControlSections.All);
            directorySecurity.AddAccessRule(new FileSystemAccessRule(
                "Users",
                FileSystemRights.FullControl,
                InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit,
                PropagationFlags.None,
                AccessControlType.Allow));
            Directory.SetAccessControl(directoryName, directorySecurity);
        }
    }
}
