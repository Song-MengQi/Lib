using Lib;
using System.Collections.Generic;

namespace Test.Lib
{
    public class StateMock<TState, TAction> : MockBase, IStateMachine<TState, TAction>
        where TState : struct
        where TAction : struct
    {
        public Dictionary<TState, Dictionary<TAction, TState>> Dic { get { return GetValue<Dictionary<TState, Dictionary<TAction, TState>>>(); } set { } }
        public TState DoAction(TState fromState, TAction action) { return GetValue<TState>(); }
    }
    //public class StateMock<TState, TAction, TResult> : MockBase, IStateMachine<TState, TAction, TResult>
    //    where TState : struct
    //    where TAction : struct
    //    where TResult : class
    //{
    //    public Dictionary<TState, Dictionary<TAction, TResult>> Dic { get { return GetValue<Dictionary<TState, Dictionary<TAction, TResult>>>(); } set { } }
    //    public TResult DoAction(TState fromState, TAction action) { return GetValue<TResult>(); }
    //}
}