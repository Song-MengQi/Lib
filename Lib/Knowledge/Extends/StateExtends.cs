namespace Lib
{
    public static class StateExtends
    {
        public static State GetState(bool state)
        {
            return state ? State.Positive : State.Negative;
        }
        public static State GetState(bool oldState, bool newState)
        {
            return oldState
                ? (newState ? State.Positive : State.PositiveToNegative)
                : (newState ? State.NegativeToPositive : State.Negative);
        }
    }
}