using System;
using System.Linq;

namespace L06.Quicksort
{
    class FisherYatesShuffle
    {
        private static Random random = new Random();

        public static void Shuffle(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < (n - 1); i++)
            {
                int r = i + random.Next(n - i);
                int t = arr[r];
                arr[r] = arr[i];
                arr[i] = t;
            }
        }
    }

    class QSort
    {
        public static int GetMedian(int[] arr, int left, int right)
        {
            int center = (left + right) / 2;

            if (arr[left] > arr[center])
                Swap(arr, left, center);

            if (arr[left] > arr[right])
                Swap(arr, left, right);

            if (arr[center] > arr[right])
                Swap(arr, center, right);

            Swap(arr, center, right - 1);
            return arr[right - 1];
        }

        private static int Partition(int[] arr, int left, int right, int pivot)
        {
            int leftPtr = left;
            int rightPtr = right - 1;

            while (true)
            {
                while (arr[++leftPtr] < pivot);
                while (arr[--rightPtr] > pivot);

                if (leftPtr >= rightPtr) break;
                else Swap(arr, leftPtr, rightPtr);
            }

            Swap(arr, leftPtr, right - 1);
            return leftPtr;
        }

        private static void Swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }

        private static void Sort(int[] arr, int low, int high)
        {
            int size = high - low + 1;
            if (size <= 3)
            {
                ManualSort(arr, low, high);
            }
            else
            {
                int median = GetMedian(arr, low, high);
                int partition = Partition(arr, low, high, median);
                Sort(arr, low, partition - 1);
                Sort(arr, partition + 1, high);
            }
        }

        public static void ManualSort(int[] arr, int left, int right)
        {
            int size = right - left + 1;
            if (size <= 1) return;

            if (size == 2)
            {
                if (arr[left] > arr[right]) Swap(arr, left, right);
                return;
            }

            if (arr[left] > arr[right - 1]) Swap(arr, left, right - 1);
            if (arr[left] > arr[right]) Swap(arr, left, right);
            if (arr[right - 1] > arr[right]) Swap(arr, right - 1, right);
        }
        
        public static void Sort(int[] arr)
        {
            FisherYatesShuffle.Shuffle(arr);
            Sort(arr, 0, arr.Length - 1);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();

            QSort.Sort(nums);
            Console.WriteLine(string.Join(" ", nums));
        }
    }
}
