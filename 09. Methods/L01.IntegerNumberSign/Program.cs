using System;

namespace L01.IntegerNumberSign
{
    class Program
    {
        static string CheckSign(int n)
        {
            if (n > 0)
            {
                return "positive";
            }
            else if (n < 0)
            {
                return "negative";
            }
            else
            {
                return "zero";
            }
        }

        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            string result = CheckSign(num);
            Console.WriteLine($"The number {num} is {result}.");
        }
    }
}
