using System;
using System.Collections.Generic;

namespace E02.AMinerTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> resourceDictionary = new Dictionary<string, int>();
            string input = Console.ReadLine();

            int count = 1;
            string oldInput = string.Empty;
            while (input != "stop")
            {   
                if (count % 2 == 0)
                {
                    int value = int.Parse(input);
                    resourceDictionary[oldInput] += value;
                }
                else
                {
                    if (!resourceDictionary.ContainsKey(input))
                    {
                        resourceDictionary.Add(input, 0);
                    }
                }

                count++;
                oldInput = input;
                input = Console.ReadLine();
            }

            foreach (KeyValuePair<string, int> pair in resourceDictionary)
            {
                Console.WriteLine($"{pair.Key} -> {pair.Value}");
            }
        }
    }
}
