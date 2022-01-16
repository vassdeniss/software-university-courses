using System;
using System.Linq;

namespace L03.PrimaryDiagonal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[,] matrix = RegisterMatrix(size);

            int sum = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
                sum += matrix[i, i];

            Console.WriteLine(sum);
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
