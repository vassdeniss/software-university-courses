using System;
using System.Collections.Generic;
using System.Linq;

namespace L01.CountRealNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split()
                .Select(int.Parse).ToArray();

            SortedDictionary<int, int> count = new SortedDictionary<int, int>();

            foreach (int num in nums)
            {
                if (count.ContainsKey(num)) count[num]++;
                else count.Add(num, 1);
            }

            foreach (KeyValuePair<int, int> pair in count)
            {
                Console.WriteLine($"{pair.Key} -> {pair.Value}");
            }
        }
    }
}
