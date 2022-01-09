using System;

namespace E02.NestedLoops
{
    internal class Program
    {
        static int[] loopArray;

        static void Main(string[] args)
        {
            int loops = int.Parse(Console.ReadLine());
            loopArray = new int[loops];
            PrintLoops(loopArray, 0);
        }

        private static void PrintLoops(int[] arr, int ind)
        {
            if (ind >= arr.Length)
            {
                Console.WriteLine(string.Join(" ", arr));
                return;
            }

            for (int i = 1; i <= arr.Length; i++)
            {
                arr[ind] = i;
                PrintLoops(arr, ind + 1);
            }
        }
    }
}
