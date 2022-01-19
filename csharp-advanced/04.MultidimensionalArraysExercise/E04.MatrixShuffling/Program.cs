using System;
using System.Linq;

namespace E04.MatrixShuffling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dimension = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string[,] matrix = RegisterMatrix(dimension[0], dimension[1]);

            string input = Console.ReadLine();
            while (input != "END")
            {
                string[] cmd = input.Split();

                if (cmd[0] != "swap" || cmd.Length != 5)
                {
                    Console.WriteLine("Invalid input!");
                    input = Console.ReadLine();
                    continue;
                }

                int row = int.Parse(cmd[1]);
                int col = int.Parse(cmd[2]);
                int row1 = int.Parse(cmd[3]);
                int col1 = int.Parse(cmd[4]);

                if (IsValidCoordinates(matrix, cmd, row, col, row1, col1))
                {
                    Console.WriteLine("Invalid input!");
                    input = Console.ReadLine();
                    continue;
                }

                Swap(matrix, row, col, row1, col1);
                PrintMatrix(matrix);

                input = Console.ReadLine();
            }
        }

        private static void PrintMatrix(string[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j]} ");
                }

                Console.WriteLine();
            }
        }

        private static void Swap(string[,] matrix, int row, int col, int row1, int col1) =>
            (matrix[row, col], matrix[row1, col1]) = (matrix[row1, col1], matrix[row, col]);

        private static bool IsValidCoordinates(string[,] matrix, string[] cmd, int row, int col, int row1, int col1)
        {
            return
                row < 0 ||
                col < 0 ||
                row1 < 0 ||
                col1 < 0 ||
                row >= matrix.GetLength(0) ||
                col >= matrix.GetLength(1) ||
                row1 >= matrix.GetLength(0) ||
                col1 >= matrix.GetLength(1);
        }

        private static string[,] RegisterMatrix(int r, int c)
        {
            string[,] matrix = new string[r, c];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                string[] elements = Console.ReadLine().Split();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = elements[j];
                }
            }

            return matrix;
        }
    }
}
