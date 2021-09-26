using System.Collections.Generic;

namespace Lib
{
    public abstract class StateMachineBase<T, IT, TState, TAction> : SingletonBase<T, IT>, IStateMachine<TState, TAction>
        where T : IT, new()
        where IT : IStateMachine<TState, TAction>
    {
        public Dictionary<TState, Dictionary<TAction, TState>> Dic { get; set; }
        protected StateMachineBase() : base()
        {
            Dic = default(Dictionary<TState, Dictionary<TAction, TState>>);
        }
        public TState DoAction(TState fromState, TAction action)
        {
            if (default(Dictionary<TState, Dictionary<TAction, TState>>) == Dic) return fromState;
            if (false == Dic.ContainsKey(fromState)) return fromState;
            if (false == Dic[fromState].ContainsKey(action)) return fromState;
            return Dic[fromState][action];
        }
    }
}