using System;
using System.Collections.Generic;
using System.Linq;

namespace Snake.GameObjects
{
    public abstract class Food : Point
    {
        private readonly Wall wall;
        private readonly char symbol;
        private readonly Random random;

        public Food(Wall wall, char symbol, int points)
            : base(0, 0)
        {
            this.wall = wall;
            this.symbol = symbol;
            Points = points;

            random = new Random();
        }

        protected virtual ConsoleColor Color => ConsoleColor.Red;

        public int Points { get; private set; }

        public void DrawOnRandomPos(Queue<Point> snakePoints)
        {
            bool isPartOfSnake = false;
            do
            {
                LeftX = random.Next(1, wall.LeftX - 1);
                TopY = random.Next(1, wall.TopY - 1);

                isPartOfSnake = snakePoints.Any(x => x.LeftX == LeftX && x.TopY == TopY);
            } while (isPartOfSnake);

            Console.BackgroundColor = Color;
            Draw(symbol);
            Console.BackgroundColor = ConsoleColor.White;
        }
    }
}
