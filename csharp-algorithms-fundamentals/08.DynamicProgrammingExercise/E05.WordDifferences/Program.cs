using System;

namespace E05.WordDifferences
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string strOne = Console.ReadLine();
            string strTwo = Console.ReadLine();

            int[,] matrix = new int[strOne.Length + 1, strTwo.Length + 1];

            for (int i = 0; i < matrix.GetLength(0); i++) matrix[i, 0] = i;
            for (int i = 0; i < matrix.GetLength(1); i++) matrix[0, i] = i;

            for (int i = 1; i < matrix.GetLength(0); i++)
            {
                for (int j = 1; j < matrix.GetLength(1); j++)
                {
                    if (strOne[i - 1] == strTwo[j - 1]) matrix[i, j] = matrix[i - 1, j - 1];
                    else matrix[i, j] = Math.Min(matrix[i - 1, j], matrix[i, j - 1]) + 1;
                }
            }

            Console.WriteLine($"Deletions and Insertions: {matrix[strOne.Length, strTwo.Length]}");
        }
    }
}
