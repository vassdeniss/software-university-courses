using System;
using System.Linq;

namespace L01.SumMatrixElements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int[,] matrix = new int[size[0], size[1]];
            int sum = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int[] nums = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    sum += nums[j];
                    matrix[i, j] = nums[j];
                }
            }

            Console.WriteLine($"{matrix.GetLength(0)}\n{matrix.GetLength(1)}\n{sum}");
        }
    }
}
