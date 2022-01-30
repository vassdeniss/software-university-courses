using System;
using System.Linq;

namespace E03.CustomMinFunction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Action<int> printNum = x => Console.WriteLine(x);

            Func<int[], int> min = x =>
            {
                int minValue = int.MaxValue;

                foreach (int n in x)
                {
                    if (n <= minValue)
                    {
                        minValue = n;
                    }
                }

                return minValue;
            };

            int[] nums = Console.ReadLine()
                .Split().Select(int.Parse).ToArray();

            printNum(min(nums));
        }
    }
}
