using System;
using System.Linq;

namespace E01.DiagonalDifferencce
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[,] matrix = RegisterMatrix(size);

            int primaryDiagonal = 0;
            int secondaryDiagonal = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (i == j) primaryDiagonal += matrix[i, j];
                    if (i + j == size - 1) secondaryDiagonal += matrix[i, j];
                }
            }

            Console.WriteLine($"{Math.Abs(primaryDiagonal - secondaryDiagonal)}");
        }

        private static int[,] RegisterMatrix(int n)
        {
            int[,] matrix = new int[n, n];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = nums[j];
                }
            }

            return matrix;
        }
    }
}
