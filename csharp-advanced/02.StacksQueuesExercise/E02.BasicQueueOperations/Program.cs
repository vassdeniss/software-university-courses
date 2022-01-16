using System;
using System.Collections.Generic;
using System.Linq;

namespace E02.BasicQueueOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int enqueue = input[0];
            int dequeue = input[1];
            int target = input[2];

            Console.WriteLine(ExistInQueue(enqueue, dequeue, target));
        }

        private static string ExistInQueue(int enqueue, int dequeue, int target)
        {
            int[] nums = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Queue<int> numStack = new Queue<int>(nums.Take(enqueue));
            for (int i = 0; i < dequeue; i++) numStack.Dequeue();

            if (numStack.Contains(target)) return "true";
            else if (numStack.Count == 0) return "0";
            else return numStack.Min().ToString();
        }
    }
}
