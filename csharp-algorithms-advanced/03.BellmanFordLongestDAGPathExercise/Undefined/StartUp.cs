using System;
using System.Collections.Generic;
using System.Linq;

namespace Undefined
{
    public class Edge
    {
        public int From { get; set; }

        public int To { get; set; }

        public int Weight { get; set; }
    }

    public class StartUp
    {
        public static List<Edge> edges;

        public static void Main()
        {
            int nodeCount = int.Parse(Console.ReadLine());
            int edgeCount = int.Parse(Console.ReadLine());

            edges = ReadGraph(edgeCount);

            int source = int.Parse(Console.ReadLine());
            int destination = int.Parse(Console.ReadLine());

            double[] distances = new double[nodeCount + 1];
            Array.Fill(distances, double.PositiveInfinity);

            int[] previous = new int[nodeCount + 1];
            Array.Fill(previous, -1);

            distances[source] = 0;
            for (int i = 0; i < nodeCount - 1; i++)
            {
                bool updated = false;
                foreach (Edge edge in edges)
                {
                    if (double.IsPositiveInfinity(edge.From))
                    {
                        continue;
                    }

                    double newDistance = distances[edge.From] + edge.Weight;
                    if (newDistance < distances[edge.To])
                    {
                        distances[edge.To] = newDistance;
                        previous[edge.To] = edge.From;
                        updated = true;
                    }
                }

                if (!updated)
                {
                    break;
                }
            }

            foreach (Edge edge in edges)
            {
                if (double.IsPositiveInfinity(edge.From))
                {
                    continue;
                }

                double newDistance = distances[edge.From] + edge.Weight;
                if (newDistance < distances[edge.To])
                {
                    Console.WriteLine("Undefined");
                    return;
                }
            }

            Stack<int> path = new Stack<int>();

            int node = destination;
            while (node != -1)
            {
                path.Push(node);
                node = previous[node];
            }

            Console.WriteLine(string.Join(" ", path));
            Console.WriteLine(distances[destination]);
        }

        private static List<Edge> ReadGraph(int edgeCount)
        {
            List<Edge> result = new List<Edge>();

            for (int i = 0; i < edgeCount; i++)
            {
                int[] edgeData = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                int from = edgeData[0];
                int to = edgeData[1];
                int weight = edgeData[2];

                result.Add(new Edge
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
