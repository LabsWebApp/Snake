using Library.Shapes;

namespace Library.Helpers
{
    internal static class StaticSettings
    {
        public const char
            SnakeChar = '*',
            TopFrameChar = '+', //'\u0305'
            DownFrameChar = TopFrameChar,
            LeftFrameChar = '|',
            RightFrameChar = LeftFrameChar;

        public static readonly (int, int)
            DefaultFieldSize = (80, 30);

        public const int
            MinWidth = 20, MinHeight = 10;

        public static Snake StartingSnake() =>
            new (new Point(4, 3, SnakeChar), 4, Direction.Right);
    }
}
