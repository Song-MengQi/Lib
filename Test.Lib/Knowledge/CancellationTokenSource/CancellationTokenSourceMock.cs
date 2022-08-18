using Lib;
using System.Threading;

namespace Test.Lib
{
    public class CancellationTokenSourceMock : MockBase, ICancellationTokenSource
    {
        public bool IsCancellationRequested { get { return GetValue<bool>(); } }
        public CancellationToken Token { get { return GetValue<CancellationToken>(); } }
        public void Reset() { }
        public void Cancel() { }
    }
}
