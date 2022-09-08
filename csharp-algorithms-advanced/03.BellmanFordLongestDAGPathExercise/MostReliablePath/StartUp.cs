using System;
using System.Collections.Generic;
using System.Linq;

using Wintellect.PowerCollections;

namespace MostReliablePath
{
    class Edge
    {
        public int First { get; set; }

        public int Second { get; set; }

        public int Weight { get; set; }
    }

    public class StartUp
    {
        private static List<Edge>[] graph;

        public static void Main()
        {
            int nodeCount = int.Parse(Console.ReadLine());
            int edgeCount = int.Parse(Console.ReadLine());

            graph = ReadGraph(nodeCount, edgeCount);

            int source = int.Parse(Console.ReadLine());
            int destination = int.Parse(Console.ReadLine());

            double[] distances = new double[nodeCount];
            Array.Fill(distances, double.NegativeInfinity);

            int[] previous = new int[nodeCount];
            Array.Fill(previous, -1);

            distances[source] = 100;

            OrderedBag<int> queue = new OrderedBag<int>(
                Comparer<int>.Create((f, s) => distances[s].CompareTo(distances[f])));

            queue.Add(source);
            while (queue.Count > 0)
            {
                int node = queue.RemoveFirst();

                if (node == destination)
                {
                    break;
                }

                List<Edge> children = graph[node];
                foreach (Edge edge in children)
                {
                    int child = edge.First == node
                        ? edge.Second
                        : edge.First;

                    if (double.IsNegativeInfinity(distances[child]))
                    {
                        queue.Add(child);
                    }

                    double newDistance = distances[node] * edge.Weight / 100.0;
                    if (newDistance > distances[child])
                    {
                        distances[child] = newDistance;
                        previous[child] = node;

                        queue = new OrderedBag<int>(
                            queue,
                            Comparer<int>.Create((f, s) => distances[s].CompareTo(distances[f])));
                    }
                }
            }

            Console.WriteLine($"Most reliable path reliability: {distances[destination]:f2}%");
            Stack<int> path = GetPath(previous, destination);

            Console.WriteLine(string.Join(" -> ", path));
        }

        private static Stack<int> GetPath(int[] previous, int node)
        {
            Stack<int> path = new Stack<int>();

            while (node != -1)
            {
                path.Push(node);
                node = previous[node];
            }

            return path;
        }

        private static List<Edge>[] ReadGraph(int nodeCount, int edgeCount)
        {
            List<Edge>[] result = new List<Edge>[nodeCount];

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = new List<Edge>();
            }

            for (int i = 0; i < edgeCount; i++)
            {
                int[] edgeData = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                int first = edgeData[0];
                int second = edgeData[1];
                int weight = edgeData[2];

                Edge edge = new Edge
                {
                    First = first,
                    Second = second,
                    Weight = weight
                };

                result[first].Add(edge);
                result[second].Add(edge);
            }

            return result;
        }
    }
}
