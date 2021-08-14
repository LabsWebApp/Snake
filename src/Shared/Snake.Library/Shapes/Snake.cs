using System.Linq;

namespace Library.Shapes
{
    public class Snake : Shape
    {
        private Direction _direction;
        public Snake(
            Point tail, 
            int length, 
            Direction direction)
        {
            _direction = direction;
            for (int i = 0; i < length; i++)
            {
                Point p = tail;
                p.Move(i, direction);
                PList.Add(p);
            }
        }

        public void Move()
        {
            PList.First().Clear();
            PList.RemoveAt(0);
            Point head = GetNextPoint();
            PList.Add(head);

            head.Draw();
        }
        private Point GetNextPoint()
        {
            Point head = PList.Last();
            Point next = head;
            next.Move(1, _direction);
            return next;
        }
    }
}
