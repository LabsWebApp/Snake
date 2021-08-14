namespace Library.Shapes.Lines
{
    public class VerticalLine : Shape
    {
        public VerticalLine(int yUp, int yDown, int x, char sym)
        {
            for (int y = yUp; y <= yDown; y++) PList.Add(new Point(x, y, sym));
        }
    }
}
