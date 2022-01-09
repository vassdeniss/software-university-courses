using System;
using System.Linq;

namespace ME04.FoldSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputArray = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int k = inputArray.Length / 4;
            int rowSize = k * 2;

            int[] firstKNumbers = new int[k];
            int[] lastKNumbers = new int[k];

            for (int i = 0; i < k; i++)
            {
                firstKNumbers[i] = inputArray[i];
            }

            Array.Reverse(firstKNumbers);

            int arrayPlacer = 0;
            int timesIterated = 0;
            for (int i = inputArray.Length - 1; i > 0; i--)
            {
                if (timesIterated >= k) { break; }

                lastKNumbers[arrayPlacer] = inputArray[i];

                arrayPlacer++;
                timesIterated++;
            }

            int[] topRow = firstKNumbers.Concat(lastKNumbers).ToArray();
            int[] bottomRow = new int[k * 2];

            Array.Copy(inputArray, k, bottomRow, 0, k * 2);

            for (int i = 0; i < topRow.Length; i++)
            {
                Console.Write($"{topRow[i] + bottomRow[i]} ");
            }
        }
    }
}
