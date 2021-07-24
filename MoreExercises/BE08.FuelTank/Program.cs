using System;

namespace BE08.FuelTank {
    class Program {
        static void Main(string[] args) {
            string fuel = Console.ReadLine();
            double liters = double.Parse(Console.ReadLine()); 

            if (liters >= 25) {
                if (fuel == "Diesel" || fuel == "Gasoline" || fuel == "Gas") {
                    Console.WriteLine($"You have enough {fuel.ToLower()}.");
                } else {
                    Console.WriteLine("Invalid fuel!");
                }
            } else {
                if (fuel == "Diesel" || fuel == "Gasoline" || fuel == "Gas") {
                    Console.WriteLine($"Fill your tank with {fuel.ToLower()}!");
                } else {
                    Console.WriteLine("Invalid fuel!");
                }
            }
        }
    }
}
