using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Geom.Base;
using Library.Helpers;
using static Library.Helpers.Config;

namespace Library.Geom
{
    public class FoodProvider
    {
        private readonly int x1, x2, y1, y2;

        private readonly Random _r = new(DateTime.Now.Millisecond);
        public FoodProvider(SimplePoint position, Size fieldSize)
        {
            x1 = position.X + 1;
            y1 = position.Y + 1;

            x2 = fieldSize.EndOfWidth - 1;
            y2 = fieldSize.EndOfHeight - 1;
        }

        public Point Supply(IList<Point> busy, char symbol = FoodChar)
        {
            int x, y;
            do
            {
                x = _r.Next(x1, x2);
                y = _r.Next(y1, y2);
            } while (busy.PointIsHit(x, y));
            return new Point(x, y, symbol);
        }
    }
}
