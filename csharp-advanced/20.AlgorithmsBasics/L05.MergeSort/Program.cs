using System;
using System.Linq;

namespace L05.MergeSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Console.WriteLine(string.Join(" ", MergeSort(nums)));
        }

        private static int[] MergeSort(int[] arr)
        {
            if (arr.Length <= 1) return arr;

            int mid = arr.Length / 2;
            int[] left = arr.Take(mid).ToArray();
            int[] right = arr.Skip(mid).ToArray();

            return Merge(MergeSort(left), MergeSort(right));
        }

        private static int[] Merge(int[] left, int[] right)
        {
            int[] merged = new int[left.Length + right.Length];

            int mergedIdx = 0, leftIdx = 0, rightIdx = 0;
            while (leftIdx < left.Length && rightIdx < right.Length)
            {
                if (left[leftIdx] < right[rightIdx]) merged[mergedIdx++] = left[leftIdx++];
                else merged[mergedIdx++] = right[rightIdx++];
            }

            for (int i = leftIdx; i < left.Length; i++) merged[mergedIdx++] = left[i];
            for (int i = rightIdx; i < right.Length; i++) merged[mergedIdx++] = right[i];

            return merged;
        }
    }
}
