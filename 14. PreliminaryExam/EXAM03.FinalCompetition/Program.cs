using System;

namespace EXAM03.FinalCompetition {
    class Program {
        static void Main(string[] args) {
            int dancersQty = int.Parse(Console.ReadLine());
            double points = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            string location = Console.ReadLine();

            double total = 0.0;

            switch (location) {
                case "Bulgaria": 
                    total += points * dancersQty;
                    if (season == "summer") { total *= 0.95; } 
                    else { total *= 0.92; }
                    break;
                case "Abroad":
                    total += (points * dancersQty) * 1.5;
                    if (season == "summer") { total *= 0.9; } 
                    else { total *= 0.85; }
                    break;
            }

            double charity = total * 0.75;
            total -= charity;
            double moneyPerDancer = total / dancersQty;

            Console.WriteLine($"Charity - {charity:f2}");
            Console.WriteLine($"Money per dancer - {moneyPerDancer:f2}");
        }
    }
}
