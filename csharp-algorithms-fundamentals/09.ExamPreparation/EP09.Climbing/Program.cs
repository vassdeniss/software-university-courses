using System;
using System.Collections.Generic;
using System.Linq;

namespace EP09.Climbing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());

            int[,] matrix = FillMatrix(rows, cols);
            int[,] dynamicMatrix = FillDPMatrix(matrix, rows, cols);
            Stack<int> path = GeneratePath(dynamicMatrix, matrix, rows, cols);

            Console.WriteLine(dynamicMatrix[0, 0]);
            Console.WriteLine(string.Join(" ", path));
        }

        private static Stack<int> GeneratePath(int[,] arr, int[,] matrix, int rows, int cols)
        {
            Stack<int> stack = new Stack<int>();

            int row = 0;
            int col = 0;
            while (row < arr.GetLength(0) - 1 && col < arr.GetLength(1) - 1)
            {
                stack.Push(matrix[row, col]);

                int down = arr[row + 1, col];
                int right = arr[row, col + 1];

                if (down > right) row++;
                else col++;
            }

            while (row < arr.GetLength(0) - 1) stack.Push(matrix[row++, col]);
            while (col < arr.GetLength(1) - 1) stack.Push(matrix[row, col++]);

            stack.Push(matrix[row, col]);
            return stack;
        }

        private static int[,] FillDPMatrix(int[,] arr, int rows, int cols)
        {
            int[,] dp = new int[rows, cols];
            dp[dp.GetLength(0) - 1, dp.GetLength(1) - 1] = arr[arr.GetLength(0) - 1, arr.GetLength(1) - 1];

            for (int i = dp.GetLength(1) - 2; i >= 0; i--)
                dp[dp.GetLength(0) - 1, i] = dp[dp.GetLength(0) - 1, i + 1] + arr[arr.GetLength(0) - 1, i];

            for (int i = dp.GetLength(0) - 2; i >= 0; i--)     
                dp[i, dp.GetLength(1) - 1] = dp[i + 1, dp.GetLength(1) - 1] + arr[i, arr.GetLength(1) - 1];

            for (int i = dp.GetLength(0) - 2; i >= 0; i--)
            {
                for (int j = dp.GetLength(1) - 2; j >= 0; j--)
                {
                    dp[i, j] = arr[i, j] + Math.Max(dp[i + 1, j], dp[i, j + 1]);
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
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
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
