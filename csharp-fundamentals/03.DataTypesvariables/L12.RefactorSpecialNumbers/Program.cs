using System;

namespace L12.RefactorSpecialNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            for (int i = 1; i <= num; i++)
            {
                int tempNum = i;
                int sum = 0;

                while (tempNum > 0)
                {
                    sum += tempNum % 10;
                    tempNum /= 10;
                }

                bool isSpecial = false;
                if (sum == 5 || sum == 7 || sum == 11) { isSpecial = true; }
                Console.WriteLine($"{i} -> {isSpecial}");
            }
        }
    }
}
