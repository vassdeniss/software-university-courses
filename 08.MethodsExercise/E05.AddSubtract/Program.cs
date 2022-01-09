using System;

namespace E05.AddSubtract
{
    class Program
    {
        static int Subtract(int a, int b)
        {
            return a - b;
        }

        static int AddSubtract(int a, int b, int c)
        {
            return Subtract(a + b, c);
        }

        static void Main(string[] args)
        {
            int firstSumNum = int.Parse(Console.ReadLine());
            int secondSumNum = int.Parse(Console.ReadLine());
            int subtractNum = int.Parse(Console.ReadLine());

            Console.WriteLine(AddSubtract(firstSumNum, secondSumNum, subtractNum));
        }
    }
}
