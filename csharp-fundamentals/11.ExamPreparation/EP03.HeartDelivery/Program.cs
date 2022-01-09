using System;
using System.Collections.Generic;
using System.Linq;

namespace EP03.HeartDelivery
{
    class Program
    {
        static void CheckSuccess(List<int> list)
        {
            int failedHouses = 0;
            foreach (int n in list)
            {
                if (n > 0) failedHouses++;
            }

            if (failedHouses == 0)
                Console.WriteLine("Mission was successful.");
            else
                Console.WriteLine($"Cupid has failed {failedHouses} places.");
        }

        static void Main(string[] args)
        {
            List<int> neighbourhood = Console.ReadLine()
                .Split('@').Select(int.Parse).ToList();
            string[] cmd = Console.ReadLine().Split();

            int iterator = 0;
            while (cmd[0] != "Love!")
            {
                int jump = int.Parse(cmd[1]);
                iterator += jump;

                if (iterator >= neighbourhood.Count)
                    iterator = 0;
                if (neighbourhood[iterator] == - 1)
                    Console.WriteLine($"Place {iterator} already had Valentine's day.");
                if (neighbourhood[iterator] > 0)
                {
                    neighbourhood[iterator] -= 2;
                    if (neighbourhood[iterator] <= 0)
                    {
                        neighbourhood[iterator] = -1;
                        Console.WriteLine($"Place {iterator} has Valentine's day.");
                    }
                }

                cmd = Console.ReadLine().Split();
            }

            Console.WriteLine($"Cupid's last position was {iterator}.");
            CheckSuccess(neighbourhood);
        }
    }
}
