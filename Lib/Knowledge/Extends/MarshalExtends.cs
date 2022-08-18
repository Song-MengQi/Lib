using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Lib
{
    public static class MarshalExtends
    {
        public static int SizeOf<T>()
        {
            return Marshal.SizeOf(typeof(T));
        }

        public static IntPtr Alloc<T>(int count)
        {
            return Marshal.AllocHGlobal(SizeOf<T>() * count);
        }
        public static IntPtr BytesToIntPtr(byte[] bytes)
        {
            IntPtr intPtr = Marshal.AllocHGlobal(bytes.Length);
            Marshal.Copy(bytes, 0, intPtr, bytes.Length);
            return intPtr;
        }
        public static byte[] IntPtrToBytes(IntPtr intPtr, int length)
        {
            byte[] bytes = new byte[length];
            Marshal.Copy(intPtr, bytes, 0, length);
            return bytes;
        }
        public static T PtrToStructure<T>(IntPtr ptr)
        {
            return (T)Marshal.PtrToStructure(ptr, typeof(T));
        }
        public static void PtrToStructures<T>(IntPtr ptr, T[] ts)
        {
            int size = SizeOf<T>();
            for (int i = 0; i < ts.Length; ++i)
            {
                ts[i] = PtrToStructure<T>(ptr);
                ptr += size;
            }
        }
        public static void PtrToStructures<T>(IntPtr ptr, T[,] ts)
        {
            int size = SizeOf<T>();
            for (int i = 0; i < ts.GetLength(0); ++i)
            {
                for (int j = 0; j < ts.GetLength(1); ++j)
                {
                    ts[i, j] = PtrToStructure<T>(ptr);
                    ptr += size;
                }
            }
        }

        public static void StructuresToPtr(IEnumerable ts, IntPtr ptr)
        {
            foreach (var t in ts)
            {
                Marshal.StructureToPtr(t, ptr, false);
                ptr += Marshal.SizeOf(t.GetType());
            }
        }
        public static void StructuresToPtr<T>(IEnumerable<T> ts, IntPtr ptr)
        {
            int size = SizeOf<T>();
            foreach (T t in ts)
            {
                Marshal.StructureToPtr(t, ptr, false);
                ptr += size;
            }
        }
    }
}