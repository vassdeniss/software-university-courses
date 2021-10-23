using System;
using System.Linq;
using System.Collections.Generic;

namespace L02.GaussTrick
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split().Select(int.Parse).ToList();

            int length = numbers.Count / 2;
            for (int i = 0; i < length; i++)
            {
                int first = i;
                int last = numbers.Count - 1;

                numbers[first] += numbers[last];
                numbers.RemoveAt(numbers.Count - 1);
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
