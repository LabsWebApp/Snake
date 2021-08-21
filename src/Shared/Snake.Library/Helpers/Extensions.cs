using System.Collections.Generic;
using System.Threading.Tasks;
using Library.Geom.Base;

namespace Library.Helpers
{
    public static class Extensions
    {
        public static bool PointIsHit(this IEnumerable<Point> list, int x, int y) => 
            !Parallel.ForEach(list, (p, loop) =>
            {
                if (p.IsHit(x, y)) loop.Break();
            }).IsCompleted;

        public static bool PointIsHit(this IEnumerable<Point> list, Point p) => PointIsHit(list, p.X, p.Y);

        //public static bool ShapeIsHit(this Shape left, Shape right) =>
        //    !Parallel.ForEach(right, (p, loop) =>
        //    {
        //        if (left.PointIsHit(p)) loop.Break();
        //    }).IsCompleted;

    }
}
