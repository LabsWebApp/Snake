using System;
using Library.Geom.Base;
using Library.Geom.Shapes;

namespace Library.Helpers
{
    public static class Config
    {
        public const char
            SnakeChar = '*',
            FoodChar = '$',
            //FoodChar = '₽',
            DeathChar = 'X',
            VerticalBarrierChar = '[', 
            HorizontalBarrierChar = VerticalBarrierChar, 
            TopFrameChar = '+', 
            //TopFrameChar = '\u0305',
            DownFrameChar = TopFrameChar, 
            //DownFrameChar = '_',
            LeftFrameChar = '|',
            //LeftFrameChar = '+',
            RightFrameChar = LeftFrameChar;

        public const ConsoleColor
            BorderColor = ConsoleColor.Blue,
            BarrierColor = ConsoleColor.DarkBlue,
            FoodColor = ConsoleColor.DarkGreen,
            DeathColor = ConsoleColor.Red;

        public static readonly SimplePoint DefaultPosition = new(1, 1);
        public static readonly Size DefaultFieldSize = new(80, 20);
        public static readonly Size MinFieldSize = new(22, 12);

        public const int StartingSpeed = 200;

        public static Snake StartingSnake(SimplePoint position) =>
            new (new Point(position.X + 4, position.Y + 3, SnakeChar), 
                4, Direction.Right);

        public static char SetWeight(Random r) => r.NextDouble() switch
        {
            >= 0.4 and < 0.7 => '2',
            >= 0.7 and < 0.9 => '3',
            >= 0.9 => '4',
            _ => FoodChar
        };
    }
}
