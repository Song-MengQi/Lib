
namespace Lib
{
    public interface IInvokableWithRunning : IInvokable
    {
        bool IsRunning { get; }
    }
}