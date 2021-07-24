using System;

namespace E04.FishingBoat {
    class Program {
        static void Main(string[] args) {
            const double SPRING_BOAT_RENT = 3000;
            const double AUTUMN_SUMMER_BOAT_RENT = 4200;
            const double WINTER_BOAT_RENT = 2600;

            int budget = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            int peopleQuantity = int.Parse(Console.ReadLine());

            double total = 0.0;

            switch (season) {
                case "Spring":
                    total += SPRING_BOAT_RENT;
                    if (peopleQuantity >= 12) {
                        total *= 0.75;
                    } else if (peopleQuantity >= 7 && 
                                peopleQuantity <= 11) {
                        total *= 0.85;
                    } else if (peopleQuantity <= 6) {
                        total *= 0.9;
                    }
                    break;
                case "Summer":
                case "Autumn":
                    total += AUTUMN_SUMMER_BOAT_RENT;
                    if (peopleQuantity >= 12) {
                        total *= 0.75;
                    } else if (peopleQuantity >= 7 &&
                                peopleQuantity <= 11) {
                        total *= 0.85;
                    } else if (peopleQuantity <= 6) {
                        total *= 0.9;
                    }
                    break;
                case "Winter":
                    total += WINTER_BOAT_RENT;
                    if (peopleQuantity >= 12) {
                        total *= 0.75;
                    } else if (peopleQuantity >= 7 &&
                                peopleQuantity <= 11) {
                        total *= 0.85;
                    } else if (peopleQuantity <= 6) {
                        total *= 0.9;
                    }
                    break;
            }

            if (season != "Autumn" && peopleQuantity % 2 == 0) {
                total *= 0.95;
            }

            if (budget >= total) {
                Console.WriteLine($"Yes! You have {(budget - total):f2} leva left.");
            } else if (budget < total) {
                Console.WriteLine($"Not enough money! You need {(total - budget):f2} leva.");
            }
        }
    }
}
