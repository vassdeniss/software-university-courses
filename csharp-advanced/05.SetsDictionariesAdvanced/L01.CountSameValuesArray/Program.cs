using System;
using System.Collections.Generic;
using System.Linq;

namespace L01.CountSameValuesArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] nums = Console.ReadLine()
                .Split().Select(double.Parse).ToArray();

            Dictionary<double, int> counter = new Dictionary<double, int>();
            foreach(double d in nums)
            {
                if (counter.ContainsKey(d)) counter[d]++;
                else counter.Add(d, 1);
            }

            foreach (KeyValuePair<double, int> kvp in counter)
                Console.WriteLine($"{kvp.Key} - {kvp.Value} times");
        }
    }
}
