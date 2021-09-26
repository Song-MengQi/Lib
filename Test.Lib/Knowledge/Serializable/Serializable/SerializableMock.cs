using System;
using System.Threading.Tasks;
using Lib;

namespace Test.Lib
{
    public class SerializableMock : MockBase, ISerializable
    {
        public bool IsRunning { get { return GetValue<bool>(); } }
        public bool IsEmpty { get { return GetValue<bool>(); } }
        public new void Clear() { }
        public void InvokeBackground(Action action) { }
        public Task InvokeAsync(Action action) { return GetTaskValue(); }
        public void Invoke(Action action) { }
        public Task<T> InvokeAsync<T>(Func<T> func) { return GetTaskValue<T>(); }
        public T Invoke<T>(Func<T> func) { return GetValue<T>(); }
    }
}
