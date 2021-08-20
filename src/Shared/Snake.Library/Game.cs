using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Library.Geom;
using Library.Geom.Base;
using Library.Geom.Shapes;
using Library.Geom.Shapes.Lines;
using static System.Console;
using static Library.Helpers.Config;

namespace Library
{
    public class Game
    {
        private readonly Snake snake;
        private readonly Field field;
        private readonly FoodProvider provider;

        public Game(Action<int, int>? setWindow = null,
            Size? windowSize = null,
            Size? fieldSize = null,
            SimplePoint? point = null)
        {
            field = Field.SetField(setWindow, windowSize, fieldSize, point);
            snake = StartingSnake(field.Position);
            provider = new(field.Position, field.EndPoint);
        } 

        public void Play()
        {
            var food = provider.Supply(snake.ToList());
            food.Draw();

            ConsoleKeyInfo current = new();
            for (;;)
            {
                if (KeyAvailable)
                {
                    var key = ReadKey(true);
                    if (key == current)
                    {
                        Thread.Sleep(1);
                        continue;
                    }
                    snake.Turn(key.Key);
                    current = key;
                }

                if (snake.Eat(food))
                {
                    food = provider.Supply(snake.ToList());
                    food.Draw();
                }
                else snake.Move();

                Thread.Sleep(StartingSpeed);
            }
        }
    }
}