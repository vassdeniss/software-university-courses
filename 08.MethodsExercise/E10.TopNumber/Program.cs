using System;

namespace E10.TopNumber
{
    class Program
    {
        static bool isDivisible(int n)
        {
            int sum = 0;

            while (n > 0)
            {
                sum += n % 10;
                n /= 10;
            }

            return sum % 8 == 0;
        }

        static bool isOdd(int n)
        {
            while (n > 0)
            {
                int num = n % 10;

                if (num % 2 != 0) return true;

                n /= 10;
            }

            return false;
        }
        
        static void Main(string[] args)
        {
            int end = int.Parse(Console.ReadLine());

            for (int i = 1; i <= end; i++)
            {
                if (isDivisible(i) && isOdd(i))
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
