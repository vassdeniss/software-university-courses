using System;

namespace L04.SymbolInMatrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] matrix = RegisterMatrix(size);
            char character = char.Parse(Console.ReadLine());

            string idx = "-1";
            bool isFound = false;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == character)
                    {
                        idx = $"({i}, {j})";
                        isFound = true;
                        break;
                    }
                }

                if (isFound) break;
            }

            if (idx == "-1") Console.WriteLine($"{character} does not occur in the matrix");
            else Console.WriteLine(idx);
        }

        private static char[,] RegisterMatrix(int n)
        {
            char[,] matrix = new char[n, n];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                string elements = Console.ReadLine();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = elements[j];
                }
            }

            return matrix;
        }
    }
}
