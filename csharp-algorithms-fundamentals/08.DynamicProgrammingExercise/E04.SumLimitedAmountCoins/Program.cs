using System;
using System.Collections.Generic;
using System.Linq;

namespace E04.SumLimitedAmountCoins
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int target = int.Parse(Console.ReadLine());

            int total = GetSums(nums, target);
            Console.WriteLine(total);
        }

        private static int GetSums(int[] elements, int target)
        {
            int times = 0;
            HashSet<int> sums = new HashSet<int>() { 0 };

            foreach (int element in elements)
            {
                HashSet<int> newSums = new HashSet<int>();
                foreach (int sum in sums)
                {
                    int newSum = sum + element;
                    if (newSum == target) times++;
                    newSums.Add(newSum);
                }

                sums.UnionWith(newSums);
            }

            return times;
        }
    }
}
