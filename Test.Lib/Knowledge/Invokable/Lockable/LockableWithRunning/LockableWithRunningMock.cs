using Lib;

namespace Test.Lib
{
    public class LockableWithRunningMock : LockableMock, ILockableWithRunning
    {
        public bool IsRunning { get; set; }
    }
}