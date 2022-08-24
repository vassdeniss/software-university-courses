using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

namespace PrimAlgorithm
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

    public class Startup
    {
        private static Dictionary<int, List<Edge>> edgesByNode;
        private static HashSet<int> forest;

        public static void Main()
        {
            int edgeQty = int.Parse(Console.ReadLine());

            edgesByNode = ReadEdges(edgeQty);
            forest = new HashSet<int>();

            foreach (int node in edgesByNode.Keys)
            {
                if (!forest.Contains(node))
                {
                    Prim(node);
                }
            } 
        }

        private static void Prim(int node)
        {
            forest.Add(node);

            OrderedBag<Edge> queue = new OrderedBag<Edge>(edgesByNode[node],
                Comparer<Edge>.Create((f, s) => f.Weight - s.Weight));
            while (queue.Count > 0)
            {
                Edge edge = queue.RemoveFirst();
                int nonTreeNode = -1;

                if (forest.Contains(edge.First) && !forest.Contains(edge.Second))
                {
                    nonTreeNode = edge.Second;
                }
                else if (!forest.Contains(edge.First) && forest.Contains(edge.Second))
                {
                    nonTreeNode = edge.First;
                }

                if (nonTreeNode == -1)
                {
                    continue;
                }

                Console.WriteLine($"{edge.First} - {edge.Second}");
                forest.Add(nonTreeNode);
                queue.AddMany(edgesByNode[nonTreeNode]);
            }
        }

        private static Dictionary<int, List<Edge>> ReadEdges(int edgeQty)
        {
            Dictionary<int, List<Edge>> result = new Dictionary<int, List<Edge>>();
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

                Edge edge = new Edge(firstNode, secondNode, weight);

                if (!result.ContainsKey(firstNode))
                {
                    result.Add(firstNode, new List<Edge>());
                }

                if (!result.ContainsKey(secondNode))
                {
                    result.Add(secondNode, new List<Edge>());
                }

                result[firstNode].Add(edge);
                result[secondNode].Add(edge);
            }

            return result;
        }
    }
}
