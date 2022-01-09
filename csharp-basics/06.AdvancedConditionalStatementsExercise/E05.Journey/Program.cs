using System;

namespace E05.Journey {
    class Program {
        static void Main(string[] args) {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();

            string location = "";
            string restPlace = "";
            double moneySpent = 0.0;

            if (budget <= 100) {
                location = "Bulgaria";
                if (season == "summer") {
                    moneySpent = budget * 0.3;
                    restPlace = "Camp"; 
                } else if (season == "winter") {
                    moneySpent = budget * 0.7;
                    restPlace = "Hotel";
                }
            } else if (budget <= 1000) {
                location = "Balkans";
                if (season == "summer") {
                    moneySpent = budget * 0.4;
                    restPlace = "Camp";
                } else if (season == "winter") {
                    moneySpent = budget * 0.8;
                    restPlace = "Hotel";
                }
            } else if (budget > 1000) {
                location = "Europe";
                moneySpent = budget * 0.9;
                restPlace = "Hotel";
            }

            Console.WriteLine($"Somewhere in {location}");
            Console.WriteLine($"{restPlace} - {moneySpent:f2}");
        }
    }
}
