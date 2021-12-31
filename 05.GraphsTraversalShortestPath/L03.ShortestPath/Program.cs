using System;
using System.Collections.Generic;
using System.Linq;

namespace L03.ShortestPath
{
    internal class Program
    {
        private static List<int>[] Graph;
        private static bool[] Visited;
        private static int[] Parent;

        static void Main(string[] args)
        {
            int nodes = int.Parse(Console.ReadLine());
            int edges = int.Parse(Console.ReadLine());

            Graph = RegisterGraph(nodes, edges);
            Visited = new bool[Graph.Length];
            Parent = new int[Graph.Length];

            Array.Fill(Parent, -1);

            int start = int.Parse(Console.ReadLine());
            int target = int.Parse(Console.ReadLine());

            BFS(start, target);
        }

        private static List<int>[] RegisterGraph(int n, int e)
        {
            List<int>[] graph = new List<int>[n + 1];

            for (int i = 0; i < graph.Length; i++) graph[i] = new List<int>();
            for (int i = 0; i < e; i++)
            {
                int[] edge = Console.ReadLine().Split().Select(int.Parse).ToArray();
                int firstNode = edge[0];
                int secondNode = edge[1];

                graph[firstNode].Add(secondNode);
                graph[secondNode].Add(firstNode);
            }

            return graph;
        }

        private static void BFS(int start, int target)
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(start);
            Visited[start] = true;

            while (queue.Count > 0)
            {
                int node = queue.Dequeue();
                
                if (node == target)
                {
                    Stack<int> path = GetPath(target);
                    Console.WriteLine($"Shortest path length is: {path.Count - 1}");
                    Console.WriteLine(string.Join(" ", path));
                    break;
                }

                foreach (int child in Graph[node])
                {
                    if (!Visited[child])
                    {
                        Parent[child] = node;
                        queue.Enqueue(child);
                        Visited[child] = true;
                    }
                }
            }
        }

        private static Stack<int> GetPath(int target)
        {
            Stack<int> path = new Stack<int>();

            int idx = target;
            while (idx != -1)
            {
                path.Push(idx);
                idx = Parent[idx];
            }

            return path;
        }
    }
}
