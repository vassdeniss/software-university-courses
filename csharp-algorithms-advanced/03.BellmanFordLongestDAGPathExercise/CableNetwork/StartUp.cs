using System;
using System.Collections.Generic;
using System.Linq;

using Wintellect.PowerCollections;

namespace CableNetwork
{
    public class Edge
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

    public class Startup
    {
        private static List<Edge>[] graph;
        private static HashSet<int> spanningTree;

        public static void Main()
        {
            int budget = int.Parse(Console.ReadLine());
            int nodeCount = int.Parse(Console.ReadLine());
            int edgeCount = int.Parse(Console.ReadLine());

            spanningTree = new HashSet<int>();
            graph = ReadEdges(nodeCount, edgeCount);

            Console.WriteLine($"Budget used: {Prim(budget)}");
        }

        private static int Prim(int budget)
        {
            OrderedBag<Edge> queue = new OrderedBag<Edge>(Comparer<Edge>.Create((f, s) => f.Weight - s.Weight));

            int cost = 0;

            foreach (int node in spanningTree)
            {
                queue.AddMany(graph[node]);
            }

            while (queue.Count > 0)
            {
                Edge edge = queue.RemoveFirst();
                int nonTreeNode = -1;

                if (spanningTree.Contains(edge.First) && !spanningTree.Contains(edge.Second))
                {
                    nonTreeNode = edge.Second;
                }
                else if (!spanningTree.Contains(edge.First) && spanningTree.Contains(edge.Second))
                {
                    nonTreeNode = edge.First;
                }

                if (nonTreeNode == -1)
                {
                    continue;
                }

                if (edge.Weight > budget)
                {
                    break;
                }

                cost += edge.Weight;
                budget -= edge.Weight;

                spanningTree.Add(nonTreeNode);
                queue.AddMany(graph[nonTreeNode]);
            }

            return cost;
        }

        private static List<Edge>[] ReadEdges(int nodeCount, int edgeCount)
        {
            List<Edge>[] result = new List<Edge>[nodeCount];

            for (int i = 0; i < nodeCount; i++)
            {
                result[i] = new List<Edge>();
            }

            for (int i = 0; i < edgeCount; i++)
            {
                string[] edgeData = Console.ReadLine()
                    .Split(new char[] { ',', ' '})
                    //.Split(", ")
                    .ToArray();

                int first = int.Parse(edgeData[0]);
                int second = int.Parse(edgeData[1]);
                int weight = int.Parse(edgeData[2]);

                if (edgeData.Length == 4)
                {
                    spanningTree.Add(first);
                    spanningTree.Add(second);
                }

                Edge edge = new Edge(first, second, weight);

                result[first].Add(edge);
                result[second].Add(edge);
            }

            return result;
        }
    }
}
