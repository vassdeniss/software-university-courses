using System;

namespace E02.Division
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            bool divisibleByTwo = number % 2 == 0;
            bool divisibleByThree = number % 3 == 0;
            bool divisibleBySix = number % 6 == 0;
            bool divisibleBySeven = number % 7 == 0;
            bool divisibleByTen = number % 10 == 0;

            if (divisibleByTen)
            {
                Console.WriteLine("The number is divisible by 10");
            }
            else if (divisibleBySeven)
            {
                Console.WriteLine("The number is divisible by 7");

            }
            else if (divisibleBySix)
            {
                Console.WriteLine("The number is divisible by 6");

            }
            else if (divisibleByThree)
            {
                Console.WriteLine("The number is divisible by 3");

            }
            else if (divisibleByTwo)
            {
                Console.WriteLine("The number is divisible by 2");

            }
            else
            {
                Console.WriteLine("Not divisible");
            }
        }
    }
}
