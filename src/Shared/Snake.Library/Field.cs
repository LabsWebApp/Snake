using System;
using System.Collections.Generic;
using System.Threading;
using Library.Geom;
using Library.Geom.Base;
using Library.Geom.Shapes;
using Library.Geom.Shapes.Lines;
using static System.Console;
using static Library.Helpers.Config;

namespace Library
{
    /// <summary>
    /// MEMENTO EXCEPTIO
    /// </summary>
    public partial class Field : IDisposable
    {
        private readonly Snake Snake;

        private readonly List<Line> Border;

        private Field(Size size, SimplePoint position)
        {
            var p = position;
            Border = new List<Line>
            {
                new HorizontalLine(p.X, size.EndOfWidth, p.Y, TopFrameChar),
                new HorizontalLine(p.X, size.EndOfWidth, size.EndOfHeight, DownFrameChar),
                new VerticalLine(p.Y + 1, size.EndOfHeight - 1, p.X, LeftFrameChar),
                new VerticalLine(p.Y + 1, size.EndOfHeight - 1, size.EndOfWidth, RightFrameChar)
            };
            Border.ForEach(line => line.Draw());

            Snake = StartingSnake(p);
        } 

        public static Field SetField(
            Action<int, int>? setWindow = null,
            Size? windowSize = null,
            Size? fieldSize = null,
            SimplePoint? point = null)
        {
            SimplePoint p = point ?? DefaultPosition;
            Size size = fieldSize ?? DefaultFieldSize,
                winSize = windowSize ?? new(size.EndOfWidth + 2 * p.X + 1, size.EndOfHeight + 2 * p.Y + 1);
            size.EndOfWidth += p.X;
            size.EndOfHeight += p.Y;

            if (winSize.EndOfWidth > LargestWindowWidth) winSize.EndOfWidth = LargestWindowWidth;
            else if (winSize.EndOfWidth < MinFieldSize.EndOfWidth) winSize.EndOfWidth = MinFieldSize.EndOfWidth + 1;

            if (winSize.EndOfHeight > LargestWindowHeight) winSize.EndOfHeight = LargestWindowHeight;
            else if (winSize.EndOfHeight < MinFieldSize.EndOfHeight) winSize.EndOfHeight = MinFieldSize.EndOfHeight + 1;

            if (size.EndOfWidth < MinFieldSize.EndOfWidth)
            {
                p.X = 0;
                size.EndOfWidth = MinFieldSize.EndOfWidth;
            }
            else if (size.EndOfWidth + p.X < MinFieldSize.EndOfWidth) p.X = winSize.EndOfWidth - size.EndOfWidth;

            if (size.EndOfHeight < MinFieldSize.EndOfHeight)
            {
                p.Y = 0;
                size.EndOfHeight = MinFieldSize.EndOfHeight;
            }
            else if (size.EndOfHeight + p.Y < MinFieldSize.EndOfHeight) p.Y = winSize.EndOfHeight - size.EndOfHeight;

            if (size.EndOfWidth >= winSize.EndOfWidth)
            {
                p.X = 0;
                size.EndOfWidth = winSize.EndOfWidth -1;
            }
            else if(size.EndOfWidth + p.X>= winSize.EndOfWidth) p.X = winSize.EndOfWidth - size.EndOfWidth-1;

            if (size.EndOfHeight >= winSize.EndOfHeight)
            {
                p.Y = 0;
                size.EndOfHeight = winSize.EndOfHeight-1;
            }
            else if (size.EndOfHeight + p.Y >= winSize.EndOfHeight) p.Y = winSize.EndOfHeight - size.EndOfHeight-1;

            Clear();
            CursorVisible = false;
            setWindow?.Invoke(winSize.EndOfWidth, winSize.EndOfHeight);

            var result = new Field(size, p);
            Run(result.Snake);
            return result;
        }

        private static void Run(Snake snake)
        {
            ConsoleKeyInfo current = new();
            for (;;)
            {
                if (KeyAvailable)
                {
                    var key = ReadKey(true);
                    if (key == current)
                    {
                        Thread.Sleep(1);
                        continue;
                    }

                    current = key;
                    switch (key.Key)
                    {
                        case ConsoleKey.Escape:
                            return;
                        case ConsoleKey.LeftArrow:
                            snake.Direction = Direction.Left;
                            break;
                        case ConsoleKey.RightArrow:
                            snake.Direction = Direction.Right;
                            break;
                        case ConsoleKey.UpArrow:
                            snake.Direction = Direction.Up;
                            break;
                        case ConsoleKey.DownArrow:
                            snake.Direction = Direction.Down;
                            break;
                    }
                }
                Thread.Sleep(StartingSpeed);
                snake.Move();
            }
        }
    }
}