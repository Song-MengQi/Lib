namespace Lib
{
    public interface IRefresher<T>
    {
        void Refresh();
        T Get();
    }
}
