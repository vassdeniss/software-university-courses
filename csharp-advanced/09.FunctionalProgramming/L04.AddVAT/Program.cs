using System;
using System.Linq;

namespace L04.AddVAT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<string, double> doubleParser = x => double.Parse(x);
            Func<double, double> addVAT = x => x += x * 0.2;
            double[] nums = Console.ReadLine().Split(", ")
                .Select(doubleParser).Select(addVAT).ToArray();

            Print(nums, x => Console.WriteLine($"{x:f2}"));
        }

        private static void Print(double[] nums, Action<double> callback)
        {
            foreach (double n in nums)
            {
                callback(n);
            }
        }
    }
}
