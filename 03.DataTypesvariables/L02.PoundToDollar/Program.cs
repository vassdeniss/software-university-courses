using System;

namespace L02.PoundToDollar
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal pound = decimal.Parse(Console.ReadLine());
            decimal dollar = pound * 1.31m;
            Console.WriteLine($"{dollar:f3}");
        }
    }
}
