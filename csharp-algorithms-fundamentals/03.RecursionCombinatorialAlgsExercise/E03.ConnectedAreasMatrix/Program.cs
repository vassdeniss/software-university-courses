using System;
using System.Collections.Generic;
using System.Linq;

namespace E03.ConnectedAreasMatrix
{
    class Area
    {
        public int Row { get; set; }
        public int Col { get; set; }
        public int Size { get; set; }
    }

    internal class Program
    {
        static char[,] _matrix;

        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());

            _matrix = new char[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                string elements = Console.ReadLine();
                for (int j = 0; j < cols; j++)
                {
                    _matrix[i, j] = elements[j];
                }
            }

            List<Area> areas = new List<Area>();
            for (int i = 0; i < _matrix.GetLength(0); i++)
            {
                for (int j = 0; j < _matrix.GetLength(1); j++)
                {
                    Area area = new Area() { Row = i, Col = j };
                    Explore(i, j, area);
                    if (area.Size != 0) areas.Add(area);
                }
            }

            Print(areas);
        }

        private static void Print(List<Area> list)
        {
            int n = 1;
            Console.WriteLine($"Total areas found: {list.Count}");
            foreach (Area area in list.OrderByDescending(x => x.Size).ThenBy(x => x.Row).ThenBy(x => x.Col))
            {
                Console.WriteLine($"Area #{n} at ({area.Row}, {area.Col}), size: {area.Size}");
                n++;
            }
        }

        private static void Explore(int row, int col, Area area)
        {
            if (IsInvalid(row, col)) return;

            area.Size++;
            _matrix[row, col] = 'v';

            Explore(row + 1, col, area);
            Explore(row - 1, col, area);
            Explore(row, col + 1, area);
            Explore(row, col - 1, area);
        }

        private static bool IsInvalid(int row, int col) =>
            row < 0 || col < 0 || row >= _matrix.GetLength(0) || col >= _matrix.GetLength(1)
            || _matrix[row, col] == 'v' || _matrix[row, col] == '*';
    }
}
