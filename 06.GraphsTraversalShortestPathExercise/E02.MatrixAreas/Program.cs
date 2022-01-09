using System;
using System.Collections.Generic;

namespace E02.MatrixAreas
{
    internal class Program
    {
        private static char[,] Graph;
        private static bool[,] Visited;
        private static SortedDictionary<char, int> Areas;

        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());

            Graph = RegisterMatrix(rows, cols);
            Visited = new bool[rows, cols];
            Areas = new SortedDictionary<char, int>();

            int areas = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (!Visited[i, j])
                    {
                        char value = Graph[i, j];
                        DFS(i, j, value);

                        areas++;
                        if (Areas.ContainsKey(value)) Areas[value]++;
                        else Areas[value] = 1;
                    }
                }
            }

            Console.WriteLine($"Areas: {areas}");
            foreach (KeyValuePair<char, int> kvp in Areas) 
                Console.WriteLine($"Letter '{kvp.Key}' -> {kvp.Value}");
        }

        private static void DFS(int row, int col, char value)
        {
            if (row < 0 || row >= Graph.GetLength(0) || col < 0 || col >= Graph.GetLength(1)) return;
            if (Visited[row, col]) return;
            if (Graph[row, col] != value) return;

            Visited[row, col] = true;

            DFS(row + 1, col, value);
            DFS(row - 1, col, value);
            DFS(row, col + 1, value);
            DFS(row, col - 1, value);
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
