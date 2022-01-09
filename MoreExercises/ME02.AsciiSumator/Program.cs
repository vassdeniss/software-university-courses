using System;

namespace ME02.AsciiSumator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char symbolOne = char.Parse(Console.ReadLine());
            char symbolTwo = char.Parse(Console.ReadLine());
            string input = Console.ReadLine();

            Console.WriteLine(CharSum(input, symbolOne, symbolTwo));
        }

        static int CharSum(string s, char cr, char cr1)
        {
            int sum = 0;
            foreach (char c in s)
            {
                if (c > cr && c < cr1) sum += c;
            }
            return sum;
        }
    }
}
