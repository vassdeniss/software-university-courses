using System;

namespace BE02.BikeRace {
    class Program {
        static void Main(string[] args) {
            const double JUNIOR_TRAIL_PRICE = 5.50;
            const double JUNIOR_CROSS_COUNTRY_PRICE = 8;
            const double JUNIOR_DOWNHILL_PRICE = 12.25;
            const double JUNIOR_ROAD_PRICE = 20;            
            const double SENIOR_TRAIL_PRICE = 7;
            const double SENIOR_CROSS_COUNTRY_PRICE = 9.50;
            const double SENIOR_DOWNHILL_PRICE = 13.75;
            const double SENIOR_ROAD_PRICE = 21.50;

            // Ако в "cross-country" състезанието се съберат 50 или повече участника(общо младши и старши), таксата  намалява с 25%.
            // Организаторите отделят 5% процента от събраната сума за разходи.

            int juniorQty = int.Parse(Console.ReadLine());
            int seniorQty = int.Parse(Console.ReadLine());
            string raceType = Console.ReadLine();

            double juniorTotal = 0.0;
            double seniorTotal = 0.0;
            double total = 0.0;

            switch (raceType) {
                case "trail":
                    juniorTotal = juniorQty * JUNIOR_TRAIL_PRICE;
                    seniorTotal = seniorQty * SENIOR_TRAIL_PRICE;
                    total = juniorTotal + seniorTotal;
                    break;
                case "cross-country":
                    if (juniorQty + seniorQty >= 50) {
                        double newJuniorPrice = JUNIOR_CROSS_COUNTRY_PRICE * 0.75;
                        double newSeniorPrice = SENIOR_CROSS_COUNTRY_PRICE * 0.75;
                        juniorTotal = juniorQty * newJuniorPrice;
                        seniorTotal = seniorQty * newSeniorPrice;
                        total = juniorTotal + seniorTotal;
                    } else {
                        juniorTotal = juniorQty * JUNIOR_CROSS_COUNTRY_PRICE;
                        seniorTotal = seniorQty * SENIOR_CROSS_COUNTRY_PRICE;
                        total = juniorTotal + seniorTotal;
                    }
                    break;
                case "downhill":
                    juniorTotal = juniorQty * JUNIOR_DOWNHILL_PRICE;
                    seniorTotal = seniorQty * SENIOR_DOWNHILL_PRICE;
                    total = juniorTotal + seniorTotal;
                    break;
                case "road":
                    juniorTotal = juniorQty * JUNIOR_ROAD_PRICE;
                    seniorTotal = seniorQty * SENIOR_ROAD_PRICE;
                    total = juniorTotal + seniorTotal;
                    break;
            }

            total *= 0.95;

            Console.WriteLine($"{total:f2}");
        }
    }
}
