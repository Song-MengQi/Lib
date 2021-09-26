using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Lib.UI
{
    public abstract class NotifyPropertyChangedSingletonBase<T> : SingletonBase<T>, INotifyPropertyChanged
        where T : new()
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (default(PropertyChangedEventHandler) != PropertyChanged) PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    public abstract class NotifyPropertyChangedSingletonBase<T, IT> : SingletonBase<T, IT>, INotifyPropertyChanged
        where T : IT, new()
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (default(PropertyChangedEventHandler) != PropertyChanged) PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}