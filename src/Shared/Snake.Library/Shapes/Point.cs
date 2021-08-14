using static System.Console;

namespace Library.Shapes
{
    public struct Point
    {
        public Point(int x, int y, char symbol)
        {
            Symbol = symbol;
            X = x;
            Y = y;
        }

        public int X { get; set; }
        public int Y { get; set; }

        public char Symbol { get; set; }

        public void Draw()
        {
            SetCursorPosition(X, Y);
            Write(Symbol);
        }

        public void Move(int offset, Direction direction)
        {
            switch (direction)
            {
                case Direction.Right:
                    X += offset;
                    break;
                case Direction.Left:
                    X -= offset;
                    break;
                case Direction.Down:
                    Y += offset;
                    break;
                case Direction.Up:
                    Y -= offset;
                    break;
            }
        }

    }
}
