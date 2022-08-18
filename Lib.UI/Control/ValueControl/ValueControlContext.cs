using System;
using System.Collections;
using System.Linq;

namespace Lib.UI
{
    public class ValueControlContext<TValue> : NotifyPropertyChangedBase
    {
        public Func<object, TValue> ConvertFunc { get; set; }
        public TValue Convert(object obj)
        {
            return ObjectExtends.EqualsDefault(ConvertFunc) ? (TValue)obj : ConvertFunc(obj);
        }
        #region OneTime
        #endregion
        #region OneWay
        private IEnumerable items;
        public IEnumerable Items
        {
            get { return items; }
            set
            {
                if (ObjectExtends.Equals(value, items)) return;
                items = value;
                NotifyPropertyChanged();
                NotifyPropertyChanged("HasTextBox");
                NotifyPropertyChanged("HasComboBox");
                if (HasComboBox) Item = Items.Generalize().FirstOrDefault();
            }
        }
        public bool HasTextBox { get { return IEnumerableExtends.IsNullOrEmpty(Items); } }
        public bool HasComboBox { get { return false==HasTextBox; } }
        #endregion
        #region TwoWay
        private TValue v;
        public TValue Value
        {
            get { return v; }
            set
            {
                if (ObjectExtends.Equals(value, v)) return;
                v = value;
                NotifyPropertyChanged();
            }
        }
        public object Item
        {
            get { return HasComboBox ? Items.Generalize().FirstOrDefault(item => ObjectExtends.Equals(Convert(item), Value)) : default(object); }
            set { Value = Convert(value); }
        }
        #endregion
    }
    public class ValueControlContext : ValueControlContext<object>
    {
    }
}