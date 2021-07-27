using System;

namespace BE03.Logistics {
    class Program {
        static void Main(string[] args) {
            const int MICROBUS_LEVS = 200;
            const int TRUCK_LEVS = 175;
            const int TRAIN_LEVS = 120;

            int cargoQty = int.Parse(Console.ReadLine());

            double totalTon = 0;
            double middlePrice = 0;
            double microbusTotal = 0;
            double truckTotal = 0;
            double trainTotal = 0;

            for (int i = 0; i < cargoQty; i++) {
                int cargonTon = int.Parse(Console.ReadLine());
                totalTon += cargonTon;
                if (cargonTon <= 3) {
                    microbusTotal += cargonTon;
                    middlePrice += cargonTon * MICROBUS_LEVS;
                } else if (cargonTon >= 4 && cargonTon <= 11) {
                    truckTotal += cargonTon;
                    middlePrice += cargonTon * TRUCK_LEVS;
                } else if (cargonTon >= 12) {
                    trainTotal += cargonTon;
                    middlePrice += cargonTon * TRAIN_LEVS;
                }
            }

            middlePrice = middlePrice / totalTon;
            double microbusPercent = (microbusTotal / totalTon) * 100;
            double truckPercent = (truckTotal / totalTon) * 100;
            double trainPercent = (trainTotal / totalTon) * 100;

            Console.WriteLine($"{middlePrice:f2}");
            Console.WriteLine($"{microbusPercent:f2}%");
            Console.WriteLine($"{truckPercent:f2}%");
            Console.WriteLine($"{trainPercent:f2}%");
        }
    }
}
