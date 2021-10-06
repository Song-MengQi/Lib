namespace Lib
{
    public interface IRunnableQueue
    {
        bool IsRunning { get; }
        bool IsEmpty { get; }
        void Clear();
        void Assign(IRunnable runnable);
        void Run();
        //void Pause();
    }
}