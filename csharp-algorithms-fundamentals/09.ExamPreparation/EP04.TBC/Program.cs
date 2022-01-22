using System;

namespace EP04.TBC
{
    internal class Program
    {
        private static char Dirt = 'd';
        private static char Visit = 'v';

        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());

            char[,] map = RegisterMatrix(rows, cols);

            int areas = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (map[i, j] != Dirt && map[i, j] != Visit)
                    {
                        Explore(map, i, j);
                        areas++;
                    }
                }
            }

            Console.WriteLine(areas);
        }

        private static void Explore(char[,] map, int row, int col)
        {
            if (row < 0 || row >= map.GetLength(0) || col < 0 || col >= map.GetLength(1)) return;
            if (map[row, col] == Dirt) return;
            if (map[row, col] == Visit) return;

            map[row, col] = Visit;

            Explore(map, row + 1, col);
            Explore(map, row - 1, col);
            Explore(map, row, col + 1);
            Explore(map, row, col - 1);
            Explore(map, row - 1, col - 1);
            Explore(map, row - 1, col + 1);
            Explore(map, row + 1, col - 1);
            Explore(map, row + 1, col + 1);
        }

        private static char[,] RegisterMatrix(int rows, int cols)
        {
            char[,] matrix = new char[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                string data = Console.ReadLine();
                for (int j = 0; j < data.Length; j++)
                {
                    matrix[i, j] = data[j];
                }
            }

            return matrix;
        }
    }
}
