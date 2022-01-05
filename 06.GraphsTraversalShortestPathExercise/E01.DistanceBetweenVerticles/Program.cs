using System;
using System.Collections.Generic;
using System.Linq;

namespace E01.DistanceBetweenVerticles
{
    internal class Program
    {
        private static Dictionary<int, List<int>> Graph;
        private static Dictionary<int, bool> Visited;
        private static Dictionary<int, int> Parent;

        static void Main(string[] args)
        {
            int verticlesQty = int.Parse(Console.ReadLine()); 
            int pairsQty = int.Parse(Console.ReadLine());

            Graph = RegisterGraph(verticlesQty);
            for (int i = 0; i < pairsQty; i++)
            {
                Visited = RegisterVisitedList();
                Parent = RegisterParentsList();

                string[] data = Console.ReadLine().Split('-');
                int start = int.Parse(data[0]);
                int end = int.Parse(data[1]);
                BFS(start, end);
            }
        }

        private static Dictionary<int, List<int>> RegisterGraph(int n)
        {
            Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();

            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine().Split(':', StringSplitOptions.RemoveEmptyEntries);
                if (data.Length == 1)
                {
                    graph.Add(int.Parse(data[0]), new List<int>());
                    continue;
                }

                List<int> children = data[1].Split().Select(int.Parse).ToList();
                graph.Add(int.Parse(data[0]), children);
            }

            return graph;
        }

        private static Dictionary<int, bool> RegisterVisitedList()
        {
            Dictionary<int, bool> list = new Dictionary<int, bool>();
            foreach (int n in Graph.Keys) list.Add(n, false);
            return list;
        }

        private static Dictionary<int, int> RegisterParentsList()
        {
            Dictionary<int, int> list = new Dictionary<int, int>();
            foreach (int n in Graph.Keys) list.Add(n, -1);
            return list;
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
                    Console.WriteLine($"{{{start}, {target}}} -> {path.Count - 1}");
                    return;
                }

                foreach (int child in Graph[node])
                {
                    if (!Visited[child])
                    {
                        Visited[child] = true;
                        queue.Enqueue(child);
                        Parent[child] = node;
                    }
                }
            }

            Console.WriteLine($"{{{start}, {target}}} -> -1");
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
