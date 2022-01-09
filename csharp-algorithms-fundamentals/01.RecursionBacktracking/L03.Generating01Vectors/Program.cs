using System;

namespace L03.Generating01Vectors
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];
            GenVectors(arr, 0);
        }

        private static void GenVectors(int[] arr, int ind)
        {
            if (ind >= arr.Length)
            {
                Console.WriteLine(string.Join(string.Empty, arr));
                return;
            }

            for (int i = 0; i < 2; i++)
            {
                arr[ind] = i;
                GenVectors(arr, ind + 1);
            }
        }
    }
}
