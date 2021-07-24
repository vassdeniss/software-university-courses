using System;

namespace BE04.TransportPrice {
    class Program {
        static void Main(string[] args) {
            const double TAXI_STARTING_FEE = 0.70;
            const double TAXI_DAY_RATE = 0.79;
            const double TAXI_NIGHT_RATE = 0.90;
            const double BUS_RATE = 0.09;
            const double TRAIN_RATE = 0.06;

            int kilometers = int.Parse(Console.ReadLine());
            string timeDay = Console.ReadLine();

            if (kilometers >= 100) {
                double total = kilometers * TRAIN_RATE;
                Console.WriteLine($"{total:f2}");
            } else if (kilometers < 100 && kilometers >= 20) {
                double total = kilometers * BUS_RATE;
                Console.WriteLine($"{total:f2}");
            } else {
                if (timeDay == "day") {
                    double total = TAXI_STARTING_FEE + TAXI_DAY_RATE * kilometers;
                    Console.WriteLine($"{total:f2}");
                } else if (timeDay == "night") {
                    double total = TAXI_STARTING_FEE + TAXI_NIGHT_RATE * kilometers;
                    Console.WriteLine($"{total:f2}");
                }
            }
        }
    }
}
