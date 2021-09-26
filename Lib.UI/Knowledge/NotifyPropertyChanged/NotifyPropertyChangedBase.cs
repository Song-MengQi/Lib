using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Lib.UI
{
    public abstract class NotifyPropertyChangedBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (default(PropertyChangedEventHandler) != PropertyChanged) PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    public abstract class NotifyPropertyChangedBase<T> : NotifyPropertyChangedBase
        where T : NotifyPropertyChangedBase<T>, new()
    {
        public string Key { get { return IoCManager<T>.GetKey(this as T); } }

        public static T Instance
        {
            get { return IoC<T>.GetInstance(()=>{
                PathManager.DirectoryChangedAction += UnsetInstance;
                return new T();
            }); }
            set { IoC<T>.Instance = value; }
        }
        public static void UnsetInstance() { IoC<T>.UnsetInstance(); }

        public static T GetInstance(string key) { return IoCManager<T>.GetInstance(key, ()=>{
            PathManager.DirectoryChangedAction += () => UnsetInstance(key);
            return new T();
        }); }
        public static void SetInstance(string key, T value) { IoCManager<T>.SetInstance(key, value); }
        public static void UnsetInstance(string key) { IoCManager<T>.UnsetInstance(key); }
    }
    public abstract class NotifyPropertyChangedBase<T, IT> : NotifyPropertyChangedBase
        where T : NotifyPropertyChangedBase<T, IT>, IT, new()
        where IT : class
    {
        public string Key { get { return IoCManager<IT>.GetKey(this as T); } }

        public static IT Instance
        {
            get { return IoC<IT>.GetInstance(()=>{
                PathManager.DirectoryChangedAction += UnsetInstance;
                return new T();
            }); }
            set { IoC<IT>.Instance = value; }
        }
        public static void UnsetInstance() { IoC<IT>.UnsetInstance(); }

        public static IT GetInstance(string key) { return IoCManager<IT>.GetInstance(key, ()=>{
            PathManager.DirectoryChangedAction += () => UnsetInstance(key);
            return new T();
        }); }
        public static void SetInstance(string key, IT value) { IoCManager<IT>.SetInstance(key, value); }
        public static void UnsetInstance(string key) { IoCManager<IT>.UnsetInstance(key); }
    }
}