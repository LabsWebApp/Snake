using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Library.Geom;
using Library.Geom.Base;
using Library.Geom.Shapes;
using Library.Geom.Shapes.Lines;
using Library.Helpers;
using static System.Console;
using static Library.Helpers.Config;
// ReSharper disable InconsistentNaming

namespace Library
{
    public class Game : IDisposable
    {
        private readonly Snake snake;
        private readonly Field field;
        private readonly FoodProvider provider;
        private readonly IList<Shape> barriers;

        private IList<Point> Busy => 
            barriers.Except(barriers.Take(4)).SelectMany(p => p).Concat(snake).ToList();

        public Game(Action<int, int>? setWindow = null,
            Size? windowSize = null,
            Size? fieldSize = null,
            SimplePoint? point = null)
        {
            Clear();
            CursorVisible = false;

            field = Field.SetField(setWindow, windowSize, fieldSize, point);
            snake = StartingSnake(field.Position);
            provider = new(field.Position, field.EndPoint);
            barriers = new List<Shape>();
            field.Border.ForEach(shape => barriers.Add(shape));
            
            AddBarriers();
        }

        //Создать свой  🠗🠗🠗🠗🠗🠗🠗🠗🠗🠗
        private void AddBarriers()
        {
            int x = (field.EndPoint.EndOfWidth - field.Position.X) / 2,
                tail = (field.EndPoint.EndOfHeight - field.Position.Y) / 2,
                y = field.Position.Y + tail / 2;
            Shape barrier = new VerticalLine(y, y + tail, x, VerticalBarrierChar);
            barriers.Add(barrier);
            barrier.Draw(BarrierColor);
        }

        public void Play()
        {
            var b = Busy;
            var food = provider.Supply(b);
            food.Draw(FoodColor);

            ConsoleKeyInfo current = new();
            for (;;)
            {
                if (KeyAvailable)
                {
                    var key = ReadKey(true);
                    if (key == current) continue;
                    if (key.Key == ConsoleKey.Escape) break;
                    if (key.Key is ConsoleKey.P or ConsoleKey.Pause)
                    {
                        if (WaitOrExit()) break;
                    }

                    snake.Turn(key.Key);
                    current = key;
                }

                if (PointIsHitBarrier(snake.Head) || snake.IsHitTail()) break;

                if (snake.Eat(food))
                {
                    food = provider.Supply(Busy);
                    food.Draw(FoodColor);
                }
                else snake.Move();
                Thread.Sleep(StartingSpeed);
            }
            snake.Death();
        }

        private static bool WaitOrExit()
        {
            for (;;)
            {
                if (KeyAvailable)
                {
                    var key = ReadKey(true);
                    if (key.Key == ConsoleKey.Escape) return true;
                    if (key.Key is ConsoleKey.P or ConsoleKey.Pause)
                        return false;
                }
                Thread.Sleep(1);
            }
        }

        private bool PointIsHitBarrier(Point p)=>
            !Parallel.ForEach(barriers, (shape, loop) =>
            {
                if (shape.PointIsHit(p)) loop.Break();
            }).IsCompleted;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                CursorVisible = true;
            }
        }
    }
}