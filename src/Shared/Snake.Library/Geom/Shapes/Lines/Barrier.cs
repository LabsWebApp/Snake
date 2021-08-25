using System.Collections.Generic;
using Library.Geom.Base;
using static Library.Helpers.Config;

namespace Library.Geom.Shapes.Lines
{
    public sealed class Barrier : Line
    {
        public Barrier(int first, int last, int secondCoordinate, bool isHorizontalLine = true)
        {
            Line line = isHorizontalLine
                ? new HorizontalLine(first, last, secondCoordinate, HorizontalBarrierChar)
                : new VerticalLine(first, last, secondCoordinate, VerticalBarrierChar);
            PList = line.PList;
        }

        public Barrier(int x, int y) =>
            PList = new List<Point> { new (x, y, PointBarrierChar) };

        public void Draw() => Draw(BarrierColor);
    }
}
