using System;
using System.Collections.Generic;
using System.Linq;

namespace E06.RoadReconstruction
{
    class Edge
    {
        public Edge(int from, int to)
        {
            _from = from;
            _to = to;
        }

        private readonly int _from;
        private readonly int _to;

        public int From { get { return _from; } }
        public int To { get { return _to; } }

        public override string ToString()
        {
            int first = Math.Min(_from, _to);
            int second = Math.Max(_from, _to);

            return $"{first} {second}";
        }
    }

    internal class Program
    {
        private static List<int>[] Graph;
        private static List<Edge> Edges;
        private static bool[] Visited;

        static void Main(string[] args)
        {
            int buildings = int.Parse(Console.ReadLine());
            int streets = int.Parse(Console.ReadLine());

            Graph = new List<int>[buildings];
            for (int i = 0; i < Graph.Length; i++)
            {
                Graph[i] = new List<int>();
            }

            Edges = new List<Edge>();
            for (int i = 0; i < streets; i++)
            {
                int[] edges = Console.ReadLine().Split(" - ").Select(int.Parse).ToArray();

                int from = edges[0];
                int to = edges[1];

                Graph[from].Add(to);
                Graph[to].Add(from);

                Edges.Add(new Edge(from, to));
            }

            Console.WriteLine("Important streets:");
            foreach (Edge edge in Edges)
            {
                Graph[edge.From].Remove(edge.To);
                Graph[edge.To].Remove(edge.From);

                Visited = new bool[Graph.Length];
                DFS(0);

                if (Visited.Contains(false))
                {
                    Console.WriteLine(edge);
                }

                Graph[edge.From].Add(edge.To);
                Graph[edge.To].Add(edge.From);
            }
        }

        private static void DFS(int node)
        {
            if (Visited[node]) return;

            Visited[node] = true;
            foreach (int child in Graph[node])
            {
                DFS(child);
            }
        }
    }
}
