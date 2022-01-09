using System;

namespace BE06.Bills {
    class Program {
        static void Main(string[] args) {
            const double WATER_RATE = 20;
            const double INTERNET_RATE = 15;
            double powerTotal = 0;

            int months = int.Parse(Console.ReadLine());
            double other = 0;

            for (int i = 0; i < months; i++) {
                double powerRate = double.Parse(Console.ReadLine());
                powerTotal += powerRate;
                other += (powerRate + WATER_RATE + INTERNET_RATE) * 1.2;
            }

            double waterTotal = WATER_RATE * months;
            double internetTotal = INTERNET_RATE * months;
            double average = (powerTotal + waterTotal + 
                internetTotal + other) / months;

            Console.WriteLine($"Electricity: {powerTotal:f2} lv");
            Console.WriteLine($"Water: {waterTotal:f2} lv");
            Console.WriteLine($"Internet: {internetTotal:f2} lv");
            Console.WriteLine($"Other: {other:f2} lv");
            Console.WriteLine($"Average: {average:f2} lv");
        }
    }
}
