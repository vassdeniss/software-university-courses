using System;
using System.Linq;

namespace E06.ReverseExclude
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Action<int[]> reverse = x =>
            {
                int start = 0;
                int end = x.Length - 1;
                while (start < end)
                {
                    (x[start], x[end]) = (x[end], x[start]);
                    start++;
                    end--;
                }
            };

            Action<int[]> printReversed = x =>
            {
                reverse(x);
                Console.WriteLine(string.Join(" ", x));
            };

            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int n = int.Parse(Console.ReadLine());

            Func<int, bool> isDivisible = x => x % n != 0;
            nums = nums.Where(x => isDivisible(x)).ToArray();
            printReversed(nums);
        }
    }
}
