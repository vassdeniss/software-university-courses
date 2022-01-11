using System;
using System.Collections.Generic;
using System.Linq;

namespace L02.MoveDownRight
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());

            int[,] matrix = FillMatrix(rows, cols);
            int[,] dynamicMatrix = FillDPMatrix(matrix, rows, cols);
            Stack<string> path = GeneratePath(dynamicMatrix, rows, cols);

            Console.WriteLine(string.Join(" ", path));
        }

        private static Stack<string> GeneratePath(int[,] arr, int rows, int cols)
        {
            Stack<string> stack = new Stack<string>();

            int row = rows - 1;
            int col = cols - 1;
            while (row > 0 && col > 0)
            {
                stack.Push($"[{row}, {col}]");

                int up = arr[row - 1, col];
                int left = arr[row, col - 1];

                if (up > left) row--;
                else col--;
            }

            while (row > 0) stack.Push($"[{row--}, {col}]");
            while (col > 0) stack.Push($"[{row}, {col--}]");

            stack.Push($"[{row}, {col}]");
            return stack;
        }

        private static int[,] FillDPMatrix(int[,] arr, int rows, int cols)
        {
            int[,] dp = new int[rows, cols];
            dp[0, 0] = arr[0, 0];

            for (int i = 1; i < cols; i++)
                dp[0, i] = dp[0, i - 1] + arr[0, i];

            for (int i = 1; i < rows; i++)
                dp[i, 0] = dp[i - 1, 0] + arr[i, 0];

            for (int i = 1; i < rows; i++)
            {
                for (int j = 1; j < cols; j++)
                {
                    dp[i, j] = arr[i, j] + Math.Max(dp[i - 1, j], dp[i, j - 1]);
                }
            }

            return dp;
        }

        private static int[,] FillMatrix(int rows, int cols)
        {
            int[,] matrix = new int[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                int[] elements = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                for (int j = 0; j < elements.Length; j++)
                {
                    matrix[i, j] = elements[j];
                }
            }

            return matrix;
        }
    }
}
