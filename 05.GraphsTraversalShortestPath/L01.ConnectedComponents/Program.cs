using System;
using System.Collections.Generic;
using System.Linq;

namespace L01.ConnectedComponents
{
    internal class Program
    {
        private static List<int>[] Graph;
        private static bool[] Visited;

        static void Main(string[] args)
        {
            Graph = RegisterGraph(int.Parse(Console.ReadLine()));
            FindConnectedComponents();
        }

        private static List<int>[] RegisterGraph(int n)
        {
            List<int>[] graph = new List<int>[n];
            for (int i = 0; i < n; i++)
            {
                string data = Console.ReadLine();
                if (string.IsNullOrEmpty(data))
                {
                    graph[i] = new List<int>();
                    continue;
                }

                List<int> children = data.Split().Select(int.Parse).ToList();
                graph[i] = new List<int>(children);
            }

            return graph;
        }

        private static void FindConnectedComponents()
        {
            Visited = new bool[Graph.Length];
            for (int i = 0; i < Graph.Length; i++)
            {
                if (!Visited[i])
                {
                    Console.Write("Connected component: ");
                    DFS(i);
                    Console.WriteLine();
                }
            }
        }

        private static void DFS(int node)
        {
            if (Visited[node]) return; 

            if (!Visited[node])
            {
                Visited[node] = true;
                foreach (int child in Graph[node]) DFS(child);
                Console.Write($"{node} ");
            }
        }
    }
}
