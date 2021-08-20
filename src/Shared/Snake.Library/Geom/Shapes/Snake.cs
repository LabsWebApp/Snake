using System.Linq;
using Library.Geom.Base;

namespace Library.Geom.Shapes
{
    public class Snake : Shape
    {
        public Direction Direction { set; private get; }

        public Snake(
            Point tail, 
            int length, 
            Direction direction)
        {
            Direction = direction;
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
            next.Move(1, Direction);
            return next;
        }
    }
}
