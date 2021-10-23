using System;
using System.Linq;

namespace L08.CondenseArrayToNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] intArray = Console.ReadLine().Split().Select(int.Parse).ToArray();

            while (intArray.Length > 1)
            {
                int[] intArrayCondensed = new int[intArray.Length - 1];

                for (int i = 0; i < intArray.Length - 1; i++)
                {
                    intArrayCondensed[i] = intArray[i] + intArray[i + 1];
                }

                intArray = intArrayCondensed;
            }

            Console.WriteLine(intArray[0]);
        }
    }
}
