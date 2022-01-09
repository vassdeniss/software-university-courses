using System;

namespace BE09.FuelTankTwo {
    class Program {
        static void Main(string[] args) {
            const double GASOLINE_PRICE = 2.22;
            const double DIESEL_PRICE = 2.33;
            const double GAS_PRICE = 0.93;
            const double GASOLINE_DISCOUNT = 0.18;
            const double DIESEL_DISCOUNT = 0.12;
            const double GAS_DISCOUNT = 0.08;
            const double DISCOUNT_PERCENT = 0.08;
            const double HEAVY_DISCOUNT_PERCENT = 0.1;

            string fuelType = Console.ReadLine();
            double litersFuel = double.Parse(Console.ReadLine());
            string discountCard = Console.ReadLine();

            double fuelPrice = 0.0;

            if (discountCard == "Yes") {
                if (fuelType == "Gasoline") {
                    fuelPrice = (GASOLINE_PRICE - GASOLINE_DISCOUNT) * litersFuel;
                } else if (fuelType == "Diesel") {
                    fuelPrice = (DIESEL_PRICE - DIESEL_DISCOUNT) * litersFuel;
                } else if (fuelType == "Gas") {
                    fuelPrice = (GAS_PRICE - GAS_DISCOUNT) * litersFuel;
                }
            } else {
                if (fuelType == "Gasoline") {
                    fuelPrice = GASOLINE_PRICE * litersFuel;
                } else if (fuelType == "Diesel") {
                    fuelPrice = DIESEL_PRICE * litersFuel;
                } else if (fuelType == "Gas") {
                    fuelPrice = GAS_PRICE * litersFuel;
                }
            }

            if (litersFuel > 20 && litersFuel <= 25) {
                fuelPrice = fuelPrice - (fuelPrice * DISCOUNT_PERCENT);
            } else if (litersFuel > 25) {
                fuelPrice = fuelPrice - (fuelPrice * HEAVY_DISCOUNT_PERCENT);
            }

            Console.WriteLine($"{fuelPrice:f2} lv.");
        }
    }
}
