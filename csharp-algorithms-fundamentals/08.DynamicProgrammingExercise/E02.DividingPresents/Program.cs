using System;
using System.Collections.Generic;
using System.Linq;

namespace E02.DividingPresents
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] presents = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            Dictionary<int, int> allSums = GetSums(presents);

            int total = presents.Sum();
            int half = total / 2;

            while (true)
            {
                if (allSums.ContainsKey(half))
                {
                    int bobSum = total - half;
                    List<int> alanPresents = GetSubset(allSums, half);
                    Console.WriteLine($"Difference: {bobSum - half}");
                    Console.WriteLine($"Alan:{half} Bob:{bobSum}");
                    Console.WriteLine($"Alan takes: {string.Join(" ", alanPresents)}");
                    Console.WriteLine("Bob takes the rest.");
                    break;
                }

                half--;
            }
        }

        private static List<int> GetSubset(Dictionary<int, int> sums, int target)
        {
            List<int> subset = new List<int>();

            while (target != 0)
            {
                int element = sums[target];
                subset.Add(element);
                target -= element;
            }

            return subset;
        }

        private static Dictionary<int, int> GetSums(int[] elements)
        {
            Dictionary<int, int> sums = new Dictionary<int, int>() { { 0, 0 } };

            foreach (int element in elements)
            {
                int[] keys = sums.Keys.ToArray();
                foreach (int key in keys)
                {
                    int sum = element + key;
                    if (sums.ContainsKey(sum)) continue;
                    sums.Add(sum, element);
                }
            }

            return sums;
        }
    }
}
