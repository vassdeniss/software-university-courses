using System;
using System.Collections.Generic;
using System.Linq;

namespace EP03.TheStoryTelling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> graph = RegisterGraph();

            List<string> visited = new List<string>();
            Stack<string> topSort = new Stack<string>();

            foreach (string node in graph.Keys) TopSortDFS(node, graph, topSort, visited);

            Console.WriteLine(string.Join(" ", topSort));
        }

        private static void TopSortDFS(string node, Dictionary<string, List<string>> graph, Stack<string> sort, List<string> visited)
        {
            if (!visited.Contains(node))
            {
                visited.Add(node);
                foreach (string child in graph[node])
                    TopSortDFS(child, graph, sort, visited);
                sort.Push(node);
            }
        }

        private static Dictionary<string, List<string>> RegisterGraph()
        {
            Dictionary<string, List<string>> graph = new Dictionary<string, List<string>>();

            string input = Console.ReadLine();
            while (input != "End")
            {
                string[] data = input
                    .Split("->", StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => x.Trim())
                    .ToArray();

                string node = data[0];
                if (!graph.ContainsKey(node)) graph.Add(node, new List<string>());

                if (data.Length > 1)
                {
                    List<string> children = data[1]
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
                    foreach (string child in children) graph[node].Add(child);
                }

                input = Console.ReadLine();
            }

            return graph;
        }
    }
}
