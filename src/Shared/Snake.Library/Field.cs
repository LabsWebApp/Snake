using System;
using System.Threading;
using Library.Shapes;
using static System.Console;
using static Library.Helpers.StaticSettings;

namespace Library
{
    /// <summary>
    /// MEMENTO EXCEPTIO
    /// </summary>
    public class Field
    {
        private readonly (int, int) _size;
        private readonly HorizontalLine
            _upLine, _dawnLine;
        private readonly VerticalLine
            _leftLine, _rightLine;

        internal Snake Snake { get; set; }

        private Field(int width, int height)
        {
            _size.Item1 = width--;
            _size.Item2 = height--;

            _upLine = new(0, width, 0, TopFrameChar);
            _dawnLine = new(0, width, height, DownFrameChar);

            _leftLine = new(0, height, 0, LeftFrameChar);
            _rightLine = new(0, height, width, RightFrameChar);
        }

        public static Field SetField(
            Action<int, int> setWindow = null,
            int width = -1, int height = -1)
        {
            var result = DrawFrame(setWindow, width, height);
            
            var snake = StartingSnake();
            result.Snake = snake;
            result.Snake.Draw();
            snake.Draw();


            return result;
        }

        private static Field DrawFrame(
            Action<int, int> setWindow, int width, int height)
        {
            if (width < 0) width = DefaultFieldSize.Item1;
            else if (width < MinWidth) width = MinWidth;
            else if (width > LargestWindowWidth) width = LargestWindowWidth;

            if (height < 0) height = DefaultFieldSize.Item2;
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
