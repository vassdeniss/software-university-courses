using System;

namespace EP08.Bee
{
    class Point
    {
        public int Row { get; set; }
        public int Col { get; set; }
        public int PollinatedFlowers { get; set; } = 0;
        public bool IsLost { get; set; } = false;

        public void ApplyDirection(string direction)
        {
            Direction check = GetDirection(direction);
            switch (check)
            {
                case Direction.UP: Row--; break;
                case Direction.DOWN: Row++; break;
                case Direction.LEFT: Col--; break;
                case Direction.RIGHT: Col++; break;
            }
        }

        private Direction GetDirection(string direction)
        {
            return direction switch
            {
                "up" => Direction.UP,
                "down" => Direction.DOWN,
                "left" => Direction.LEFT,
                "right" => Direction.RIGHT,
                _ => Direction.INVALID
            };
        }

        public bool IsOutOfBounds(char[,] field, int row, int col)
        {
            return row < 0 || row >= field.GetLength(0) || col < 0 || col >= field.GetLength(1);
        }
    }

    enum Direction
    {
        UP,
        DOWN,
        LEFT,
        RIGHT,
        INVALID
    }

    internal class Program
    {
        private const char DEFAULT_MAZE_SYMBOL = '.';
        private const char BEE_MAZE_SYMBOL = 'B';
        private const int NEEDED_FLOWERS = 5;

        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            Point bee = new Point();
            char[,] matrix = RegisterMatrix(size, bee);

            string command = Console.ReadLine();
            while (command != "End")
            {
                matrix[bee.Row, bee.Col] = DEFAULT_MAZE_SYMBOL;
                bee.ApplyDirection(command);

                int row = bee.Row;
                int col = bee.Col;

                if (bee.IsOutOfBounds(matrix, row, col))
                {
                    bee.IsLost = true;
                    break;
                }

                if (matrix[row, col] == 'f')
                {
                    matrix[row, col] = DEFAULT_MAZE_SYMBOL;
                    bee.PollinatedFlowers++;
                }

                if (matrix[row, col] == 'O')
                {
                    matrix[row, col] = DEFAULT_MAZE_SYMBOL;
                    continue;
                }

                matrix[row, col] = BEE_MAZE_SYMBOL;
                command = Console.ReadLine();
            }

            if (bee.IsLost)
                Console.WriteLine("The bee got lost!");

            Console.WriteLine(bee.PollinatedFlowers < 5
                ? $"The bee couldn't pollinate the flowers, she needed {NEEDED_FLOWERS - bee.PollinatedFlowers} flowers more"
                : $"Great job, the bee managed to pollinate {bee.PollinatedFlowers} flowers!");

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j]);
                }

                Console.WriteLine();
            }
        }

        private static char[,] RegisterMatrix(int size, Point point)
        {
            char[,] matrix = new char[size, size];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                string elements = Console.ReadLine();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = elements[j];

                    if (matrix[i, j] == 'B')
                    {
                        point.Row = i;
                        point.Col = j;
                    }
                }
            }

            return matrix;
        }
    }
}
