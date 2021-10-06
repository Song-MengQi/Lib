using System.Collections.Generic;

namespace Lib
{
    public abstract class StateMachineBase<T, IT, TState, TAction, TResult> : SingletonBase<T, IT>, IStateMachine<TState, TAction, TResult>
        where T : IT, new()
        where IT : IStateMachine<TState, TAction, TResult>
    {
        public Dictionary<TState, Dictionary<TAction, TResult>> Dic { get; set; }
        protected StateMachineBase() : base()
        {
            Dic = default(Dictionary<TState, Dictionary<TAction, TResult>>);
        }
        protected virtual TResult GetDefaultResult(TState state) { return default(TResult); }
        public TResult DoAction(TState fromState, TAction action)
        {
            if (default(Dictionary<TState, Dictionary<TAction, TResult>>) == Dic) return GetDefaultResult(fromState);
            if (false == Dic.ContainsKey(fromState)) return GetDefaultResult(fromState);
            if (false == Dic[fromState].ContainsKey(action)) return GetDefaultResult(fromState);
            return Dic[fromState][action];
        }
    }
    public abstract class StateMachineBase<T, IT, TState, TAction> : StateMachineBase<T, IT, TState, TAction, TState>, IStateMachine<TState, TAction>
        where T : IT, new()
        where IT : IStateMachine<TState, TAction>
    {
        protected override TState GetDefaultResult(TState state) { return state; }
    }
}