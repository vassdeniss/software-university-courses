using System;

namespace EXAM05.Everest {
    class Program {
        static void Main(string[] args) {
            int startingMeters = 5364;
            int metersToReach = 8848;
            int days = 1;
            string input = Console.ReadLine();

            while (input != "END") {
                if (input == "Yes") { days++; }
                if (days > 5) { break; }

                int metersClimbed = int.Parse(Console.ReadLine());
                startingMeters += metersClimbed;

                if (startingMeters >= metersToReach) {
                    Console.WriteLine($"Goal reached for " +
                        $"{days} days!");
                    return;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Failed!\n{startingMeters}");
        }
    }
}
