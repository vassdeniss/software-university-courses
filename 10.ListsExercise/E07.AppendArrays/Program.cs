using System;
using System.Collections.Generic;
using System.Linq;

namespace E07.AppendArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine()
                .Split("|").Reverse().ToList();
            List<int> result = new List<int>();

            foreach (string s in input)
            {
                result.AddRange(s.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToList());
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
