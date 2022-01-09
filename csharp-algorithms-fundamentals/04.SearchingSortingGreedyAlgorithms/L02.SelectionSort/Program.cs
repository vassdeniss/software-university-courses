using System;
using System.Linq;

namespace L02.SelectionSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            SelectionSort(nums);
            Console.WriteLine(string.Join(" ", nums));
        }

        private static void SelectionSort(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                int min = i;
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] < arr[min])
                    {
                        min = j;
                    }
                }

                Swap(arr, i, min);
            }
        }

        private static void Swap(int[] arr, int one, int two) => (arr[one], arr[two]) = (arr[two], arr[one]);
    }
}
