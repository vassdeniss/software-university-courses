using System;
using System.Collections.Generic;

namespace MaximumTasksAssignment
{
    public class StartUp
    {
        private static int[,] graph;
        private static int[] parents;

        public static void Main()
        {
            int people = int.Parse(Console.ReadLine());
            int tasks = int.Parse(Console.ReadLine());

            graph = ReadGraph(people, tasks);

            int nodes = graph.GetLength(0);

            parents = new int[nodes];
            Array.Fill(parents, -1);

            int start = 0;
            int end = nodes - 1;

            while (BFS(start, end))
            {
                int node = end;
                while (node != start)
                {
                    int parent = parents[node];

                    graph[parent, node] = 0;
                    graph[node, parent] = 1;

                    node = parent;
                }
            }

            for (int person = 1; person <= people; person++)
            {
                for (int task = people + 1; task <= people + tasks; task++)
                {
                    if (graph[task, person] > 0)
                    {
                        Console.WriteLine($"{(char)(64 + person)}-{task - people}");
                        break;
                    }
                }
            }
        }

        private static bool BFS(int start, int end)
        {
            Queue<int> queue = new Queue<int>();
            bool[] visited = new bool[graph.GetLength(0)];

            queue.Enqueue(start);
            visited[start] = true;

            while (queue.Count > 0)
            {
                int node = queue.Dequeue();

                if (node == end)
                {
                    return true;
                }

                for (int child = 0; child < graph.GetLength(1); child++)
                {
                    if (!visited[child] && graph[node, child] > 0)
                    {
                        visited[child] = true;
                        queue.Enqueue(child);
                        parents[child] = node;
                    }
                }
            }

            return visited[end];
        }

        private static int[,] ReadGraph(int people, int tasks)
        {
            int nodes = people + tasks + 2;

            int[,] result = new int[nodes, nodes];

            int start = 0;
            int end = nodes - 1;

            for (int person = 1; person <= people; person++)
            {
                result[start, person] = 1;
            }

            for (int task = people + 1; task <= people + tasks; task++)
            {
                result[task, end] = 1;
            }

            for (int person = 1; person <= people; person++)
            {
                string personTasks = Console.ReadLine();
                for (int task = 0; task < personTasks.Length; task++)
                {
                    if (personTasks[task] == 'Y')
                    {
                        result[person, people + 1 + task] = 1;
                    }
                }
            }

            return result;
        }
    }
}
