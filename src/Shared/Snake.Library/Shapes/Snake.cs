namespace Library.Shapes
{
    public class Snake : Shape
    {
        public Snake(
            Point tail, 
            int length, 
            Direction direction)
        {
            for (int i = 0; i < length; i++)
            {
                Point p = tail;
                p.Move(i, direction);
                PList.Add(p);
            }
        }
    }
}
