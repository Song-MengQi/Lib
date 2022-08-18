using System.IO;

namespace Lib
{
    public abstract class PathManagerBase<T> : SingletonBase<T>, IPathManager
        where T : PathManagerBase<T>, new()
    {
        protected virtual string SpecificDirectory { get { return typeof(T).Name.TrimOnceEnd("PathManager"); } }
        public string Directory { get { return Path.Combine(PathManager.Directory, SpecificDirectory); } }
        public string DirectoryDefault { get { return Path.Combine(PathManager.DirectoryDefault, SpecificDirectory); } }
        public virtual string ExtensionName { get { return default(string); } }
    }
}