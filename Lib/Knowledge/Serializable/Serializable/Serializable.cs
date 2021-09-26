using System;
using System.Threading.Tasks;

namespace Lib
{
    public class Serializable : ISerializable
    {
        private readonly SerialQueue serialQueue;
        public Serializable()
        {
            serialQueue = new SerialQueue();
        }
        public bool IsRunning { get { return serialQueue.IsRunning; } }
        public bool IsEmpty { get { return serialQueue.IsEmpty; } }
        public void Clear() { serialQueue.Clear(); }
        
        public void Invoke(Action action)
        {
            if (default(Action) == action) return;
            InvokeAsync(action).Wait();
        }
        public Task InvokeAsync(Action action)
        {
            if (default(Action) == action) return TaskExtends.RunEmpty();
            Task task = new Task(action);
            serialQueue.Assign(new RunnableTask(task));
            serialQueue.Run();
            return task;
        }
        public void InvokeBackground(Action action)
        {
            if (default(Action) == action) return;
            serialQueue.Assign(new RunnableAction(action));
            serialQueue.Run();
        }

        public T Invoke<T>(Func<T> func)
        {
            if (default(Func<T>) == func) return default(T);
            return InvokeAsync(func).Result;
        }
        public Task<T> InvokeAsync<T>(Func<T> func)
        {
            if (default(Func<T>) == func) return TaskExtends.RunEmpty<T>();
            Task<T> task = new Task<T>(func);
            serialQueue.Assign(new RunnableTask(task));
            serialQueue.Run();
            return task;
        }
    }
}