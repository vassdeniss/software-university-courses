using System;
using System.Linq;

namespace E02.SquaresInMatrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string[,] matrix = RegisterMatrix(size[0], size[1]);

            int count = FindMaxSquare(matrix);
            Console.WriteLine(count);
        }

        private static int FindMaxSquare(string[,] matrix)
        {
            int total = 0;

            for (int i = 0; i < matrix.GetLength(0) - 1; i++)
            {
                for (int j = 0; j < matrix.GetLength(1) - 1; j++)
                {
                    string comparator = matrix[i, j];
                    if (matrix[i, j + 1] == comparator 
                        && matrix[i + 1, j] == comparator 
                        && matrix[i + 1, j + 1] == comparator)
                    {
                        total++;
                    }
                }
            }

            return total;
        }

        private static string[,] RegisterMatrix(int r, int c)
        {
            string[,] matrix = new string[r, c];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                string[] chars = Console.ReadLine().Split();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = chars[j];
                }
            }

            return matrix;
        }
    }
}
