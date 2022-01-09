using System;
using System.Collections.Generic;
using System.Linq;

namespace E05.BreakCycles
{
    class Edge
    {
        public Edge(string from, string to)
        {
            _from = from;
            _to = to;
        }

        private readonly string _from;
        private readonly string _to;

        public string From { get { return _from; } }
        public string To { get { return _to; } }

        public override string ToString()
        {
            return $"{_from} - {_to}";
        }

        public string ToStringReversed()
        {
            return $"{_to} - {_from}";
        }
    }

    internal class Program
    {
        private static Dictionary<string, List<string>> Graph;
        private static List<Edge> Edges;

        static void Main(string[] args)
        {
            int nodes = int.Parse(Console.ReadLine());
            Edges = new List<Edge>();
            Graph = RegisterGraph(nodes);

            Edges = Edges.OrderBy(x => x.From).ThenBy(x => x.To).ToList();

            HashSet<string> reversedEdges = new HashSet<string>();
            List<string> removedEdges = new List<string>();
            foreach (Edge edge in Edges)
            {
                if (reversedEdges.Contains(edge.ToString())) continue;

                Graph[edge.From].Remove(edge.To);
                Graph[edge.To].Remove(edge.From);

                if (BFS(edge.From, edge.To))
                {
                    removedEdges.Add(edge.ToString());
                    reversedEdges.Add(edge.ToStringReversed());
                }
                else
                {
                    Graph[edge.From].Add(edge.To);
                    Graph[edge.To].Add(edge.From);
                }
            }

            Console.WriteLine($"Edges to remove: {removedEdges.Count}");
            foreach (string edge in removedEdges)
            {
                Console.WriteLine(edge);
            }
        }

        private static bool BFS(string start, string target)
        {
            Queue<string> queue = new Queue<string>();
            queue.Enqueue(start);

            HashSet<string> visited = new HashSet<string>();
            while (queue.Count > 0)
            {
                string node = queue.Dequeue();

                if (node == target) return true;

                foreach (string child in Graph[node])
                {
                    if (!visited.Contains(child))
                    {
                        visited.Add(child);
                        queue.Enqueue(child);
                    }
                }
            }

            return false;
        }

        private static Dictionary<string, List<string>> RegisterGraph(int nodes)
        {
            Dictionary<string, List<string>> graph = new Dictionary<string, List<string>>();

            for (int i = 0; i < nodes; i++)
            {
                string[] line = Console.ReadLine().Split(" -> ");

                string node = line[0];
                List<string> children = line[1].Split().ToList();

                graph[node] = children;

                foreach (string child in children)
                {
                    Edges.Add(new Edge(node, child));
                }
            }

            return graph;
        }
    }
}
