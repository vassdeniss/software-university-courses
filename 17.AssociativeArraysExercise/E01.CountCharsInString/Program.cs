using System;
using System.Collections.Generic;
using System.Linq;

namespace E01.CountCharsInString
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine().Split().ToList();
            Dictionary<char, int> charCount = new Dictionary<char, int>();

            foreach (string s in input)
            {
                foreach (char c in s)
                {
                    if (charCount.ContainsKey(c))
                        charCount[c]++;
                    else
                        charCount.Add(c, 1);
                }
            }

            foreach (KeyValuePair<char, int> pair in charCount)
                Console.WriteLine($"{pair.Key} -> {pair.Value}");
        }
    }
}
