using System;

namespace ME04.TribonacciSequence
{
    class Program
    {
        static void GetTribonacci(long num)
        {
            long minus3 = 1;
            long minus2 = 1;
            long minus1 = 2;
            long max = num;

            for (int i = 0; i < max - 3; i++)
            {
                num = minus3 + minus2 + minus1;
                minus3 = minus2;
                minus2 = minus1;
                minus1 = num;
                Console.Write($"{num} ");
            }
        }

        static void Main(string[] args)
        {

            long num = long.Parse(Console.ReadLine());

            if (num <= 0)
                Console.WriteLine(0);
            else if (num == 1)
                Console.Write(1);
            else if (num == 2)
                Console.Write("1 1");
            else if (num == 3)
                Console.Write("1 1 2");
            else
            {
                Console.Write("1 1 2 ");
                GetTribonacci(num);
            }
        }
    }
}
