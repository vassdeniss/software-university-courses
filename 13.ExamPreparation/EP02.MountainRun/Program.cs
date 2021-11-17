using System;

namespace EP02.MountainRun {
    class Program {
        static void Main(string[] args) {
            double recordSeconds = double.Parse(Console.ReadLine());
            double distanceMeters = double.Parse(Console.ReadLine());
            double meterSecond = double.Parse(Console.ReadLine());

            double delay = Math.Floor(distanceMeters / 50) * 30;
            double totalTime = meterSecond * distanceMeters + delay;

            if (totalTime >= recordSeconds) {
                Console.WriteLine($"No! He was {(totalTime - recordSeconds):f2} seconds slower.");
            } else {
                Console.WriteLine($"Yes! The new record is {totalTime:f2} seconds.");
            }
        }
    }
}
