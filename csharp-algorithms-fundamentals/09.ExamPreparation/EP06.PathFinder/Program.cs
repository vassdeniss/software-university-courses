using System;
using System.Collections.Generic;
using System.Linq;

namespace EP06.PathFinder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int nodes = int.Parse(Console.ReadLine());
            List<int>[] graph = RegisterGraph(nodes);

            int pathsCheck = int.Parse(Console.ReadLine());
            CheckPaths(graph, pathsCheck);
        }

        private static void CheckPaths(List<int>[] graph, int pathsCheck)
        {
            for (int i = 0; i < pathsCheck; i++)
            {
                int[] nodes = Console.ReadLine()
                    .Split().Select(int.Parse).ToArray();

                bool path = true;
                for (int j = 0; j < nodes.Length - 1; j++)
                {
                    if (!graph[nodes[j]].Contains(nodes[j + 1]))
                    {
                        path = false;
                        break;
                    }
                }

                if (path) Console.WriteLine("yes");
                else Console.WriteLine("no");
            }
        }

        private static List<int>[] RegisterGraph(int n)
        {
            List<int>[] graph = new List<int>[n];

            for (int i = 0; i < n; i++)
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
