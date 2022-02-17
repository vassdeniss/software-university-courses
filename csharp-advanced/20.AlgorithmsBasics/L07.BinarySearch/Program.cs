using System;
using System.Linq;

namespace L07.BinarySearch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int target = int.Parse(Console.ReadLine());

            Console.WriteLine(BinarySearch(numbers, target));
        }

        private static int BinarySearch(int[] arr, int target)
        {
            int left = 0, right = arr.Length - 1;

            while (left <= right)
            {
                int mid = (left + right) / 2;

                if (arr[mid] == target) return mid;
                if (arr[mid] < target) left = mid + 1;
                if (arr[mid] > target) right = mid - 1;
            }

            return -1;
        }
    }
}
