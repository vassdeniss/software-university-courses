using System;
using System.Numerics;

namespace E11.Snowballs
{
    class Program
    {
        static void Main(string[] args)
        {
            int snowballQty = int.Parse(Console.ReadLine());

            BigInteger bestSnowballValue = 0, bestSnowballSnow = 0, bestSnowballTime = 0, bestSnowballQuality = 0;

            for (int i = 0; i < snowballQty; i++)
            {
                BigInteger snowballSnow = BigInteger.Parse(Console.ReadLine());
                BigInteger snowballTime = BigInteger.Parse(Console.ReadLine());
                int snowballQuality = int.Parse(Console.ReadLine());
                BigInteger snowballValue = BigInteger.Pow((snowballSnow / snowballTime), snowballQuality);

                if (snowballValue > bestSnowballValue)
                {
                    bestSnowballSnow = snowballSnow;
                    bestSnowballTime = snowballTime;
                    bestSnowballQuality = snowballQuality;
                    bestSnowballValue = snowballValue;
                }
            }

            Console.WriteLine($"{bestSnowballSnow} : {bestSnowballTime} = {bestSnowballValue} ({bestSnowballQuality})");
        }
    }
}
