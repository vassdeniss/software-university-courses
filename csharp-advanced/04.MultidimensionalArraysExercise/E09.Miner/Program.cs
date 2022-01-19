using System;
using System.Collections.Generic;
using System.Linq;

namespace E09.Miner
{
    internal class Program
    {
        private static int Coal = 0;

        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            Queue<string> directions = new Queue<string>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries));
            int[] start = new int[2];
            char[,] field = RegisterMatrix(size, start);

            Explore(field, start[0], start[1], directions);
        }

        private static void Explore(char[,] field, int row, int col, Queue<string> queue)
        {
            if (field[row, col] == 'c')
            {
                Coal--;

                if (Coal == 0)
                {
                    Console.WriteLine($"You collected all coals! ({row}, {col})");
                    return;
                }

                field[row, col] = '*';
            }

            if (field[row, col] == 'e')
            {
                Console.WriteLine($"Game over! ({row}, {col})");
                return;
            }

            if (queue.Count == 0)
            {
                Console.WriteLine($"{Coal} coals left. ({row}, {col})");
                return;
            }

            string direction;
            do
            {
                if (queue.Count == 0)
                {
                    Console.WriteLine($"{Coal} coals left. ({row}, {col})");
                    return;
                }

                direction = queue.Dequeue();
            }
            while (IsOutsideRange(field, direction, row, col));

            switch (direction)
            {
                case "up": Explore(field, row - 1, col, queue);  break;
                case "down": Explore(field, row + 1, col, queue);  break;
                case "left": Explore(field, row, col - 1, queue); break;
                case "right": Explore(field, row, col + 1, queue);  break;
            }

            return;
        }

        private static bool IsOutsideRange(char[,] field, string direction, int row, int col)
        {
            return (direction == "up" && row - 1 < 0) ||
                (direction == "down" && row + 1 >= field.GetLength(0)) ||
                (direction == "left" && col - 1 < 0) ||
                (direction == "right" && col + 1 >= field.GetLength(1));
        }

        private static char[,] RegisterMatrix(int n, int[] arr)
        {
            char[,] matrix = new char[n, n];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                char[] chars = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse).ToArray();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = chars[j];

                    if (matrix[i, j] == 's')
                    {
                        arr[0] = i;
                        arr[1] = j;
                    }

                    if (matrix[i, j] == 'c') Coal++;
                }
            }

            return matrix;
        }
    }
}
