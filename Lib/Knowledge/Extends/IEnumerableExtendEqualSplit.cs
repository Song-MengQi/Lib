using System;
using System.Collections.Generic;
using System.Linq;

namespace Lib
{
    public static partial class IEnumerableExtend
    {
        //相等分割
        //A,A,A,B=>[A,A,A],[B]
        public static TSource[][] EqualSplit<TSource, TValue>(this IEnumerable<TSource> sources, Func<TSource, TValue> func)
        {
            List<TSource[]> list = new List<TSource[]>();
            List<TSource> tempList = new List<TSource>();//待定列表
            Action decideAction = ()=>{//决定
                if (false == tempList.Any()) return;//待定列表为空
                list.Add(tempList.ToArray());
                tempList.Clear();
            };

            TValue lastValue = default(TValue);
            foreach (TSource source in sources)
            {
                TValue value = func(source);
                if (false==ObjectExtends.Equals(lastValue, value))
                {
                    decideAction();//待定的有结论了
                }
                tempList.Add(source);
                lastValue = value;
            }
            decideAction();
            return list.ToArray();
        }
        public static TSource[][] EqualSplit<TSource>(this IEnumerable<TSource> sources)
        {
            return sources.EqualSplit(source=>source);
        }
    }
}
