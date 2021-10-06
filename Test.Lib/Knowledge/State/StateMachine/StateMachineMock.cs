using System.Collections.Generic;
using Lib;

namespace Test.Lib
{
    public class StateMachineMock<TState, TAction, TResult> : MockBase, IStateMachine<TState, TAction, TResult>
        where TState : struct
        where TAction : struct
    {
        public Dictionary<TState, Dictionary<TAction, TResult>> Dic { get { return GetValue<Dictionary<TState, Dictionary<TAction, TResult>>>(); } set { } }
        public TResult DoAction(TState fromState, TAction action) { return GetValue<TResult>(); }
    }
    public class StateMachineMock<TState, TAction> : StateMachineMock<TState, TAction, TState>, IStateMachine<TState, TAction, TState>
        where TState : struct
        where TAction : struct
    {
    }
}