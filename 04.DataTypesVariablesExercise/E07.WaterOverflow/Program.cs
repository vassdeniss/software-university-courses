using System;

namespace E07.WaterOverflow
{
    class Program
    {
        static void Main(string[] args)
        {
            int waterTankCapacity = 255;
            int n = int.Parse(Console.ReadLine());

            int totalLiters = 0;

            for (int i = 0; i < n; i++)
            {
                int pouredLiters = int.Parse(Console.ReadLine());
                if (pouredLiters > waterTankCapacity)
                {
                    Console.WriteLine("Insufficient capacity!");
                }
                else
                {
                    totalLiters += pouredLiters;
                    waterTankCapacity -= pouredLiters;
                }
            }

            Console.WriteLine(totalLiters);
        }
    }
}
