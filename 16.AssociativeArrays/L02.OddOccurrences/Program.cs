using System;
using System.Collections.Generic;
using System.Linq;

namespace L02.OddOccurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split().ToArray();

            Dictionary<string, int> oddWords = new Dictionary<string, int>();

            foreach (string word in input)
            {
                string wordLower = word.ToLower();

                if (oddWords.ContainsKey(wordLower))
                    oddWords[wordLower]++;
                else
                    oddWords.Add(wordLower, 1);
            }

            foreach (KeyValuePair<string, int> word in oddWords)
                if (word.Value % 2 != 0)
                    Console.Write($"{word.Key} ");
        }
    }
}
