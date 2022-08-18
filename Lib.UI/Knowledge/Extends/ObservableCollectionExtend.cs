using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Lib.UI
{
    public static class ObservableCollectionExtend
    {
        //按照ts的顺序排序
        private static void Sort<T>(this ObservableCollection<T> observableCollection, T[] ts)
        {
            for (int i = 0; i < observableCollection.Count; ++i)
            {
                int j = observableCollection.IndexOf(ts[i]);
                if (i == j) continue;
                observableCollection.Move(j, i);
            }
        }
        public static void Sort<T>(this ObservableCollection<T> observableCollection, bool desc = false)
        {
            observableCollection.Sort(observableCollection.Order(desc).ToArray());
        }
        public static void Sort<T>(this ObservableCollection<T> observableCollection, IComparer<T> comparer, bool desc = false)
        {
            observableCollection.Sort(observableCollection.Order(comparer, desc).ToArray());
        }
        public static void SortBy<T, TKey>(this ObservableCollection<T> observableCollection, Func<T, TKey> keySelector, bool desc = false)
        {
            observableCollection.Sort(observableCollection.OrderBy(keySelector, desc).ToArray());
        }
        public static void SortBy<T, TKey>(this ObservableCollection<T> observableCollection, Func<T, TKey> keySelector, IComparer<TKey> comparer, bool desc = false)
        {
            observableCollection.Sort(observableCollection.OrderBy(keySelector, comparer, desc).ToArray());
        }
    }
}
