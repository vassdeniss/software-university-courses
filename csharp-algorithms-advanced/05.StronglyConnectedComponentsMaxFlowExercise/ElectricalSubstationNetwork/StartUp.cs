using System;
using System.Collections.Generic;
using System.Linq;

namespace ElectricalSubstationNetwork
{
    public class StartUp
    {
        private static List<int>[] graph;
        private static List<int>[] reversedGraph;
        private static Stack<int> sorted;

        public static void Main()
        {
            int nodesCount = int.Parse(Console.ReadLine());
            int linesCount = int.Parse(Console.ReadLine());

            (graph, reversedGraph) = ReadGraph(nodesCount, linesCount);

            sorted = TopologicalSort();

            bool[] visited = new bool[nodesCount];
            while (sorted.Count > 0)
            {
                int node = sorted.Pop();

                if (visited[node])
                {
                    continue;
                }

                Stack<int> component = new Stack<int>();
                DFS(reversedGraph, node, visited, component);
                Console.WriteLine(string.Join(", ", component));
            }
        }

        private static Stack<int> TopologicalSort()
        {
            Stack<int> result = new Stack<int>();

            bool[] visited = new bool[graph.Length];
            for (int i = 0; i < graph.Length; i++)
            {
                if (!visited[i])
                {
                    DFS(graph, i, visited, result);
                }
            }

            return result;
        }

        private static void DFS(List<int>[] source, int node, bool[] visited, Stack<int> result)
        {
            if (visited[node])
            {
                return;
            }

            visited[node] = true;

            foreach (int child in source[node])
            {
                DFS(source, child, visited, result);
            }

            result.Push(node);
        }

        private static (List<int>[] graph, List<int>[] reversedGraph) ReadGraph(int nodesCount, int linesCount)
        {
            List<int>[] graph = new List<int>[nodesCount];
            List<int>[] reversedGraph = new List<int>[nodesCount];

            for (int i = 0; i < nodesCount; i++)
            {
                graph[i] = new List<int>();
                reversedGraph[i] = new List<int>();
            }

            for (int i = 0; i < linesCount; i++)
            {
                int[] data = Console.ReadLine()
                    .Split(", ")
                    .Select(int.Parse)
                    .ToArray();

                int node = data[0];
                for (int j = 1; j < data.Length; j++)
                {
                    int child = data[j];
                    graph[node].Add(child);
                    reversedGraph[child].Add(node);
                }
            }

            return (graph, reversedGraph);
        }
    }
}
