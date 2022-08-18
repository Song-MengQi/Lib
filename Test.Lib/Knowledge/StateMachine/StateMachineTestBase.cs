using Lib;

namespace Test.Lib
{
    public abstract class StateMachineTestBase<T, IT, TState, TAction, TResult> : SingletonTestBase<T, IT>
        where T : SingletonBase<T, IT>, IT, new()
        where IT : IStateMachine<TState, TAction, TResult>
    {
        public abstract void TestDoAction();
    }
    public abstract class StateMachineTestBase<T, IT, TState, TAction> : StateMachineTestBase<T, IT, TState, TAction, TState>
        where T : SingletonBase<T, IT>, IT, new()
        where IT : IStateMachine<TState, TAction>
    {
    }
}