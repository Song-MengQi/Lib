using System.Collections.Generic;

namespace Lib
{
    public interface IStateMachine<TState, TAction, TResult>
    {
        Dictionary<TState, Dictionary<TAction, TResult>> Dic { get; set; }
        TResult DoAction(TState fromState, TAction action);
    }
    public interface IStateMachine<TState, TAction> : IStateMachine<TState, TAction, TState>
    {
    }
}