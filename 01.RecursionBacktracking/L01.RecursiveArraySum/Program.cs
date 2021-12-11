using System;
using System.Linq;

namespace L01.RecursiveArraySum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Console.WriteLine(SumArr(input, 0));
        }

        static int SumArr(int[] arr, int i)
        {
            if (i == arr.Length) return 0;
            return arr[i] + SumArr(arr, i + 1);
        }
    }
}
