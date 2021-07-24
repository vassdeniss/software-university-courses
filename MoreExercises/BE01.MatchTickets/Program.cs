using System;

namespace BE01.MatchTickets {
    class Program {
        static void Main(string[] args) {
            const double VIP_PRICE = 499.99;
            const double NORMAL_PRICE = 249.99;

            double budget = double.Parse(Console.ReadLine());
            string category = Console.ReadLine();
            int peopleQuantity = int.Parse(Console.ReadLine());

            double total = 0.0;

            if (peopleQuantity >= 50) {
                budget *= 0.75;
            } else if (peopleQuantity <= 49 && peopleQuantity >= 25) {
                budget *= 0.6;
            } else if (peopleQuantity <= 24 && peopleQuantity >= 10) {
                budget *= 0.5;
            } else if (peopleQuantity <= 9 && peopleQuantity >= 5) {
                budget *= 0.4;
            } else if (peopleQuantity <= 4 && peopleQuantity >= 1) {
                budget *= 0.25;
            }

            total = category == "VIP"
                ? total += peopleQuantity * VIP_PRICE
                : total += peopleQuantity * NORMAL_PRICE;

            if (budget >= total) {
                Console.WriteLine($"Yes! You have {(budget - total):f2} leva left.");
            } else if (budget < total) {
                Console.WriteLine($"Not enough money! You need {(total - budget):f2} leva.");
            }

        }
    }
}
