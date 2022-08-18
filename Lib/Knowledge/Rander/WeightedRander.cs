using System.Linq;

namespace Lib
{
    public class WeightedItem<T>
    {
        public T Value { get; set; }
        public uint Weight;
        public WeightedItem(T value, uint weight)
        {
            Value = value;
            Weight = weight;
        }
    }
    public class WeightedRander<T> : RanderBase<T>
    {
        private readonly WeightedItem<T>[] items;
        private int sum;
        //private void SortL()
        //{
        //    //l.Sort((x, y) => { return y.Weight - x.Weight; });
        //    l.Sort((x, y) => { return y.Weight.CompareTo(x.Weight); });
        //}
        public WeightedRander(T[] items, uint[] weights)
            : this(items.Select((item, i) => new WeightedItem<T>(item, weights[i])).ToArray())
        {
        }
        public WeightedRander(WeightedItem<T>[] weightItems)
            : base()
        {
            items = weightItems
                .Where(item => item.Weight > 0u)
                .OrderByDescending(item => item.Weight)
                .ToArray();
            sum = items.Sum(item => (int)item.Weight);
        }
        //public void Add(WeightedItem<T> weightItem)
        //{
        //    if (weightItem.Weight == 0) return;
        //    l.Add(weightItem);
        //    sum += (int)weightItem.Weight;
        //    SortL();
        //}
        //public void Add(T item, uint weight)
        //{
        //    if (weight == 0) return;
        //    l.Add(new WeightedItem<T>(item, weight));
        //    sum += weight;
        //    SortL();
        //}
        public override T Next()
        {
            uint rand = (uint)random.Next(sum);
            foreach (WeightedItem<T> item in items)
            {
                if (rand < item.Weight) return item.Value;
                rand -= item.Weight;
            }
            return default(T);//走不到这里
        }
    }
}