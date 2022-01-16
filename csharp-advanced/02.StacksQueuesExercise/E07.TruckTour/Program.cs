using System;
using System.Collections.Generic;
using System.Linq;

namespace E07.TruckTour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Queue<int[]> petrolQueue = new Queue<int[]>();
            for (int i = 0; i < n; i++)
            {
                int[] input = Console.ReadLine()
                    .Split().Select(int.Parse).ToArray();
                petrolQueue.Enqueue(input);
            }

            int index = 0;
            while (true)
            {
                int currLiters = 0;
                bool workingPath = true;
                foreach (int[] petrol in petrolQueue)
                {
                    int liters = petrol[0];
                    int distance = petrol[1];

                    currLiters += liters;
                    if (currLiters - distance < 0)
                    {
                        index++;
                        petrolQueue.Enqueue(petrolQueue.Dequeue());
                        workingPath = false;
                        break;
                    }
                    currLiters -= distance;
                }

                if (workingPath)
                {
                    Console.WriteLine(index);
                    break;
                }
            }
        }
    }
}
