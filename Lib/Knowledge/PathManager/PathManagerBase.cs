using System;
using System.IO;

namespace Lib
{
    public abstract class PathManagerBase<T> : SingletonBase<T>
        where T : PathManagerBase<T>, new()
    {
        protected virtual string SpecificDirectory { get { return typeof(T).Name.TrimOnceEnd("PathManager"); } }
        protected virtual string ExtensionName { get { return default(string); } }

        public string Directory { get { return Path.Combine(PathManager.Directory, SpecificDirectory); } }
        public string GetFileName(string shortFileName) { return Path.Combine(Directory, shortFileName).AddSuffixIfNotNullOrEmpty(ExtensionName, "."); }
        public string GetFileName(Type type) { return GetFileName(type.FullName); }
        public string GetFileName<TType>() { return GetFileName(typeof(TType)); }
        public string GetFileNameByKey(string key, Type type) { return GetFileName(type.FullName.AddSuffixIfNotNullOrEmpty(key, Path.DirectorySeparatorChar.ToString())); }
        public string GetFileNameByKey<TStorage>(string key) { return GetFileNameByKey(key, typeof(TStorage)); }

        public string DirectoryDefault { get { return Path.Combine(PathManager.DirectoryDefault, SpecificDirectory); } }
        public string GetFileNameDefault(string shortFileName) { return Path.Combine(DirectoryDefault, shortFileName).AddSuffixIfNotNullOrEmpty(ExtensionName, "."); }
        public string GetFileNameDefault(Type type) { return GetFileNameDefault(type.FullName); }
        public string GetFileNameDefault<TType>() { return GetFileNameDefault(typeof(TType)); }
        #region Default不存在有Key的情况
        //public string GetFileNameDefaultByKey(string key, Type type) { return GetFileNameDefault(type.FullName.AddSuffixIfNotNullOrEmpty(key, Path.DirectorySeparatorChar.ToString())); }
        //public string GetFileNameDefaultByKey<TStorage>(string key) { return GetFileNameDefaultByKey(key, typeof(TStorage)); }
        #endregion
    }
}