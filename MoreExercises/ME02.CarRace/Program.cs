using System;
using System.Collections.Generic;
using System.Linq;

namespace ME02.CarRace
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> times = Console.ReadLine()
                .Split().Select(int.Parse).ToList();
            double racerOneTime = 0;
            double racerTwoTime = 0;

            int middleIndex = (times.Count - 1) / 2;
            for (int i = 0; i < middleIndex; i++)
            {
                if (times[i] == 0) racerOneTime *= 0.8;
                racerOneTime += times[i];
            }

            for (int i = times.Count - 1; i > middleIndex; i--)
            {
                if (times[i] == 0) racerTwoTime *= 0.8;
                racerTwoTime += times[i];
            }

            string winner = racerOneTime <= racerTwoTime ? "left" : "right";
            double winnerTime = racerOneTime <= racerTwoTime ? racerOneTime : racerTwoTime;
            Console.WriteLine($"The winner is {winner} with total time: {winnerTime:0.#####}");
        }
    }
}
