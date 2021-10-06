using Lib;
using System;
using System.Threading;

namespace Test.Lib
{
    public class SlimMock : MockBase, ISlim
    {
        public void Arrival(Action<ManualResetEventSlim> shockWaitAction, Action dispatchAction) { }
        public void Add(ManualResetEventSlim manualResetEventSlim) { }
        public void Remove(ManualResetEventSlim manualResetEventSlim) { }
        public bool Check(Func<bool> checkFunc, ManualResetEventSlim manualResetEventSlim) { return GetValue<bool>(); }
    }
}