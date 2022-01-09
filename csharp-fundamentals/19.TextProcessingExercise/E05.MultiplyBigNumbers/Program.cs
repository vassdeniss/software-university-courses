using System;
using System.Text;

namespace E05.MultiplyBigNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int multiplier = int.Parse(Console.ReadLine());

            if (input == "0" || multiplier == 0)
            {
                Console.WriteLine(0);
                return;
            }

            int remainder = 0;
            StringBuilder sb = new StringBuilder();
            for (int i = input.Length - 1; i >= 0; i--)
            {
                int digit = int.Parse(input[i].ToString());
                int product = digit * multiplier + remainder;
                int result = product % 10;
                remainder = product / 10;
                sb.Insert(0, result);
            }

            if (remainder > 0) sb.Insert(0, remainder);
            Console.WriteLine(sb);
        }
    }
}
