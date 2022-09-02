using System;
using System.Collections.Generic;
using System.Linq;

namespace LongestPath
{
    public class Node
    {
        public int From { get; set; }

        public int To { get; set; }

        public int Weight { get; set; }
    }

    public class StartUp
    {
        private static List<Node>[] graph;

        public static void Main()
        {
            int nodeCount = int.Parse(Console.ReadLine());
            int edgeCount = int.Parse(Console.ReadLine());

            graph = ReadGraph(nodeCount, edgeCount);

            int source = int.Parse(Console.ReadLine());
            int destination = int.Parse(Console.ReadLine());

            Stack<int> sortedNodes = TopologicalSort();

            double[] distances = new double[graph.Length];
            Array.Fill(distances, double.NegativeInfinity);
            distances[source] = 0;

            while (sortedNodes.Count > 0)
            {
                int node = sortedNodes.Pop();
                foreach (Node edge in graph[node])
                {
                    double newDistance = distances[node] + edge.Weight;
                    if (newDistance > distances[edge.To])
                    {
                        distances[edge.To] = newDistance;
                    }
                }
            }

            Console.WriteLine(distances[destination]);
        }

        private static Stack<int> TopologicalSort()
        {
            bool[] visited = new bool[graph.Length];

            Stack<int> sorted = new Stack<int>();
            for (int i = 0; i < graph.Length; i++)
            {
                DFS(i, visited, sorted);
            }

            return sorted;
        }

        private static void DFS(int node, bool[] visited, Stack<int> sorted)
        {
            if (visited[node])
            {
                return;
            }

            visited[node] = true;
            foreach (Node edge in graph[node])
            {
                DFS(edge.To, visited, sorted);
            }

            sorted.Push(node);
        }

        private static List<Node>[] ReadGraph(int nodeCount, int edgeCount)
        {
            List<Node>[] result = new List<Node>[nodeCount + 1];

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = new List<Node>();
            }

            for (int i = 0; i < edgeCount; i++)
            {
                int[] edgeData = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                int from = edgeData[0];
                int to = edgeData[1];
                int weight = edgeData[2];

                result[from].Add(new Node
                {
                    From = from,
                    To = to,
                    Weight = weight
                });
            }

            return result;
        }
    }
}
