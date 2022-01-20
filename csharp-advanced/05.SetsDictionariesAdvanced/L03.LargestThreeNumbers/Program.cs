using System;
using System.Linq;

namespace L03.LargestThreeNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] sortedNums = Console.ReadLine()
                .Split().Select(int.Parse)
                .OrderByDescending(x => x).ToArray();
            for (int i = 0; i < 3; i++)
            {
                try
                {
                    Console.Write($"{sortedNums[i]} ");

                }
                catch (Exception)
                {
                    break;
                }
            }
        }
    }
}
