using System;
using System.Collections.Generic;

namespace E03.GraphCycles
{
    internal class Program
    {
        private static Dictionary<string, List<string>> Graph;
        private static HashSet<string> Visited;
        private static HashSet<string> Cycles;
        private static string Result;

        static void Main(string[] args)
        {
            Graph = RegisterGraph();
            Visited = new HashSet<string>();
            Cycles = new HashSet<string>();

            Result = "Acyclic: Yes";
            foreach (string node in Graph.Keys) DFS(node);
            Console.WriteLine(Result);
        }

        private static void DFS(string node)
        {
            if (Cycles.Contains(node))
            {
                Result = "Acyclic: No";
                return;
            }

            if (Visited.Contains(node)) return; 

            Visited.Add(node);
            Cycles.Add(node);

            foreach (string child in Graph[node]) DFS(child);

            Cycles.Remove(node);
        }

        private static Dictionary<string, List<string>> RegisterGraph()
        {
            Dictionary<string, List<string>> graph = new Dictionary<string, List<string>>();

            string input = Console.ReadLine();
            while (input != "End")
            {
                string[] data = input.Split('-');
                string from = data[0];
                string to = data[1];

                if (!graph.ContainsKey(from)) graph.Add(from, new List<string>());
                if (!graph.ContainsKey(to)) graph.Add(to, new List<string>());

                graph[from].Add(to);

                input = Console.ReadLine();
            }

            return graph;
        }
    }
}
