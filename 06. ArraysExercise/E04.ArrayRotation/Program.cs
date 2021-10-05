using System;
using System.Linq;

namespace E04.ArrayRotation
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sourceArray = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rotations = int.Parse(Console.ReadLine());

            for (int i = 0; i < rotations; i++)
            {
                int[] destinationArray = new int[sourceArray.Length];
                Array.Copy(sourceArray, 1, destinationArray, 0, destinationArray.Length - 1);
                destinationArray[destinationArray.Length - 1] = sourceArray[0];
                sourceArray = destinationArray;
            }

            foreach (int i in sourceArray)
            {
                Console.Write($"{i} ");
            }
        }
    }
}
