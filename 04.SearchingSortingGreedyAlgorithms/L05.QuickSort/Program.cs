using System;
using System.Linq;

namespace L05.QuickSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            QuickSort(nums, 0, nums.Length - 1);
            Console.WriteLine(string.Join(" ", nums));
        }

        private static void QuickSort(int[] arr, int start, int end)
        {
            if (start >= end) return;

            int pivot = start;
            int left = start + 1;
            int right = end;

            while (left <= right)
            {
                if (arr[left] > arr[pivot] && arr[right] < arr[pivot]) Swap(arr, left, right);
                if (arr[left] <= arr[pivot]) left++;
                if (arr[right] >= arr[pivot]) right--;
            }

            Swap(arr, pivot, right);

            bool isLeftArrSmaller = right - 1 - start < end - (right + 1);
            if (isLeftArrSmaller)
            {
                QuickSort(arr, start, right - 1);
                QuickSort(arr, right + 1, end);
            }
            else
            {
                QuickSort(arr, right + 1, end);
                QuickSort(arr, start, right - 1);
            }
        }

        private static void Swap(int[] arr, int one, int two) => (arr[one], arr[two]) = (arr[two], arr[one]);
    }
}
