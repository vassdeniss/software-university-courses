using System;

namespace ME04.ReverseString
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            char[] reversal = input.ToCharArray();
            Array.Reverse(reversal);

            Console.WriteLine(reversal);
        }
    }
}
