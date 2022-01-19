using System;
using System.Collections.Generic;
using System.Linq;

namespace E05.SnakeMoves
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            char[,] matrix = new char[dimensions[0], dimensions[1]];
            char[] snek = Console.ReadLine().ToCharArray();

            Queue<char> snekQueue = new Queue<char>(snek);
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (i % 2 == 0)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        matrix[i, j] = snekQueue.Dequeue();
                        if (snekQueue.Count == 0)
                            snekQueue = new Queue<char>(snek);
                    }
                }
                else
                {
                    for (int j = matrix.GetLength(1) - 1; j >= 0; j--)
                    {
                        matrix[i, j] = snekQueue.Dequeue();
                        if (snekQueue.Count == 0)
                            snekQueue = new Queue<char>(snek);
                    }
                }
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j]);
                }

                Console.WriteLine();
            }
        }
    }
}
