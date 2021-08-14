namespace Library.Shapes.Lines
{
    public class HorizontalLine : Shape
    {
        public HorizontalLine(int xLeft, int xRight, int y, char sym)
        {
            for (int x = xLeft; x <= xRight; x++) PList.Add(new Point(x, y, sym));
        }
    }
}
