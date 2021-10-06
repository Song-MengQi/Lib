namespace Lib.Timer
{
    public interface ITimingRefresher<T> : IRefresher<T>
    {
        uint Period { get; }
    }
}