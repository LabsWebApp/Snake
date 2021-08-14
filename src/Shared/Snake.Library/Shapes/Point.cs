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
    }
}
