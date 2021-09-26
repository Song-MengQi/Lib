namespace Lib.UI
{
    public static class DirectionExtend
    {
        public static double ToAngle(this Direction direction)
        {
            switch(direction)
            {
                case Direction.Up:
                    return 0d;
                case Direction.RightUp:
                    return 45d;
                case Direction.Right:
                    return 90d;
                case Direction.RightDown:
                    return 135d;
                case Direction.Down:
                    return 180d;
                case Direction.LeftDown:
                    return 225d;
                case Direction.Left:
                    return 270d;
                case Direction.LeftUp:
                    return 315d;
            }
            return 0d;
        }
    }
}