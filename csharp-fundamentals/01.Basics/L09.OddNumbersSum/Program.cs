using System;

namespace L09.OddNumbersSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());

            int odd = 1;
            int oddSum = 0;

            for (int i = 0; i < input; i++)
            {
                Console.WriteLine(odd);
                oddSum += odd;
                odd += 2;
            }

            Console.WriteLine($"Sum: {oddSum}");
        }
    }
}
