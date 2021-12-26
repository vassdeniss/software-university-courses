using System;
using System.Linq;

namespace L04.InsertionSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            InsertionSort(nums);
            Console.WriteLine(string.Join(" ", nums));
        }

        private static void InsertionSort(int[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                int j = i;
                while (j > 0 && arr[j - 1] > arr[j])
                {
                    Swap(arr, j, j - 1);
                    j--;
                }
            }
        }

        private static void Swap(int[] arr, int one, int two) => (arr[one], arr[two]) = (arr[two], arr[one]);
    }
}
