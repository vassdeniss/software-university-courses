using System;

namespace BE11.HappyCatParking {
    class Program {
        static void Main(string[] args) {
            const double EVEN_DAY_ODD_HOUR = 2.50;
            const double ODD_DAY_EVEN_HOUR = 1.25;
            int dayQty = int.Parse(Console.ReadLine());
            int hoursPerDay = int.Parse(Console.ReadLine());

            double total = 0.0;

            for (int i = 1; i <= dayQty; i++) {
                double dayTotal = 0.0;
                for (int j = 1; j <= hoursPerDay; j++) {
                    if (i % 2 == 0 && j % 2 != 0) {
                        dayTotal += EVEN_DAY_ODD_HOUR;
                        total += EVEN_DAY_ODD_HOUR;
                    } else if (i % 2 != 0 && j % 2 == 0) {
                        dayTotal += ODD_DAY_EVEN_HOUR;
                        total += ODD_DAY_EVEN_HOUR;
                    } else {
                        dayTotal += 1;
                        total += 1;
                    }
                }
                Console.WriteLine($"Day: {i} - {dayTotal:f2} leva");
            }
            Console.WriteLine($"Total: {total:f2} leva");
        }
    }
}
