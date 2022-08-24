using System;
using System.Collections.Generic;
using System.Linq;

using Wintellect.PowerCollections;

namespace DijkstraAlgorithm
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
        private static Dictionary<int, List<Edge>> edgesByNode;

        public static void Main()
        {
            int edgeQty = int.Parse(Console.ReadLine());

            edgesByNode = ReadEdges(edgeQty);

            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());

            int[] distance = new int[edgesByNode.Keys.Max() + 1];

            // Judge .NET Framework
            //for (int i = 0; i < distance.Length; i++)
            //{
            //    distance[i] = int.MaxValue;
            //}

            Array.Fill(distance, int.MaxValue);
            distance[start] = 0;

            int[] previous = new int[edgesByNode.Keys.Max() + 1];
            previous[start] = -1;

            OrderedBag<int> queue = new OrderedBag<int>(Comparer<int>.Create((f, s) => distance[f] - distance[s]));

            queue.Add(start);
            while (queue.Count > 0)
            {
                int minNode = queue.RemoveFirst();
                List<Edge> children = edgesByNode[minNode];

                if (minNode == end)
                {
                    break;
                }

                foreach (Edge childEdge in children)
                {
                    int childNode = childEdge.First == minNode
                        ? childEdge.Second
                        : childEdge.First;
                    if (distance[childNode] == int.MaxValue)
                    {
                        queue.Add(childNode);
                    }

                    int newDistance = childEdge.Weight + distance[minNode];
                    if (newDistance < distance[childNode])
                    {
                        distance[childNode] = newDistance;
                        previous[childNode] = minNode;
                        queue = new OrderedBag<int>(
                            queue, Comparer<int>.Create((f, s) => distance[f] - distance[s]));
                    }
                }
            }

            if (distance[end] == int.MaxValue)
            {
                Console.WriteLine("There is no such path.");
                return;
            }

            Console.WriteLine(distance[end]);

            Stack<int> path = new Stack<int>();
            int node = end;
            while (node != -1)
            {
                path.Push(node);
                node = previous[node];
            }

            Console.WriteLine(string.Join(" ", path));
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
