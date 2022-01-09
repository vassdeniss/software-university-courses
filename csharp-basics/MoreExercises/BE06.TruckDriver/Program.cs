using System;

namespace BE06.TruckDriver {
    class Program {
        static void Main(string[] args) {
            string season = Console.ReadLine();
            double kilometers = double.Parse(Console.ReadLine());

            double total = 0.0;

            switch (season) {
                case "Spring":
                case "Autumn":
                    if (kilometers > 10000 && kilometers <= 20000) {
                        total += kilometers * 1.45 * 4;
                    } else if (kilometers > 5000 && kilometers <= 10000) {
                        total += kilometers * 0.95 * 4;
                    } else if (kilometers <= 5000) {
                        total += kilometers * 0.75 * 4;
                    }
                    break;
                case "Summer":
                    if (kilometers > 10000 && kilometers <= 20000) {
                        total += kilometers * 1.45 * 4;
                    } else if (kilometers > 5000 && kilometers <= 10000) {
                        total += kilometers * 1.10 * 4;
                    } else if (kilometers <= 5000) {
                        total += kilometers * 0.9 * 4;
                    }
                    break;
                case "Winter":
                    if (kilometers > 10000 && kilometers <= 20000) {
                        total += kilometers * 1.45 * 4;
                    } else if (kilometers > 5000 && kilometers <= 10000) {
                        total += kilometers * 1.25 * 4;
                    } else if (kilometers <= 5000) {
                        total += kilometers * 1.05 * 4;
                    }
                    break;
            }

            total *= 0.9;

            Console.WriteLine($"{total:f2}");
        }
    }
}
