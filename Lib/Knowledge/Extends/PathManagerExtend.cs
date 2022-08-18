using System;
using System.IO;

namespace Lib
{
    public static class PathManagerExtend
    {
        //Directory=Data(\Sub)\Specific
        //Directory\shortFileName.ExtensionName
        public static string GetFileName(this IPathManager pathManager, string shortFileName) { return Path.Combine(pathManager.Directory, shortFileName).AddSuffixIfNotNullOrEmpty(pathManager.ExtensionName, "."); }
        //Directory\Type.ExtensionName
        public static string GetFileName(this IPathManager pathManager, Type type) { return pathManager.GetFileName(type.FullName); }
        //Directory\Type.ExtensionName
        public static string GetFileName<T>(this IPathManager pathManager) { return pathManager.GetFileName(typeof(T)); }
        //Directory\Type\key.ExtensionName
        public static string GetFileNameByKey(this IPathManager pathManager, string key, Type type) { return pathManager.GetFileName(type.FullName.AddSuffixIfNotNullOrEmpty(key, Path.DirectorySeparatorChar.ToString())); }
        //Directory\Type\key.ExtensionName
        public static string GetFileNameByKey<T>(this IPathManager pathManager, string key) { return pathManager.GetFileNameByKey(key, typeof(T)); }


        //Directory=Data\Default\Specific
        //DirectoryDefault\shortFileName.ExtensionName
        public static string GetFileNameDefault(this IPathManager pathManager, string shortFileName) { return Path.Combine(pathManager.DirectoryDefault, shortFileName).AddSuffixIfNotNullOrEmpty(pathManager.ExtensionName, "."); }
        //DirectoryDefault\Type.ExtensionName
        public static string GetFileNameDefault(this IPathManager pathManager, Type type) { return pathManager.GetFileNameDefault(type.FullName); }
        //DirectoryDefault\Type.ExtensionName
        public static string GetFileNameDefault<T>(this IPathManager pathManager) { return pathManager.GetFileNameDefault(typeof(T)); }
        #region Default不存在有Key的情况
        //public string GetFileNameDefaultByKey(string key, Type type) { return GetFileNameDefault(type.FullName.AddSuffixIfNotNullOrEmpty(key, Path.DirectorySeparatorChar.ToString())); }
        //public string GetFileNameDefaultByKey<T>(string key) { return GetFileNameDefaultByKey(key, typeof(T)); }
        #endregion
    }
}
