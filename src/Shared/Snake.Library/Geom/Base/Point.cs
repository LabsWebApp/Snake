using static System.Console;

namespace Library.Geom.Base
{
    public struct Point
    {
        public int X;
        public int Y;
        public char Symbol;

        public Point(int x, int y, char symbol)
        {
            Symbol = symbol;
            X = x;
            Y = y;
        }

        public void Clear()
        {
            Symbol = ' ';
            Draw();
        }

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

        public bool IsHit(Point p) => p.X == X && p.Y == Y;
        public bool IsHit(int x, int y) => x == X && y == Y;
    }
}
