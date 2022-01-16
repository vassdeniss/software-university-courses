using System;
using System.Collections.Generic;
using System.Linq;

namespace E01.BasicStackOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int push = input[0];
            int pop = input[1];
            int target = input[2];

            Console.WriteLine(ExistInStack(push, pop, target));
        }

        private static string ExistInStack(int push, int pop, int target)
        {
            int[] nums = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Stack<int> numStack = new Stack<int>(nums.Take(push));
            for (int i = 0; i < pop; i++) numStack.Pop();

            if (numStack.Contains(target)) return "true";
            else if (numStack.Count == 0) return "0";
            else return numStack.Min().ToString();
        }
    }
}
