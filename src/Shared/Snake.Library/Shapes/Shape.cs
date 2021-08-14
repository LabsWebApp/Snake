using System.Collections.Generic;

namespace Library.Shapes
{
    public abstract class Shape
    {
        protected List<Point> PList;
        protected Shape() => PList = new List<Point>();
        public void Draw() => PList.ForEach(p => p.Draw());
    }
}
