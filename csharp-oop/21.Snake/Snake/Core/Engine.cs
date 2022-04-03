using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;

using Snake.Enums;
using Snake.GameObjects;

namespace Snake.Core
{
    public class Engine : IEngine
    {
        private const string ScoreFileName = "YourHighScores.txt";

        private readonly Wall wall;
        private readonly GameObjects.Snake snake;
        private readonly Point[] directions;

        private Direction direction;
        private double sleepTime;

        public Engine(Wall wall, GameObjects.Snake snake)
        {
            this.wall = wall;
            this.snake = snake;

            sleepTime = 100;
            directions = new Point[4];
        }

        public void Run()
        {
            directions[0] = new Point(1, 0);
            directions[1] = new Point(-1, 0);
            directions[2] = new Point(0, 1);
            directions[3] = new Point(0, -1);

            wall.InitializeWall();

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    GetNext();
                }

                bool canMove = snake.CanMove(directions[(int)direction]);
                if (!canMove) AskForRestart();

                sleepTime -= 0.01;
                Thread.Sleep((int)sleepTime);
            }
        }

        private void AskForRestart()
        {
            Console.SetCursorPosition(wall.LeftX + 3, 4);
            Console.Write("Game Over!");

            Console.SetCursorPosition(wall.LeftX + 3, 5);
            Console.Write($"Score: {snake.Score}");

            Console.SetCursorPosition(wall.LeftX + 3, 6);
            Console.Write("Would you like to continue? (y/n)");

            File.AppendAllLines(ScoreFileName, new List<string>
            {
                $"[{DateTime.Now}] {Environment.UserName} => {snake.Score}"
            });

            string input = Console.ReadLine();
            if (input == "y")
            {
                Console.Clear();
                StartUp.Main();
            }
            else
            {
                Environment.Exit(0);
            }
        }

        private void GetNext()
        {
            ConsoleKeyInfo key = Console.ReadKey();

            if (key.Key == ConsoleKey.LeftArrow && direction != Direction.Right)
            {
                direction = Direction.Left;
            }
            else if (key.Key == ConsoleKey.RightArrow && direction != Direction.Left)
            {
                direction = Direction.Right;
            }
            else if (key.Key == ConsoleKey.UpArrow && direction != Direction.Down)
            {
                direction = Direction.Up;
            }
            else if (key.Key == ConsoleKey.DownArrow && direction != Direction.Up)
            {
                direction = Direction.Down;
            }

            Console.CursorVisible = false;
        }
    }
}
