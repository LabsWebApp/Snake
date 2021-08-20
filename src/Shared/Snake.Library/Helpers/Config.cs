using System;
using System.Collections.Generic;
using Library.Geom;
using Library.Geom.Base;
using Library.Geom.Shapes;

namespace Library.Helpers
{
    public static class Config
    {
        public const char
            SnakeChar = '*',
            FoodChar = '₽',
            TopFrameChar = '+', 
            //TopFrameChar = '\u0305',
            DownFrameChar = TopFrameChar, 
            //DownFrameChar = '_',
            LeftFrameChar = '|',
            //LeftFrameChar = '+',
            RightFrameChar = LeftFrameChar;

        public static readonly SimplePoint DefaultPosition = new(1, 1);
        public static readonly Size DefaultFieldSize = new(80, 20);
        public static readonly Size MinFieldSize = new(22, 12);

        public const int StartingSpeed = 200;

        public static Snake StartingSnake(SimplePoint p) =>
            new (new Point(p.X + 4, p.Y + 3, SnakeChar), 4, Direction.Right);

    }
}
