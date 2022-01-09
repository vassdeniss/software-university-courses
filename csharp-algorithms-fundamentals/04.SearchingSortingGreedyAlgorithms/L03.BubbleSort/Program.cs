using System;
using System.Linq;

namespace L03.BubbleSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            BubbleSort(nums);
            Console.WriteLine(string.Join(" ", nums));
        }

        private static void BubbleSort(int[] arr)
        {
            bool isSorted = false;
            int sorts = 0;

            while (!isSorted)
            {
                isSorted = true;
                for (int i = 1; i < arr.Length - sorts; i++)
                {
                    if (arr[i - 1] > arr[i])
                    {
                        Swap(arr, i - 1, i);
                        isSorted = false;
                    }
                }

                sorts++;
            }
        }

        private static void Swap(int[] arr, int one, int two) => (arr[one], arr[two]) = (arr[two], arr[one]);
    }
}
