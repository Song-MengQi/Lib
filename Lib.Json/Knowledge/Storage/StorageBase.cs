using System.IO;

namespace Lib.Json
{
    public abstract class StorageBase
    {
        private readonly ISerializable serializable;
        protected StorageBase()
        {
            serializable = new Serializable();
        }
        public void Save(string fileName) { serializable.Invoke(()=>FileExtends.SaveJson(fileName, this)); }
        public static T Load<T>(string fileName) { return FileExtends.LoadJson<T>(fileName); }
        public static T LoadOrNew<T>(string fileName)
            where T : new()
        {
            return File.Exists(fileName) ? FileExtends.LoadJson<T>(fileName) : new T();
        }
        public static T Load<T>(string fileName, string fileNameDefault) { return Load<T>(File.Exists(fileName) ? fileName : fileNameDefault); }
        public static T LoadOrNew<T>(string fileName, string fileNameDefault)
            where T : new()
        {
            return File.Exists(fileName)
                ? Load<T>(fileName)
                : (File.Exists(fileNameDefault)
                    ? Load<T>(fileNameDefault)
                    : new T());
        }
    }
    public abstract class StoragePathManagerBase<T> : PathManagerBase<T>
        where T : StoragePathManagerBase<T>, new()
    {
        protected override string ExtensionName { get { return "json"; } }
    }
    public abstract class StorageBase<T, TPathManager> : StorageBase
        where T : StorageBase<T, TPathManager>, new()
        where TPathManager : StoragePathManagerBase<TPathManager>, new()
    {
        #region IoC
        public static T Instance
        {
            get { return IoC<T>.GetInstance(()=>{
                PathManager.DirectoryChangedAction += UnsetInstance;
                return LoadOrNew<T>(GetFileName(), GetFileNameDefault());
            }); }
            set { IoC<T>.Instance = value; }
        }
        public static void UnsetInstance() { IoC<T>.UnsetInstance(); }

        public static T GetInstance(string key)
        {
            return IoCManager<T>.GetInstance(key, ()=>{
                PathManager.DirectoryChangedAction += ()=>UnsetInstance(key);
                return LoadOrNew<T>(GetFileName(key), GetFileNameDefault());
            });
        }
        public static void SetInstance(string key, T value) { IoCManager<T>.SetInstance(key, value); }
        public static void UnsetInstance(string key) { IoCManager<T>.UnsetInstance(key); }
        protected string Key { get { return IoCManager<T>.GetKey(this as T); } }
        #endregion
        protected static string GetFileName(string key = default(string)) { return StoragePathManagerBase<TPathManager>.Instance.GetFileNameByKey<T>(key); }
        protected static string GetFileNameDefault() { return StoragePathManagerBase<TPathManager>.Instance.GetFileNameDefault<T>(); }
        public virtual void Save() { Save(GetFileName(Key)); }
    }
    public class StoragePathManager : StoragePathManagerBase<StoragePathManager>
    {
    }
    public abstract class StorageBase<T> : StorageBase<T, StoragePathManager>
        where T : StorageBase<T>, new()
    {
    }
}