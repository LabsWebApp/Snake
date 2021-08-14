using System;
using Library.Shapes;
using static System.Console;

namespace Library
{
    /// <summary>
    /// MEMENTO EXCEPTIO
    /// </summary>
    public class Field
    {
        public static readonly (int, int) 
            DefaultSize = (80, 30);
        public const int 
            MinWidth = 20, MinHeight = 10;

        private readonly (int, int) _size;
        private Field(int width, int height)
        {
            _size.Item1 = width--;
            _size.Item2 = height--;

            _upLine = new(0, width, 0, '+');
            _dawnLine = new(0, width, height, '+');

            _leftLine = new(0, height, 0, '+');
            _rightLine = new(0, height, width, '+');
        }

        private readonly HorizontalLine
            _upLine, _dawnLine;
        private readonly VerticalLine
            _leftLine, _rightLine;

        public static Field SetField(
            Action<int, int> setWindow = null,
            int width = -1, int height = -1)
        {
            if (width < 0) width = DefaultSize.Item1;
            else if (width < MinWidth) width = MinWidth;
            else if (width > LargestWindowWidth) width = LargestWindowWidth;

            if (height < 0) height = DefaultSize.Item2;
            else if (height < MinHeight) height = MinHeight;
            else if (height > LargestWindowHeight) height = LargestWindowHeight;

            Field result = new(width, height);
            Clear(); 
            setWindow?.Invoke(width, height);

            result._upLine.Draw();
            result._dawnLine.Draw();
            result._leftLine.Draw();
            result._rightLine.Draw();

            return result;
        }

    }
}
