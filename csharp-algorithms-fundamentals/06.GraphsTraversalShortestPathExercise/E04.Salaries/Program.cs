using System;
using System.Collections.Generic;

namespace E04.Salaries
{
    internal class Program
    {
        private static List<List<int>> Graph;
        private static Dictionary<int, int> Visited;

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Graph = RegisterGraph(n);
            Visited = new Dictionary<int, int>();

            int salary = 0;
            for (int i = 0; i < Graph.Count; i++) salary += DFS(i);

            Console.WriteLine(salary);
        }

        private static int DFS(int node)
        {
            if (Visited.ContainsKey(node)) return Visited[node];

            Visited.Add(node, 1);

            if (Graph[node].Count == 0) return 1;

            int salary = 0;
            if (Graph[node].Count == 0)
            {
                salary = 1;
            }
            else
            {
                foreach (int child in Graph[node])
                {
                    salary += DFS(child);
                }
            }

            Visited[node] = salary;
            return salary;
        }

        private static List<List<int>> RegisterGraph(int n)
        {
            List<List<int>> graph = new List<List<int>>();

            for (int i = 0; i < n; i++)
            {
                graph.Add(new List<int>());
                string line = Console.ReadLine();
                for (int j = 0; j < line.Length; j++)
                {
                    if (line[j] == 'Y')
                    {
                        graph[i].Add(j);
                    }
                }
            }

            return graph;
        }
    }
}
