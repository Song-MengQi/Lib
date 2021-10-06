namespace Lib
{
    public class BoolRander : RanderBase<bool>
    {
        public override bool Next()
        {
            return random.Next(2) == 0;
        }
    }
}