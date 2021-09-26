using System;
using System.Collections.Generic;

namespace Lib
{
    public static class ArrayExtends
    {
        public static bool IsNullOrEmpty<T>(T[] array)
        {
            return default(T[]) == array || 0 == array.Length;
        }
        public static T[] GetSpecialOrder<T, TKey>(T[] src, TKey[] preKeys, Func<T, TKey> getKeyFunc)
        {
            T[] result = new T[src.Length];
            List<T> srcList = new List<T>(src);
            int i = 0;
            foreach (TKey preKey in preKeys)
            {
                int index = srcList.FindIndex(item => getKeyFunc(item).Equals(preKey));
                if (index >= 0)
                {
                    result[i++] = srcList[index];
                    srcList.RemoveAt(index);
                }
            }
            srcList.CopyTo(result, i);
            return result;
        }
        public static T[] GetArray<T>(int length, Func<T> func)
        {
            T[] ts = new T[length];
            for (int i = 0; i < length; ++i)
            {
                ts[i] = func();
            }
            return ts;
        }
        public static T[] GetArray<T>(int length, Func<int, T> func)
        {
            T[] ts = new T[length];
            for (int i = 0; i < length; ++i)
            {
                ts[i] = func(i);
            }
            return ts;
        }
        public static T[] GetCopy<T>(T[] array)
        {
            //return GetCopy(array, array.Length);
            //return array.ToArray();
            return (T[])array.Clone();
        }
        public static T[] GetCopy<T>(T[] array, int length)
        {
            T[] ts = new T[length];
            Array.Copy(array, ts, length);
            return ts;
        }
        public static T[] GetCopy<T>(T[] array, int sourceIndex, int length)
        {
            T[] ts = new T[length];
            Array.Copy(array, sourceIndex, ts, 0, length);
            return ts;
        }

        public static void Clear<T>(T[] array) { Array.Clear(array, 0, array.Length); }

        public static void SetValue<T>(T[] array, T value)
        {
            for (int i = 0; i < array.Length; ++i)
            {
                array[i] = value;
            }
        }
        public static void SetValue<T>(T[] array, T value, int index, int length)
        {
            int end = Math.Min(array.Length, index + length);
            for (int i = index; i < end; ++i)
            {
                array[i] = value;
            }
        }
    }
}