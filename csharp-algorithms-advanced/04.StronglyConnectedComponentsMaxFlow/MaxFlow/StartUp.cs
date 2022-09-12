using System;
using System.Collections.Generic;
using System.Linq;

namespace MaxFlow
{
    public class StartUp
    {
        private static int[,] graph;
        private static int[] parents;

        public static void Main()
        {
            int nodes = int.Parse(Console.ReadLine());

            graph = ReadGraph(nodes);

            int source = int.Parse(Console.ReadLine());
            int destination = int.Parse(Console.ReadLine());

            parents = new int[nodes];
            Array.Fill(parents, -1);

            int maxFlow = 0;
            while (BFS(source, destination))
            {
                int currentFlow = GetCurrentFlow(source, destination);
                maxFlow += currentFlow;
                ApplyCurrentFlow(source, destination, currentFlow);
            }

            Console.WriteLine($"Max flow = {maxFlow}");
        }

        private static void ApplyCurrentFlow(int source, int destination, int flow)
        {
            int node = destination;
            while (node != source)
            {
                int parent = parents[node];
                graph[parent, node] -= flow;
                node = parent;
            }
        }

        private static int GetCurrentFlow(int source, int destination)
        {
            int minFlow = int.MaxValue;

            int node = destination;
            while (node != source)
            {
                int parent = parents[node];

                int flow = graph[parent, node];
                if (flow < minFlow)
                {
                    minFlow = flow;
                }

                node = parent;
            }

            return minFlow;
        }

        private static bool BFS(int source, int destination)
        {
            Queue<int> queue = new Queue<int>();
            bool[] visited = new bool[graph.GetLength(0)];

            queue.Enqueue(source);
            visited[source] = true;

            while (queue.Count > 0)
            {
                int node = queue.Dequeue();
                for (int child = 0; child < graph.GetLength(1); child++)
                {
                    if (!visited[child] && graph[node, child] > 0)
                    {
                        visited[child] = true;
                        queue.Enqueue(child);
                        parents[child] = node;
                    }
                }
            }

            return visited[destination];
        }

        private static int[,] ReadGraph(int nodes)
        {
            int[,] result = new int[nodes, nodes];

            for (int node = 0; node < nodes; node++)
            {
                int[] capacities = Console.ReadLine()
                    .Split(", ")
                    .Select(int.Parse)
                    .ToArray();

                for (int child = 0; child < capacities.Length; child++)
                {
                    int capacity = capacities[child];
                    result[node, child] = capacity;
                }
            }

            return result;
        }
    }
}
