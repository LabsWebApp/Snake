using System;
using System.Linq;
using Library.Geom.Base;

namespace Library.Geom.Shapes
{
    public sealed class Snake : Shape
    {
        private Direction Direction;

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

        public bool Eat(Point food)
        {
            var head = GetNextPoint();
            if (head.IsHit(food))
            {
                food.Symbol = head.Symbol;
                food.Draw();
                PList.Add(food);
                return true;
            }
            return false;
        }

        public void Turn(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.LeftArrow:
                    Direction = Direction.Left;
                    break;
                case ConsoleKey.RightArrow:
                    Direction = Direction.Right;
                    break;
                case ConsoleKey.UpArrow:
                    Direction = Direction.Up;
                    break;
                case ConsoleKey.DownArrow:
                    Direction = Direction.Down;
                    break;
            }
        }
    }
}
