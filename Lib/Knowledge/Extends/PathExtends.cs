using System.IO;

namespace Lib
{
    public static class PathExtends
    {
        public static string EnsureNotEndWithDirectorySeparatorChar(string path)
        {
            return path.TrimEnd(Path.DirectorySeparatorChar);
        }
        public static string EnsureEndWithDirectorySeparatorChar(string path)
        {
            return EnsureNotEndWithDirectorySeparatorChar(path) + Path.DirectorySeparatorChar;
        }
    }
}