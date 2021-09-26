using Lib;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Test.Lib
{
    public abstract class MockBase
    {
        private Dictionary<string, Queue<object>> expectValues = new Dictionary<string, Queue<object>>();
        public MockBase Expect(string method, object value)
        {
            if (false == expectValues.ContainsKey(method))
            {
                expectValues.Add(method, new Queue<object>());
            }
            expectValues[method].Enqueue(value);
            return this;
        }
        public void Clear()
        {
            if (expectValues.Count > 0) expectValues = new Dictionary<string, Queue<object>>();
        }
        protected T GetValue<T>([CallerMemberName] string method = default(string))
        {
            if (false == expectValues.ContainsKey(method)) return default(T);
            Queue<object> queue = expectValues[method];
            if (0 == queue.Count) return default(T);
            return (T)queue.Dequeue();
        }
        protected Task GetTaskValue() { return TaskExtends.RunEmpty(); }
        protected Task<T> GetTaskValue<T>()
        {
            T result = GetValue<T>();
            return Task.Run<T>(() => result);
        }
    }
}