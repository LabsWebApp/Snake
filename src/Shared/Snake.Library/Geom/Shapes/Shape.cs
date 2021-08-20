using System.Collections;
using System.Collections.Generic;
using Library.Geom.Base;

namespace Library.Geom.Shapes
{
    public abstract class Shape : IEnumerable<Point>
    {
        protected IList<Point> PList { get; set; }
        protected Shape() => PList = new List<Point>();
        public void Draw()
        {
            foreach (var point in PList) point.Draw();
        }

        public IEnumerator<Point> GetEnumerator() => PList.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => PList.GetEnumerator();
    }
}
