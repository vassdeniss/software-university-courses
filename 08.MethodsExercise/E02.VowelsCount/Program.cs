using System;

namespace E02.VowelsCount
{
    class Program
    {
        static void CountVowels(string s)
        {
            int total = 0;
            foreach (char c in s)
            {
                if ("aeiouAEIOU".Contains(c))
                {
                    total++;
                }
            }
            Console.WriteLine(total);
        }

        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            CountVowels(input);
        }
    }
}
