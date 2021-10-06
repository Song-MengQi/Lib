using Lib;
using System;

namespace Test.Lib
{
    public class LockableMock : MockBase, ILockable
    {
        public void Invoke(Action action) { }
        public T Invoke<T>(Func<T> func) { return GetValue<T>(); }
    }
}