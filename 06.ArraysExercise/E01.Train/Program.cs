using System;

namespace E01.Train
{
    class Program
    {
        static void Main(string[] args)
        {
            int wagonQty = int.Parse(Console.ReadLine());

            int[] peoplePerWagon = new int[wagonQty];
            int sum = 0;

            for (int i = 0; i < peoplePerWagon.Length; i++)
            {
                int peopleQty = int.Parse(Console.ReadLine());
                sum += peopleQty;
                peoplePerWagon[i] = peopleQty;
            }

            foreach (int i in peoplePerWagon)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine($"\n{sum}");
        }
    }
}
