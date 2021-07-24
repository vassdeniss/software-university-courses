using System;

namespace BE05.Vacation {
    class Program {
        static void Main(string[] args) {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            
            string accommodationType = "";
            string location = "";
            double totalPrice = 0.0;

            if (budget > 3000) {
                accommodationType = "Hotel";
                totalPrice = budget * 0.9;
                location = season == "Summer" ? "Alaska" : "Morocco";
            } else if (budget > 1000 && budget <= 3000) {
                accommodationType = "Hut";
                if (season == "Summer") {
                    location = "Alaska";
                    totalPrice = budget * 0.8;
                } else if (season == "Winter") {
                    location = "Morocco";
                    totalPrice = budget * 0.6;
                }
            } else if (budget <= 1000) {
                accommodationType = "Camp";
                if (season == "Summer") {
                    location = "Alaska";
                    totalPrice = budget * 0.65;
                } else if (season == "Winter") {
                    location = "Morocco";
                    totalPrice = budget * 0.45;
                }
            }

            Console.WriteLine($"{location} - {accommodationType} - {totalPrice:f2}");
        }
    }
}
