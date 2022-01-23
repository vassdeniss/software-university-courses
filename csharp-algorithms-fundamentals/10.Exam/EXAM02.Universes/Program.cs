using System;
using System.Collections.Generic;

namespace EXAM02.Universes
{
    class Graph
    {
        private int _n;
        private int _total;
        List<int>[] adjListArray;

        public Graph(int nodes)
        {
            _n = nodes;
            _total = 0;

            adjListArray = new List<int>[nodes];
            for (int i = 0; i < nodes; i++)
                adjListArray[i] = new List<int>();
        }

        public void AddEdge(int src, int dest)
        {
            adjListArray[src].Add(dest);
            adjListArray[dest].Add(src);
        }

        void DFS(int node, bool[] visited)
        {
            visited[node] = true;

            foreach (int child in adjListArray[node])
            {
                if (!visited[child]) DFS(child, visited);
            }

        }

        public void ConnectedComponents()
        {
            bool[] visited = new bool[_n];

            for (int v = 0; v < _n; ++v)
            {
                if (!visited[v])
                {
                    _total++;
                    DFS(v, visited);
                }
            }
        }

        public override string ToString()
        {
            return _total.ToString();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Queue<string> inputs = new Queue<string>();

            Dictionary<string, int> map = new Dictionary<string, int>();
            int idx = 0;
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                inputs.Enqueue(input);

                string[] data = input.Split(" - ");
                string node = data[0];
                string child = data[1];

                if (!map.ContainsKey(node)) map.Add(node, idx++);
                if (!map.ContainsKey(child)) map.Add(child, idx++);
            }

            Graph graph = new Graph(map.Count);
            for (int i = 0; i < n; i++)
            {
                string[] data = inputs.Dequeue().Split(" - ");
                string node = data[0];
                string child = data[1];
                
                graph.AddEdge(map[node], map[child]);
            }

            graph.ConnectedComponents();
            Console.WriteLine(graph);
        }
    }
}
