using System;
using System.Collections.Generic;
using System.Linq;

namespace EP08.Paths
{
    internal class Program
    {
        private static List<int> Path;
        private static bool[] Visited;

        static void Main(string[] args)
        {
            int nodes = int.Parse(Console.ReadLine());
            List<int>[] graph = RegisterGraph(nodes);

            for (int i = 0; i < graph.Length - 1; i++)
            {
                Visited = new bool[graph.Length];
                Path = new List<int>();

                DFS(graph, i, graph.Length - 1);
            }
        }

        private static void DFS(List<int>[] graph, int node, int target)
        {
            if (Visited[node]) return;

            Path.Add(node);
            if (node == target)
            {
                Console.WriteLine(string.Join(" ", Path));
                Path.RemoveAt(Path.Count - 1);
                return;
            }

            Visited[node] = true;

            foreach (int child in graph[node]) DFS(graph, child, target);

            Visited[node] = false;
            Path.RemoveAt(Path.Count - 1);
        }

        private static List<int>[] RegisterGraph(int n)
        {
            List<int>[] graph = new List<int>[n];

            for (int i = 0; i < n - 1; i++)
            {
                int[] children = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();

                graph[i] = new List<int>();
                if (children.Length == 0) continue;
                foreach (int child in children) graph[i].Add(child);
            }

            return graph;
        }
    }
}
