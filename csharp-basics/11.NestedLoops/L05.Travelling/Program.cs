using System;

namespace L05.Travelling {
    class Program {
        static void Main(string[] args) {
            string location = Console.ReadLine();

            while (location != "End") {
                double vacationPrice = double.Parse(Console.ReadLine());
                double budget = 0.0;

                while (budget < vacationPrice) {
                    budget += double.Parse(Console.ReadLine());
                }

                Console.WriteLine($"Going to {location}!");

                location = Console.ReadLine();
            }
        }
    }
}
