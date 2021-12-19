using System;

namespace E01.ReverseArray
{
    internal class Program
    {
        static string[] reversed;

        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            reversed = new string[input.Length];
            Reverse(input, 0, reversed.Length - 1);
            Console.WriteLine(string.Join(" ", reversed));
        }

        private static void Reverse(string[] arr, int ind, int place)
        {
            if (ind >= arr.Length) return;
            Reverse(arr, ind + 1, place - 1);
            reversed[place] = arr[ind];
        }
    }
}
