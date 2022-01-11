using System;
using System.Collections.Generic;

namespace L03.LongestCommonSubsequence
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string strOne = Console.ReadLine();
            string strTwo = Console.ReadLine();

            int[,] matrix = new int[strOne.Length + 1, strTwo.Length + 1];
            for (int i = 1; i < matrix.GetLength(0); i++)
            {
                for (int j = 1; j < matrix.GetLength(1); j++)
                {
                    if (strOne[i - 1] == strTwo[j - 1]) matrix[i, j] = matrix[i - 1, j - 1] + 1;
                    else matrix[i, j] = Math.Max(matrix[i, j - 1], matrix[i - 1, j]);
                }
            }

            Console.WriteLine(matrix[strOne.Length, strTwo.Length]);
            //Console.WriteLine(string.Join("", RecoverPath(matrix, strOne, strTwo)));
        }

        private static Stack<char> RecoverPath(int[,] matrix, string one, string two)
        {
            Stack<char> pathStack = new Stack<char>();
            int row = one.Length;
            int col = two.Length;

            while (row > 0 && col > 0)
            {
                if (one[row - 1] == two[col - 1] && matrix[row, col] == matrix[row - 1, col - 1] + 1)
                {
                    pathStack.Push(one[row - 1]);
                    row--;
                    col--;
                }
                else if (matrix[row - 1, col] > matrix[row, col - 1]) row--;
                else col--;
            }

            return pathStack;
        }
    }
}
