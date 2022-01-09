using System;

namespace L10.MultiplyEvenOdd
{
    class Program
    {
        static int GetSumEven(int n)
        {
            int sum = 0;
            int nAbs = Math.Abs(n);

            while (nAbs > 0)
            {
                int num = nAbs % 10;
                nAbs /= 10;
                if (num % 2 != 0) { continue; }
                sum += num;
            }

            return sum;
        }

        static int GetSumOdd(int n)
        {
            int sum = 0;
            int nAbs = Math.Abs(n);

            while (nAbs > 0)
            {
                int num = nAbs % 10;
                nAbs /= 10;
                if (num % 2 == 0) { continue; }
                sum += num;
            }

            return sum;
        }

        static int GetMultiple(int n)
        {
            return GetSumEven(n) * GetSumOdd(n);
        }

        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            Console.WriteLine(GetMultiple(input));
        }
    }
}
