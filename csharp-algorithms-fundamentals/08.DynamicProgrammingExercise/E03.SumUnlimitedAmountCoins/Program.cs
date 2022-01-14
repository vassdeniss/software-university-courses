using System;
using System.Linq;

namespace E03.SumUnlimitedAmountCoins
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int target = int.Parse(Console.ReadLine());

            Console.WriteLine(Sums(nums, target));
        }

        private static int Sums(int[] nums, int target)
        {
            int[] sums = new int[target + 1];
            sums[0] = 1;

            foreach (int num in nums)
            {
                for (int i = num; i <= target; i++)
                {
                    sums[i] += sums[i - num];
                }
            }

            return sums[target];
        }
    }
}
