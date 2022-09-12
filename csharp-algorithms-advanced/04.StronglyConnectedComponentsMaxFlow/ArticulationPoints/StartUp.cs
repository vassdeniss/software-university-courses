using System;
using System.Collections.Generic;
using System.Linq;

namespace ArticulationPoints
{
    public class StartUp
    {
        private static List<int>[] graph;
        private static int[] depth;
        private static int[] lowpoint;
        private static int[] parent;
        private static bool[] visited;
        private static List<int> articulationPoints;

        public static void Main()
        {
            int nodesCount = int.Parse(Console.ReadLine());
            int linesCount = int.Parse(Console.ReadLine());

            graph = ReadGraph(nodesCount, linesCount);

            depth = new int[nodesCount];
            lowpoint = new int[nodesCount];
            parent = new int[nodesCount];
            visited = new bool[nodesCount];
            articulationPoints = new List<int>();

            Array.Fill(parent, -1);

            for (int node = 0; node < graph.Length; node++)
            {
                if (!visited[node])
                {
                    FindArticulationPoint(node, 1);
                }
            }

            Console.WriteLine($"Articulation points: {string.Join(", ", articulationPoints)}");
        }

        private static void FindArticulationPoint(int node, int currentDepth)
        {
            visited[node] = true;
            lowpoint[node] = currentDepth;
            depth[node] = currentDepth;

            int childCount = 0;
            bool isArticulationPoint = false;

            foreach (int child in graph[node])
            {
                if (!visited[child])
                {
                    parent[child] = node;
                    FindArticulationPoint(child, currentDepth + 1);
                    childCount++;

                    if (lowpoint[child] >= currentDepth)
                    {
                        isArticulationPoint = true;
                    }

                    lowpoint[node] = Math.Min(lowpoint[node], lowpoint[child]);
                }
                else if (parent[node] != child)
                {
                    lowpoint[node] = Math.Min(lowpoint[node], depth[child]);
                }
            }

            if ((parent[node] == -1 && childCount > 1)
                || (parent[node] != -1 && isArticulationPoint))
            {
                articulationPoints.Add(node);
            }
        }

        private static List<int>[] ReadGraph(int nodesCount, int linesCount)
        {
            List<int>[] result = new List<int>[nodesCount];

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = new List<int>();
            }

            for (int i = 0; i < linesCount; i++)
            {
                int[] data = Console.ReadLine()
                    .Split(", ")
                    .Select(int.Parse)
                    .ToArray();

                int node = data[0];
                for (int j = 1; j < data.Length; j++)
                {
                    int child = data[j];

                    result[node].Add(child);
                    result[child].Add(node);
                }
            }

            return result;
        }
    }
}
