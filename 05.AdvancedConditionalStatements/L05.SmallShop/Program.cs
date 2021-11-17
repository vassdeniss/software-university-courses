using System;

namespace L05.SmallShop {
    class Program {
        static void Main(string[] args) {
            const double SOFIA_COFFEE_PRICE = 0.50;
            const double SOFIA_WATER_PRICE = 0.80;
            const double SOFIA_BEER_PRICE = 1.20;
            const double SOFIA_SWEETS_PRICE = 1.45;
            const double SOFIA_PEANUTS_PRICE = 1.60;            
            const double PLOVDIV_COFFEE_PRICE = 0.40;
            const double PLOVDIV_WATER_PRICE = 0.70;
            const double PLOVDIV_BEER_PRICE = 1.15;
            const double PLOVDIV_SWEETS_PRICE = 1.30;
            const double PLOVDIV_PEANUTS_PRICE = 1.50;            
            const double VARNA_COFFEE_PRICE = 0.45;
            const double VARNA_WATER_PRICE = 0.70;
            const double VARNA_BEER_PRICE = 1.10;
            const double VARNA_SWEETS_PRICE = 1.35;
            const double VARNA_PEANUTS_PRICE = 1.55;

            string product = Console.ReadLine();
            string city = Console.ReadLine();
            double quantity = double.Parse(Console.ReadLine());
            double totalPrice = 0.0;

            if (city == "Sofia") {
                if (product == "coffee") {
                    totalPrice += quantity * SOFIA_COFFEE_PRICE;
                } else if (product == "water") {
                    totalPrice += quantity * SOFIA_WATER_PRICE;
                } else if (product == "beer") {
                    totalPrice += quantity * SOFIA_BEER_PRICE;
                } else if (product == "sweets") {
                    totalPrice += quantity * SOFIA_SWEETS_PRICE;
                } else if (product == "peanuts") {
                    totalPrice += quantity * SOFIA_PEANUTS_PRICE;
                }
            } else if (city == "Plovdiv") {
                if (product == "coffee") {
                    totalPrice += quantity * PLOVDIV_COFFEE_PRICE;
                } else if (product == "water") {
                    totalPrice += quantity * PLOVDIV_WATER_PRICE;
                } else if (product == "beer") {
                    totalPrice += quantity * PLOVDIV_BEER_PRICE;
                } else if (product == "sweets") {
                    totalPrice += quantity * PLOVDIV_SWEETS_PRICE;
                } else if (product == "peanuts") {
                    totalPrice += quantity * PLOVDIV_PEANUTS_PRICE;
                }
            } else if (city == "Varna") {
                if (product == "coffee") {
                    totalPrice += quantity * VARNA_COFFEE_PRICE;
                } else if (product == "water") {
                    totalPrice += quantity * VARNA_WATER_PRICE;
                } else if (product == "beer") {
                    totalPrice += quantity * VARNA_BEER_PRICE;
                } else if (product == "sweets") {
                    totalPrice += quantity * VARNA_SWEETS_PRICE;
                } else if (product == "peanuts") {
                    totalPrice += quantity * VARNA_PEANUTS_PRICE;
                }
            }

            Console.WriteLine(totalPrice);
        }
    }
}
