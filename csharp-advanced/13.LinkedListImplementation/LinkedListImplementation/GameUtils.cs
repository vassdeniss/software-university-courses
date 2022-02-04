using System;

namespace LinkedListImplementation
{
    public class GameUtils
    {
        private static Random RndFruit = new Random();

        public static Snake Snake = new Snake();
        public static int Frame = 0;
        public static int Score = 0;
        public static Position OldPos = new Position(0, 0);
        public static int ThreadSleep = 100;

        public static readonly int FieldHeight = 15;
        public static readonly int FieldWidth = 70;
        public static readonly int InfoWidth = 10;
        public static readonly int MoveFrame = 10;

        public static readonly int ConsoleHeight = 1 + FieldHeight + 1;
        public static readonly int ConsoleWidth = 1 + FieldWidth + 1 + InfoWidth + 1;

        public static bool[][] BorderField = InitialiseField();
        public static bool[][] FruitField = InitialiseFruitField();
        public static bool[][] SnakeField = InitialiseSnakeField();

        public static void SetupGame()
        {
            Snake.SnakeElements.AddHead(new Node<SnakeElement>(new SnakeElement()
            {
                Character = '*',
                Position = new Position(5, 11)
            }));
            Snake.SnakeElements.AddHead(new Node<SnakeElement>(new SnakeElement()
            {
                Character = '*',
                Position = new Position(5, 11)
            }));
            Snake.SnakeElements.AddHead(new Node<SnakeElement>(new SnakeElement()
            {
                Character = '*',
                Position = new Position(5, 11)
            }));

            Console.Title = "Snake With Custom Linked List";
            Console.CursorVisible = false;
            Console.SetWindowSize(ConsoleWidth, ConsoleHeight + 1);
            Console.SetBufferSize(ConsoleWidth, ConsoleHeight + 1);

            GenRndFruit();
        }

        public static Direction ChangeDirection(Direction direction)
        {
            if (Console.KeyAvailable)
            {
                ConsoleKey ch = Console.ReadKey().Key;
                switch (ch)
                {
                    case ConsoleKey.LeftArrow:
                        if (direction != Direction.Right) return Direction.Left;
                        break;
                    case ConsoleKey.RightArrow:
                        if (direction != Direction.Left) return Direction.Right;
                        break;
                    case ConsoleKey.UpArrow:
                        if (direction != Direction.Down) return Direction.Up;
                        break;
                    case ConsoleKey.DownArrow:
                        if (direction != Direction.Up) return Direction.Down;
                        break;
                }
            }

            return direction;
        }

        public static bool BorderCollision()
        {
            if (BorderField[Snake.SnakeElements.Head.Value.Position.Row]
                [Snake.SnakeElements.Head.Value.Position.Col]) return true;

            return false;
        }

        public static bool FruitCollision()
        {
            if (FruitField[Snake.SnakeElements.Head.Value.Position.Row]
                [Snake.SnakeElements.Head.Value.Position.Col]) return true;

            return false;
        }

        public static bool SnakeCollision()
        {
            if (SnakeField[Snake.SnakeElements.Head.Value.Position.Row]
                [Snake.SnakeElements.Head.Value.Position.Col]) return true;

            return false;
        }

        private static void GenRndFruit()
        {
            int rndRow = RndFruit.Next(0, BorderField.Length);
            int rndCol = RndFruit.Next(0, BorderField[0].Length);
            Render.FruitPos = new Position(rndRow, rndCol);
            OldPos = new Position(rndRow, rndCol);
            FruitField[rndRow][rndCol] = true;
        }

        public static void UpdateFruit()
        {
            int row = Snake.SnakeElements.Head.Value.Position.Row;
            int col = Snake.SnakeElements.Head.Value.Position.Col;
            Snake.SnakeElements.AddHead(new Node<SnakeElement>(new SnakeElement()
            {
                Character = '*',
                Position = new Position(row, col)
            }));
            
            FruitField[OldPos.Row][OldPos.Col] = false;

            Score += 10;

            if (ThreadSleep > 10) ThreadSleep -= 10;

            GenRndFruit();
        }

        public static bool[][] InitialiseSnakeField()
        {
            bool[][] field = new bool[FieldHeight][];
            for (int i = 0; i < field.Length; i++) field[i] = new bool[FieldWidth];

            bool first = true;
            Node<SnakeElement> snakeNode = Snake.SnakeElements.Head;
            while (snakeNode != null)
            {
                if (!first) field[snakeNode.Value.Position.Row][snakeNode.Value.Position.Col] = true;

                snakeNode = snakeNode.Next;

                first = false;
            }

            return field;
        }

        private static bool[][] InitialiseFruitField()
        {
            bool[][] field = new bool[FieldHeight][];

            for (int i = 0; i < field.Length; i++) field[i] = new bool[FieldWidth];

            return field;
        }

        private static bool[][] InitialiseField()
        {
            bool[][] field = new bool[FieldHeight + 2][];

            for (int i = 0; i < field.Length; i++) field[i] = new bool[FieldWidth + 2];

            for (int i = 0; i < field[0].Length; i++) field[0][i] = true;
            for (int i = 0; i < field.Length; i++)
            {
                field[i][0] = true;
                field[i][^1] = true;
            }
            for (int i = 0; i < field[^1].Length; i++) field[^1][i] = true;

            return field;
        }
    }
}
