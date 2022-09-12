using System;
using System.Collections.Generic;
using System.Linq;

namespace FindBiConnectedComponents
{
    public class StartUp
    {
        private static List<int>[] graph;
        private static int[] depth;
        private static int[] lowpoint;
        private static int[] parent;
        private static bool[] visited;

        private static Stack<int> stack;
        private static List<HashSet<int>> components;

        public static void Main()
        {
            int nodesCount = int.Parse(Console.ReadLine());
            int edgesCount = int.Parse(Console.ReadLine());

            graph = ReadGraph(nodesCount, edgesCount);

            depth = new int[nodesCount];
            lowpoint = new int[nodesCount];
            visited = new bool[nodesCount];

            parent = new int[nodesCount];
            Array.Fill(parent, -1);

            stack = new Stack<int>();
            components = new List<HashSet<int>>();

            for (int node = 0; node < graph.Length; node++)
            {
                if (!visited[node])
                {
                    FindArticulationPoint(node, 1);

                    HashSet<int> component = new HashSet<int>();

                    while (stack.Count > 1)
                    {
                        int stackChild = stack.Pop();
                        int stackNode = stack.Pop();

                        component.Add(stackNode);
                        component.Add(stackChild);
                    }

                    components.Add(component);
                }
            }

            Console.WriteLine($"Number of bi-connected components: {components.Count}");
        }

        private static void FindArticulationPoint(int node, int currentDepth)
        {
            visited[node] = true;
            lowpoint[node] = currentDepth;
            depth[node] = currentDepth;

            int childCount = 0;
            foreach (int child in graph[node])
            {
                if (!visited[child])
                {
                    stack.Push(node);
                    stack.Push(child);

                    parent[child] = node;
                    FindArticulationPoint(child, currentDepth + 1);
                    childCount++;

                    if ((parent[node] == -1 && childCount > 1)
                        || (parent[node] != -1 && lowpoint[child] >= currentDepth))
                    {
                        HashSet<int> component = new HashSet<int>();

                        while (true)
                        {
                            int stackChild = stack.Pop();
                            int stackNode = stack.Pop();

                            component.Add(stackNode);
                            component.Add(stackChild);

                            if (stackNode == node
                                && stackChild == child)
                            {
                                break;
                            }
                        }

                        components.Add(component);
                    }

                    lowpoint[node] = Math.Min(lowpoint[node], lowpoint[child]);
                }
                else if (parent[node] != child 
                         && depth[child] < lowpoint[node])
                {
                    lowpoint[node] = depth[child];

                    stack.Push(node);
                    stack.Push(child);
                }
            }
        }

        private static List<int>[] ReadGraph(int nodesCount, int edgesCount)
        {
            List<int>[] result = new List<int>[nodesCount];

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = new List<int>();
            }

            for (int i = 0; i < edgesCount; i++)
            {
                int[] data = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                int first = data[0];
                int second = data[1];

                result[first].Add(second);
                result[second].Add(first);
            }

            return result;
        }
    }
}
