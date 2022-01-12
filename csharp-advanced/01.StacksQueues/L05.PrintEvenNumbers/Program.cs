using System;
using System.Collections.Generic;
using System.Linq;

namespace L05.PrintEvenNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Queue<int> numsQueue = new Queue<int>(nums);
            List<int> numsList = new List<int>();

            while (numsQueue.Count > 0)
            {
                int curr = numsQueue.Dequeue();
                if (curr % 2 == 1) continue;
                numsList.Add(curr);
            }

            Console.WriteLine(string.Join(", ", numsList));
        }
    }
}
