using Lib;

namespace Test.Lib
{
    public class InvokableWithRunningMock : InvokableMock, IInvokableWithRunning
    {
        public bool IsRunning { get; set; }
    }
}