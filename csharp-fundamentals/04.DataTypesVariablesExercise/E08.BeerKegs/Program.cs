using System;

namespace E08.BeerKegs
{
    class Program
    {
        static void Main(string[] args)
        {
            int kegSets = int.Parse(Console.ReadLine());

            double tempKeg = 0.0;
            string biggestKeg = String.Empty;

            for (int i = 0; i < kegSets; i++)
            {
                string model = Console.ReadLine();
                double radius = double.Parse(Console.ReadLine());
                int height = int.Parse(Console.ReadLine());

                double currentBiggestKeg = Math.PI * Math.Pow(radius, 2) * height;

                if (currentBiggestKeg > tempKeg)
                {
                    tempKeg = currentBiggestKeg;
                    biggestKeg = model;
                }
            }

            Console.WriteLine(biggestKeg);
        }
    }
}
