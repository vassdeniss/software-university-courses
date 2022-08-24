using System;
using System.Collections.Generic;
using System.Linq;

namespace KruskalAlgorithm
{
    class Edge
    {
        public Edge(int first, int second, int weight)
        {
            this.First = first;
            this.Second = second;
            this.Weight = weight;
        }

        public int First { get; set; }

        public int Second { get; set; }

        public int Weight { get; set; }
    }

    public class StartUp
    {
        private static List<Edge> edges;

        public static void Main()
        {
            int edgeQty = int.Parse(Console.ReadLine());

            edges = ReadEdges(edgeQty);

            List<Edge> sortedEdges = edges
                .OrderBy(edge => edge.Weight)
                .ToList();

            HashSet<int> nodes = edges
                .Select(edge => edge.First)
                .Union(edges.Select(edge => edge.Second))
                .ToHashSet();

            int[] parents = Enumerable.Repeat(-1, nodes.Max() + 1)
                .ToArray();

            foreach (int node in nodes)
            {
                parents[node] = node;
            }

            foreach (Edge edge in sortedEdges)
            {
                int firstNodeRoot = GetRoot(parents, edge.First);
                int secondNodeRoot = GetRoot(parents, edge.Second);

                if (firstNodeRoot != secondNodeRoot)
                {
                    Console.WriteLine($"{edge.First} - {edge.Second}");
                    parents[firstNodeRoot] = secondNodeRoot;
                }
            }
        }

        private static int GetRoot(int[] parents, int node)
        {
            while (node != parents[node])
            {
                node = parents[node];
            }

            return node;
        }

        private static List<Edge> ReadEdges(int edgeQty)
        {
            List<Edge> result = new List<Edge>();
            for (int i = 0; i < edgeQty; i++)
            {
                int[] edgeData = Console.ReadLine()
                    // Judge .NET Framework
                    //.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Split(", ")
                    .Select(int.Parse)
                    .ToArray();

                int firstNode = edgeData[0];
                int secondNode = edgeData[1];
                int weight = edgeData[2];

                result.Add(new Edge(firstNode, secondNode, weight));
            }

            return result;
        }
    }
}
