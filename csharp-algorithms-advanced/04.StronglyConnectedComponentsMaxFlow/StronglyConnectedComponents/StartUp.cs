using System;
using System.Collections.Generic;
using System.Linq;

namespace StronglyConnectedComponents
{
    public class StartUp
    {
        private static List<int>[] graph;
        private static List<int>[] reversed;
        private static Stack<int> sorted;

        public static void Main()
        {
            int nodeCount = int.Parse(Console.ReadLine());
            int lineCount = int.Parse(Console.ReadLine());

            (graph, reversed) = ReadGraph(nodeCount, lineCount);

            sorted = TopologicalSort();
            
            bool[] visited = new bool[nodeCount];

            Console.WriteLine("Strongly Connected Components:");
            while (sorted.Count > 0)
            {
                int node = sorted.Pop();

                if (visited[node])
                {
                    continue;
                }

                Stack<int> component = new Stack<int>();
                DFS(reversed, node, visited, component);

                Console.WriteLine($"{{{string.Join(", ", component)}}}");
            }
        }

        private static Stack<int> TopologicalSort()
        {
            Stack<int> result = new Stack<int>();

            bool[] visited = new bool[graph.Length];
            for (int i = 0; i < graph.Length; i++)
            {
                DFS(graph, i, visited, result);
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

        private static (List<int>[] graph, List<int>[] reversed) ReadGraph(int nodeCount, int lineCount)
        {
            List<int>[] result = new List<int>[nodeCount];
            List<int>[] reversed = new List<int>[nodeCount];

            for (int i = 0; i < nodeCount; i++)
            {
                result[i] = new List<int>();
                reversed[i] = new List<int>();
            }

            for (int i = 0; i < lineCount; i++)
            {
                int[] data = Console.ReadLine()
                    .Split(", ")
                    .Select(int.Parse)
                    .ToArray();

                int node = data[0];
                for (int j = 1; j < data.Length; j++)
                {
                    int child = data[j];
                    result[node].Add(child);
                    reversed[child].Add(node);
                }
            }

            return (result, reversed);
        }
    }
}
