using System;
using System.Collections;
using System.Collections.Generic;
using Library.Geom.Base;

namespace Library.Geom.Shapes
{
    public abstract class Shape : IEnumerable<Point>
    {
        public virtual List<Point> PList { get; init; } = new ();

        public virtual void Draw(ConsoleColor? color = null)
        {
            void MainDraw()
            {
                foreach (var point in PList) point.Draw();
            };

            if (color is not null)
                SetResetColor.ForAction((ConsoleColor) color, MainDraw);
            else MainDraw();
        }

        public IEnumerator<Point> GetEnumerator() => PList.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => PList.GetEnumerator();
    }
}
