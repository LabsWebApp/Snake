using System;
using System.Collections;
using System.Collections.Generic;
using Library.Geom.Base;

namespace Library.Geom.Shapes
{
    public abstract class Shape : IEnumerable<Point>
    {
        public virtual IList<Point> PList { get; }
        protected Shape() => PList = new List<Point>();
        public void Draw()
        {
            foreach (var point in PList) point.Draw();
        }

        public void Draw(ConsoleColor color) => SetResetColor.ForAction(color, Draw);

        public IEnumerator<Point> GetEnumerator() => PList.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => PList.GetEnumerator();
    }
}
