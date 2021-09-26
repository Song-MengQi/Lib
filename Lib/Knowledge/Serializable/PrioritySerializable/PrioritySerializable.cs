using System;
using System.Threading.Tasks;

namespace Lib
{
    public class PrioritySerializable : IPrioritySerializable
    {
        private readonly PrioritySerialQueue prioritySerialQueue;
        public PrioritySerializable(int numOfPriority = 1)
        {
            prioritySerialQueue = new PrioritySerialQueue(numOfPriority);
        }
        public bool IsRunning { get { return prioritySerialQueue.IsRunning; } }
        public bool IsEmpty { get { return prioritySerialQueue.IsEmpty; } }
        public void Clear() { prioritySerialQueue.Clear(); }
        public void InvokeBackground(Action action, int priority = 0)
        {
            if (default(Action) == action) return;
            prioritySerialQueue.Assign(new RunnableAction(action), priority);
            prioritySerialQueue.Run();
        }
        public Task InvokeAsync(Action action, int priority = 0)
        {
            if (default(Action) == action) return TaskExtends.RunEmpty();
            Task task = new Task(action);
            prioritySerialQueue.Assign(new RunnableTask(task), priority);
            prioritySerialQueue.Run();
            return task;
        }
        public void Invoke(Action action, int priority = 0)
        {
            if (default(Action) == action) return;
            InvokeAsync(action, priority).Wait();
        }

        public Task<T> InvokeAsync<T>(Func<T> func, int priority = 0)
        {
            if (default(Func<T>) == func) return TaskExtends.RunEmpty<T>();
            Task<T> task = new Task<T>(func);
            prioritySerialQueue.Assign(new RunnableTask(task), priority);
            prioritySerialQueue.Run();
            return task;
        }
        public T Invoke<T>(Func<T> func, int priority = 0)
        {
            if (default(Func<T>) == func) return default(T);
            return InvokeAsync(func, priority).Result;
        }
    }
}