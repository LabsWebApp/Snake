using System;
using System.Linq;
using System.Threading;
using Library.Geom.Base;
using static Library.Helpers.Config;

namespace Library.Geom.Shapes
{
    public sealed class Snake : Shape
    {
        private Direction _direction;
        private int _foodWeight = 0;
        public Point Head => PList.Last();

        public Snake(
            Point tail, 
            int length, 
            Direction direction)
        {
            _direction = direction;
            for (int i = 0; i < length; i++)
            {
                Point p = tail;
                PList.Add(p);
                p.Move(i, direction);
            }
        }

        public void Move()
        {
            if (_foodWeight == 0)
            {
                PList.First().Clear();
                PList.RemoveAt(0);
            }
            else _foodWeight--;

            Point head = GetNextPoint();
            PList.Add(head);

            head.Draw();
        }
        private Point GetNextPoint()
        {
            Point next = Head;
            next.Move(1, _direction);
            return next;
        }

        public bool Eat(Point food)
        {
            var head = GetNextPoint();
            if (head.IsHit(food))
            {
                _foodWeight += FoodProvider.GetWeight(food);
                Move();
                return true;
            }
            return false;
        }

        public void Turn(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.LeftArrow:
                    _direction = Direction.Left;
                    break;
                case ConsoleKey.RightArrow:
                    _direction = Direction.Right;
                    break;
                case ConsoleKey.UpArrow:
                    _direction = Direction.Up;
                    break;
                case ConsoleKey.DownArrow:
                    _direction = Direction.Down;
                    break;
            }
        }

        public bool IsHitTail()
        {
            var head = GetNextPoint();
            for (int i = PList.Count - 1; i > -1; i--)
            {
                if (head.IsHit(PList[i]))
                    return true;
            }
            return false;
        }

        public void Death()
        {
            var head = Head;
            head.Symbol = DeathChar;
            SetResetColor.ForAction(DeathColor, head.Draw);
            Thread.Sleep(1000);
        }
    }
}
