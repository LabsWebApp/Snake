using System;
using static System.Console;
using System.Collections.Generic;
using static Library.Helpers.Config;
using Library.Geom.Base;
using Library.Geom.Shapes;
using Library.Geom.Shapes.Lines;

namespace Library.Geom
{
    /// <summary>
    /// MEMENTO EXCEPTIO
    /// </summary>
    public class Field
    {
        public SimplePoint Position { get; }
        public Size EndPoint { get; }

        public List<Shape> Border { get; } 

        private Field(SimplePoint position, Size size)
        {
            var p = position;

            Border = new List<Shape>
            {
                new HorizontalLine(p.X, size.EndOfWidth, p.Y, TopFrameChar),
                new HorizontalLine(p.X, size.EndOfWidth, size.EndOfHeight, DownFrameChar),
                new VerticalLine(p.Y + 1, size.EndOfHeight - 1, p.X, LeftFrameChar),
                new VerticalLine(p.Y + 1, size.EndOfHeight - 1, size.EndOfWidth, RightFrameChar)
            };

            Border.ForEach(line => line.Draw(BorderColor));
            Position = p;
            EndPoint = size;
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
                size.EndOfWidth = winSize.EndOfWidth - 1;
            }
            else if (size.EndOfWidth + p.X >= winSize.EndOfWidth) p.X = winSize.EndOfWidth - size.EndOfWidth - 1;

            if (size.EndOfHeight >= winSize.EndOfHeight)
            {
                p.Y = 0;
                size.EndOfHeight = winSize.EndOfHeight - 1;
            }
            else if (size.EndOfHeight + p.Y >= winSize.EndOfHeight) p.Y = winSize.EndOfHeight - size.EndOfHeight - 1;

            setWindow?.Invoke(winSize.EndOfWidth, winSize.EndOfHeight);

            return new Field(p, size);
        }
    }
}
