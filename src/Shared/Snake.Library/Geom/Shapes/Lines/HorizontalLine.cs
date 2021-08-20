using Library.Geom.Base;

namespace Library.Geom.Shapes.Lines
{
    public class HorizontalLine : Line
    {
        public HorizontalLine(int xLeft, int xRight, int y, char sym)
        {
            for (int x = xLeft; x <= xRight; x++) PList.Add(new Point(x, y, sym));
        }
    }
}
