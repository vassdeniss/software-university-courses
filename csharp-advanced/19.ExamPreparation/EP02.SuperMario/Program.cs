using System;
using System.Linq;

namespace EP02.SuperMario
{
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
        static void Main(string[] args)
        {
            int lives = int.Parse(Console.ReadLine());
            int size = int.Parse(Console.ReadLine());
            int[] marioPos = new int[2];
            char[][] field = RegisterMatrix(size, marioPos);

            Explore(field, marioPos[0], marioPos[1], lives);

            for (int i = 0; i < field.Length; i++)
            {
                for (int j = 0; j < field[i].Length; j++)
                {
                    Console.Write(field[i][j]);
                }

                Console.WriteLine();
            }
        }

        private static void Explore(char[][] field, int row, int col, int lives)
        {
            if (field[row][col] == 'B')
            {
                lives -= 2;
            }

            if (field[row][col] == 'P')
            {
                field[row][col] = '-';
                Console.WriteLine($"Mario has successfully saved the princess! Lives left: {lives}");
                return;
            }

            if (lives <= 0)
            {
                field[row][col] = 'X';
                Console.WriteLine($"Mario died at {row};{col}.");
                return;
            }

            string[] tokens = Console.ReadLine().Split();
            Direction direction = GetDirection(tokens[0]);
            int bowserRow = int.Parse(tokens[1]);
            int bowserCol = int.Parse(tokens[2]);

            lives--;
            field[bowserRow][bowserCol] = 'B';
            field[row][col] = '-';

            if (IsOutsideRange(field, direction, row, col))
            {
                direction = Direction.INVALID;
            }

            switch (direction)
            {
                case Direction.UP: Explore(field, row - 1, col, lives); break;
                case Direction.DOWN: Explore(field, row + 1, col, lives); break;
                case Direction.LEFT: Explore(field, row, col - 1, lives); break;
                case Direction.RIGHT: Explore(field, row, col + 1, lives); break;
                case Direction.INVALID: Explore(field, row, col, lives); break;
            }

            return;
        }

        private static Direction GetDirection(string direction)
        {
            return direction switch
            {
                "W" => Direction.UP,
                "S" => Direction.DOWN,
                "A" => Direction.LEFT,
                "D" => Direction.RIGHT,
                _ => Direction.INVALID
            };
        }

        private static bool IsOutsideRange(char[][] field, Direction direction, int row, int col)
        {
            return (direction == Direction.UP && row - 1 < 0) ||
                (direction == Direction.DOWN && row + 1 >= field.Length) ||
                (direction == Direction.LEFT && col - 1 < 0) ||
                (direction == Direction.RIGHT && col + 1 >= field[0].Length);
        }

        private static char[][] RegisterMatrix(int n, int[] arr)
        {
            char[][] matrix = new char[n][];

            for (int i = 0; i < n; i++)
            {
                char[] elements = Console.ReadLine().ToCharArray();
                matrix[i] = elements;
                if (elements.Contains('M'))
                {
                    arr[0] = i;
                    arr[1] = elements.ToList().IndexOf('M');
                }
            }

            return matrix;
        }
    }
}
