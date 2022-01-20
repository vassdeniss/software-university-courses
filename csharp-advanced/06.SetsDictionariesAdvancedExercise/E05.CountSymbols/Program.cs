using System;
using System.Collections.Generic;

namespace E05.CountSymbols
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<char, int> seen = new SortedDictionary<char, int>();

            string input = Console.ReadLine();
            foreach (char c in input)
            {
                if (!seen.ContainsKey(c)) seen.Add(c, 0);
                seen[c]++;
            }

            foreach (KeyValuePair<char, int> kvp in seen)
                Console.WriteLine($"{kvp.Key}: {kvp.Value} time/s");
        }
    }
}
