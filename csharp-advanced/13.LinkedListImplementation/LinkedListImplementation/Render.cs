using System;

namespace LinkedListImplementation
{
    public static class Render
    {
        public static char[][] Buffer = InitialiseBuffer();
        public static Position FruitPos = new Position(0, 0);

        private static void AddSnakeToBuffer()
        {
            Node<SnakeElement> snakeNode = GameUtils.Snake.SnakeElements.Head;
            while (snakeNode != null)
            {
                Buffer[snakeNode.Value.Position.Row][snakeNode.Value.Position.Col] = snakeNode.Value.Character;
                snakeNode = snakeNode.Next;
            }
        }

        private static void AddBorderToBuffer()
        {
            // Top Line
            for (int i = 0; i < Buffer[0].Length; i++)
            {
                Buffer[0][i] = '*';
            }

            // Middle Lines
            for (int i = 0; i < Buffer.Length; i++)
            {
                Buffer[i][0] = '*';
                Buffer[i][^1] = '*';
                Buffer[i][GameUtils.FieldWidth + 1] = '*';
            }

            // Bottom Line
            for (int i = 0; i < Buffer[^1].Length; i++)
            {
                Buffer[^1][i] = '*';
            }
        }

        private static void AddInfoToBuffer()
        {
            int scoreTextRow = 2;
            int scoreTextCol = GameUtils.FieldWidth + 4;
            foreach (char c in "Score:") Buffer[scoreTextRow][scoreTextCol++] = c;

            int scoreNumberRow = 3;
            int scoreNumberCol = GameUtils.FieldWidth + 4;
            foreach (char c in GameUtils.Score.ToString()) Buffer[scoreNumberRow][scoreNumberCol++] = c;
        }

        private static void AddFruintToBuffer()
        {
            Buffer[FruitPos.Row][FruitPos.Col] = '^';
        }

        private static char[][] InitialiseBuffer()
        {
            char[][] buffer = new char[GameUtils.ConsoleHeight][];

            for (int i = 0; i < buffer.Length; i++)
            {
                buffer[i] = new char[GameUtils.ConsoleWidth];
            }

            return buffer;
        }

        public static void UpdateScreenBuffer()
        {
            AddBorderToBuffer();
            AddSnakeToBuffer();
            AddInfoToBuffer();
            AddFruintToBuffer();

            Console.Clear();
            for (int i = 0; i < Buffer.Length; i++) Console.WriteLine(Buffer[i]);

            ClearBuffer();
        }

        private static void ClearBuffer()
        {
            for (int i = 0; i < Buffer.Length; i++)
            {
                for (int j = 0; j < Buffer[i].Length; j++)
                {
                    Buffer[i][j] = ' ';
                }
            }
        }
    }
}
