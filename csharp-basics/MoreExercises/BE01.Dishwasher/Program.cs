using System;

namespace BE01.Dishwasher {
    class Program {
        static void Main(string[] args) {
            const int WASHING_SOLUTION_CAPACITY = 750;
            const int PLATE_SOLUTION_REQUIRED = 5;
            const int PAN_SOLUTION_REQUIRED = 15;

            int washingSolutionBottles = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();

            int totalSolution = washingSolutionBottles * WASHING_SOLUTION_CAPACITY;
            int timesWashed = 0;
            int washedPlates = 0;
            int washedPans = 0;

            while (input != "End") {
                int dishesToWash = int.Parse(input);
                timesWashed++;

                if (timesWashed % 3 == 0) {
                    totalSolution -= dishesToWash * PAN_SOLUTION_REQUIRED;
                    washedPans += dishesToWash;
                } else {
                    totalSolution -= dishesToWash * PLATE_SOLUTION_REQUIRED;
                    washedPlates += dishesToWash;
                }

                if (totalSolution < 0) {
                    Console.WriteLine($"Not enough detergent, {Math.Abs(totalSolution)} ml. more necessary!");
                    return;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine("Detergent was enough!");
            Console.WriteLine($"{washedPlates} dishes and {washedPans} pots were washed.");
            Console.WriteLine($"Leftover detergent {totalSolution} ml.");
        }
    }
}
