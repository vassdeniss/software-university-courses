using System;
using System.Linq;

namespace L03.RoundingNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] doubleArray = Console.ReadLine().Split().Select(double.Parse).ToArray();

            foreach (double i in doubleArray)
            {
                double iterator = i;
                if (iterator == -0) iterator = 0;
                int numberRounded = (int)Math.Round(iterator, MidpointRounding.AwayFromZero);
                Console.WriteLine($"{iterator} => {numberRounded}");
            }
        }
    }
}
