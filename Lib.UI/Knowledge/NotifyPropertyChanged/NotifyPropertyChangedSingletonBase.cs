using System;
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
        protected virtual bool SetProperty<TValue>(ref TValue oldValue, TValue newValue, [CallerMemberName] string propertyName = null)
        {
            if (object.Equals(oldValue, newValue)) return false;
            oldValue = newValue;
            NotifyPropertyChanged(propertyName);
            return true;
        }
        protected virtual bool SetProperty<TValue>(ref TValue oldValue, TValue newValue, Action changedAction, [CallerMemberName] string propertyName = null)
        {
            if (object.Equals(oldValue, newValue)) return false;
            oldValue = newValue;
            ActionExtends.Invoke(changedAction);
            NotifyPropertyChanged(propertyName);
            return true;
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
        protected virtual bool SetProperty<TValue>(ref TValue oldValue, TValue newValue, [CallerMemberName] string propertyName = null)
        {
            if (object.Equals(oldValue, newValue)) return false;
            oldValue = newValue;
            NotifyPropertyChanged(propertyName);
            return true;
        }
        protected virtual bool SetProperty<TValue>(ref TValue oldValue, TValue newValue, Action changedAction, [CallerMemberName] string propertyName = null)
        {
            if (object.Equals(oldValue, newValue)) return false;
            oldValue = newValue;
            ActionExtends.Invoke(changedAction);
            NotifyPropertyChanged(propertyName);
            return true;
        }
    }
}