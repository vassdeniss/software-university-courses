using System;
using System.Collections.Generic;
using System.Linq;

namespace Snake.GameObjects
{
    public class Snake
    {
        private const int SNAKE_SIZE = 6;
        private const char SNAKE_SYMBOL = '\u25CF';

        private readonly Wall wall;
        private readonly Food[] food;
        
        private Queue<Point> snakeElements;
        private int foodIdx;
        private int nextLeftX;
        private int nextTopY;
        private int score;

        public Snake(Wall wall)
        {
            this.wall = wall;

            food = new Food[]
            {
                new FoodAsterisk(wall),
                new FoodDollar(wall),
                new FoodHash(wall)
            };

            foodIdx = RandomFood;

            CreateSnake();
        }

        private int RandomFood => new Random().Next(0, food.Length);

        public int Score => score;

        public bool CanMove(Point direction)
        {
            Point head = snakeElements.Last();

            nextLeftX = head.LeftX + direction.LeftX;
            nextTopY = head.TopY + direction.TopY;

            bool isOnSnake = snakeElements.Any(x => x.LeftX == nextLeftX && x.TopY == nextTopY);
            if (isOnSnake) return false;

            bool isOnWall = nextLeftX < 0 || nextTopY < 0 || nextLeftX >= wall.LeftX || nextTopY >= wall.TopY;
            if (isOnWall) return false;

            Point newHead = new Point(nextLeftX, nextTopY);
            snakeElements.Enqueue(newHead);
            newHead.Draw(SNAKE_SYMBOL);

            bool isOnFood = food[foodIdx].LeftX == nextLeftX && food[foodIdx].TopY == nextTopY;
            if (isOnFood) Eat(direction, newHead);

            Point tail = snakeElements.Dequeue();
            tail.Draw(' ');

            return true;
        }

        private void CreateSnake()
        {
            snakeElements = new Queue<Point>();

            for (int i = 0; i <= SNAKE_SIZE; i++)
            {
                Point point = new Point(2, i + 1);
                snakeElements.Enqueue(point);
                point.Draw(SNAKE_SYMBOL);
            }

            food[foodIdx].DrawOnRandomPos(snakeElements);
        }

        private void Eat(Point direction, Point head)
        {
            Food food = this.food[foodIdx];
            for (int i = 0; i < food.Points; i++)
            {
                snakeElements.Enqueue(new Point(nextLeftX, nextTopY));
                nextLeftX = head.LeftX + direction.LeftX;
                nextTopY = head.TopY + direction.TopY;
            }

            score += food.Points;
            foodIdx = RandomFood;
            this.food[foodIdx].DrawOnRandomPos(snakeElements);
        }
    }
}
