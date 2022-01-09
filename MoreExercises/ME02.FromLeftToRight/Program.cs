using System;
using System.Collections.Generic;

namespace ME02.FromLeftToRight
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            
            for (int i = 0; i < n; i++)
            {
                List<long> numbersList = new List<long>(Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse));

                long numberLeft = numbersList[0], numberRight = numbersList[1], sum = 0;

                numberRight = numberLeft >= numberRight ? numberLeft : numberRight;
                numberRight = Math.Abs(numberRight);

                while (numberRight > 0)
                {
                    sum += numberRight % 10;
                    numberRight /= 10;
                }

                Console.WriteLine(sum);
            }
        }
    }
}
