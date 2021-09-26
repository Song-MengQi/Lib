using Lib;
using System;
using System.Threading.Tasks;

namespace Test.Lib
{
    public class PrioritySerializableMock : MockBase, IPrioritySerializable
    {
        public bool IsRunning { get { return GetValue<bool>(); } }
        public bool IsEmpty { get { return GetValue<bool>(); } }
        public new void Clear() { }
        public void InvokeBackground(Action action, int priority = 0) { }
        public Task InvokeAsync(Action action, int priority = 0) { return GetTaskValue(); }
        public void Invoke(Action action, int priority = 0) { }
        public Task<T> InvokeAsync<T>(Func<T> func, int priority = 0) { return GetTaskValue<T>(); }
        public T Invoke<T>(Func<T> func, int priority = 0) { return GetValue<T>(); }
    }
}