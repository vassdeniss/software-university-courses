using System;
using System.Collections.Generic;

namespace L05.LabyrinthPaths
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());

            char[,] maze = new char[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                string colElements = Console.ReadLine();
                for (int j = 0; j < colElements.Length; j++)
                {
                    maze[i, j] = colElements[j];
                }
            }

            FindPaths(maze, 0, 0, new List<string>(), string.Empty);
        }

        private static void FindPaths(char[,] maze, int row, int col, List<string> path, string direction)
        {
            if (row < 0 || row >= maze.GetLength(0) || col < 0 || col >= maze.GetLength(1)) return;
            if (maze[row, col] == '*' || maze[row, col] == 'v') return;

            path.Add(direction);
            if (maze[row, col] == 'e')
            {
                Console.WriteLine(string.Join(string.Empty, path));
                path.RemoveAt(path.Count - 1);
                return;
            }

            maze[row, col] = 'v';

            FindPaths(maze, row + 1, col, path, "D"); // down
            FindPaths(maze, row - 1, col, path, "U"); // up
            FindPaths(maze, row, col + 1, path, "R"); // right
            FindPaths(maze, row, col - 1, path, "L"); // left

            maze[row, col] = '-';
            path.RemoveAt(path.Count - 1);
        }
    }
}
