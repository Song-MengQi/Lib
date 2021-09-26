namespace Lib.UI
{
    public static class DirectionExtends
    {
        public static double ToAngle(Direction direction) { return direction.ToAngle(); }
        public static Direction ToDirection(double angle)
        {
            switch(((int)(angle % 360) + 23) / 45)
            {
                case 0:
                    return Direction.Up;
                case 1:
                    return Direction.RightUp;
                case 2:
                    return Direction.Right;
                case 3:
                    return Direction.RightDown;
                case 4:
                    return Direction.Down;
                case 5:
                    return Direction.LeftDown;
                case 6:
                    return Direction.Left;
                case 7:
                    return Direction.LeftUp;
            }
            return Direction.Up;
        }
    }
}