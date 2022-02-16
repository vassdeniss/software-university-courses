using System;
using System.Collections.Generic;
using System.Linq;

namespace EP07.Scheduling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] tasksArray = Console.ReadLine()
                .Split(", ").Select(int.Parse).ToArray();
            int[] threadsArray = Console.ReadLine()
                .Split().Select(int.Parse).ToArray();
            int toKill = int.Parse(Console.ReadLine());

            Queue<int> threads = new Queue<int>(threadsArray);
            Stack<int> tasks = new Stack<int>(tasksArray);
            while (threads.Count > 0 && tasks.Count > 0)
            {
                int thread = threads.Peek();
                int task = tasks.Peek();

                if (task == toKill) break;

                if (thread >= task)
                {
                    threads.Dequeue();
                    tasks.Pop();
                }

                if (thread < task)
                {
                    threads.Dequeue();
                }
            }

            Console.WriteLine($"Thread with value {threads.Peek()} killed task {tasks.Peek()}");
            Console.WriteLine(string.Join(" ", threads));
        }
    }
}
