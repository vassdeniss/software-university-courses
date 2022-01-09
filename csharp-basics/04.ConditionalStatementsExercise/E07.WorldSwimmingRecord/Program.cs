using System;

namespace E07.WorldSwimmingRecord {
    class Program {
        static void Main(string[] args) {
            const double SECONDS_LOST_PER_METER = 12.5;
            double currentRecord = double.Parse(Console.ReadLine()); 
            double distance = double.Parse(Console.ReadLine());
            double timeMeter = double.Parse(Console.ReadLine());

            double timesSlowed = Math.Floor(distance / 15);
            double secondsWasted = timesSlowed * SECONDS_LOST_PER_METER;
            double timeTaken = (distance * timeMeter) + secondsWasted;

            if (timeTaken < currentRecord) {
                Console.WriteLine($"Yes, he succeeded! The new world record is {timeTaken:f2} seconds.");
            } else {
                Console.WriteLine($"No, he failed! He was {timeTaken - currentRecord:f2} seconds slower.");
            }
        }
    }
}
