using System;
using System.Collections.Generic;
using System.Linq;

namespace L02.TopologicalSorting
{
    internal class Program
    {
        private static Dictionary<string, List<string>> Graph;
        private static Dictionary<string, int> Dependencies; 

        static void Main(string[] args)
        {
            Graph = RegisterGraph(int.Parse(Console.ReadLine()));
            Dependencies = FindDependencies(Graph);
            List<string> sortedGraph = TopologicalSort(Dependencies);

            if (sortedGraph.Count != 0) Console.WriteLine($"Topological sorting: {string.Join(", ", sortedGraph)}");
        }

        private static Dictionary<string, List<string>> RegisterGraph(int n)
        {
            Dictionary<string, List<string>> graph = new Dictionary<string, List<string>>();
            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine()
                    .Split("->", StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => x.Trim())
                    .ToArray();

                string node = data[0];
                if (data.Length == 1)
                {
                    graph.Add(node, new List<string>());
                }
                else
                {
                    List<string> children = data[1].Split(", ").ToList();
                    graph.Add(node, children);
                }
            }

            return graph;
        }

        private static Dictionary<string, int> FindDependencies(Dictionary<string, List<string>> graph)
        {
            Dictionary<string, int> result = new Dictionary<string, int>();

            foreach (KeyValuePair<string, List<string>> kvp in graph)
            {
                string node = kvp.Key;
                List<string> children = kvp.Value;

                if (!result.ContainsKey(node)) result.Add(node, 0);
                foreach (string child in children)
                {
                    if (!result.ContainsKey(child)) result.Add(child, 1);
                    else result[child]++;
                }
            }

            return result;
        }

        private static List<string> TopologicalSort(Dictionary<string, int> dependencies)
        {
            List<string> sorted = new List<string>();
            while (dependencies.Count > 0)
            {
                string node = dependencies.FirstOrDefault(x => x.Value == 0).Key;
                if (node == null)
                {
                    Console.WriteLine("Invalid topological sorting");
                    return new List<string>();
                }

                sorted.Add(node);
                dependencies.Remove(node);

                foreach (string child in Graph[node]) dependencies[child]--;
            }

            return sorted;
        }
    }
}
