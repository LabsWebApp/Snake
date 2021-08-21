using System;
using System.Collections.Generic;
using Library.Geom.Base;
using Library.Helpers;
using static Library.Helpers.Config;

namespace Library.Geom
{
    public class FoodProvider
    {
        private readonly int x1, x2, y1, y2;

        private readonly Random _r = new(DateTime.Now.Millisecond);
        private char SetWeight => SetWeight(_r);

        public FoodProvider(SimplePoint position, Size fieldSize)
        {
            x1 = position.X + 1;
            y1 = position.Y + 1;

            x2 = fieldSize.EndOfWidth - 1;
            y2 = fieldSize.EndOfHeight - 1;
        }

        public Point Supply(IList<Point> busy)
        {
            int x, y;
            do
            {
                x = _r.Next(x1, x2);
                y = _r.Next(y1, y2);
            } while (busy.PointIsHit(x, y));
            return new Point(x, y, SetWeight);
        }

        public static int GetWeight(Point food) => food.Symbol switch
        {
            '2' => 2, '3' => 3, '4' => 4, '5' => 5, '6' => 6, '7' => 7, '8' => 8, '9' => 9,
            _ => 1
        };
    }
}
