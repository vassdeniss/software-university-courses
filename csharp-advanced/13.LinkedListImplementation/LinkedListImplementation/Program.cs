using System;
using System.Threading;

namespace LinkedListImplementation
{
    public class Program
    {
        private static Direction Direction = Direction.Right;

        static void Main()
        {
            GameUtils.SetupGame();
            while (true)
            {
                GameUtils.Frame++;
                Direction = GameUtils.ChangeDirection(Direction);

                if (GameUtils.Frame % GameUtils.MoveFrame == 0)
                {
                    GameUtils.Snake.MoveSnake(Direction);
                    if (GameUtils.BorderCollision() || GameUtils.SnakeCollision()) break;
                    if (GameUtils.FruitCollision()) GameUtils.UpdateFruit();
                    Render.UpdateScreenBuffer();
                    GameUtils.Frame = 0;
                }

                Thread.Sleep(GameUtils.ThreadSleep);
            }

            Console.SetCursorPosition(28, 5);
            Console.Write("Game Over!");
        }
    }
}
