using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Lib.UI
{
    public static class ObservableCollectionExtend
    {
        private static void Sort<T>(this ObservableCollection<T> observableCollection, T[] ts)
        {
            for (int i = 0; i < observableCollection.Count; ++i)
            {
                int j = observableCollection.IndexOf(ts[i]);
                if (i == j) continue;
                observableCollection.Move(j, i);
            }
        }
        public static void Sort<T>(this ObservableCollection<T> observableCollection, IComparer<T> comparer)
        {
            T[] ts = observableCollection.ToArray();
            Array.Sort(ts, comparer);
            observableCollection.Sort(ts);
        }
        public static void Sort<T>(this ObservableCollection<T> observableCollection)
        {
            observableCollection.Sort(Comparer<T>.Default);
        }
        public static void SortBy<T, TKey>(this ObservableCollection<T> observableCollection, Func<T, TKey> keySelector, bool desc = false)
        {
            observableCollection.Sort(observableCollection.OrderBy(keySelector, desc).ToArray());
        }
    }
}
