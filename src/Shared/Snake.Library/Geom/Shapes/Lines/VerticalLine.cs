using Library.Geom.Base;

namespace Library.Geom.Shapes.Lines
{
    public sealed class VerticalLine : Line
    {
        public VerticalLine(int yUp, int yDown, int x, char sym) 
        {
            for (int y = yUp; y <= yDown; y++) PList.Add(new Point(x, y, sym));
        }
    }
}
