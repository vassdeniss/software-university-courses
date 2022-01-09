using System;
using System.Linq;

namespace L05.SumEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;
            int[] intArray = Console.ReadLine().Split().Select(int.Parse).ToArray();

            foreach (int i in intArray)
            {
                if (i % 2 == 0)
                {
                    sum += i;
                }
            }

            Console.WriteLine(sum);
        }
    }
}
