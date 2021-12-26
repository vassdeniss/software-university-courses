using System;
using System.Linq;

namespace L01.BinarySearch
{
    internal class Program
    {
        private static int Target;

        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Target = int.Parse(Console.ReadLine());

            Console.WriteLine(BinarySearch(numbers, 0, numbers.Length - 1));
        }

        // Recursive solution
        private static int BinarySearch(int[] arr, int left, int right)
        {
            if (left > right) return -1;

            int mid = (left + right) / 2;
            if (arr[mid] == Target) return mid;
            if (arr[mid] < Target) left = mid + 1;
            if (arr[mid] > Target) right = mid - 1;

            return BinarySearch(arr, left, right);
        }
        
        // Iterative solution
        private static int BinarySearch(int[] arr)
        {
            int left = 0, right = arr.Length - 1;

            while (left <= right)
            {
                int mid = (left + right) / 2;

                if (arr[mid] == Target) return mid;
                if (arr[mid] < Target) left = mid + 1;
                if (arr[mid] > Target) right = mid - 1;
            }

            return -1;
        }
    }
}
