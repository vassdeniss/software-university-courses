using System;

namespace L13.SkiTrip {
    class Program {
        static void Main(string[] args) {
            const double ONE_PERSON_ROON = 18;
            const double APARTMENT = 25;
            const double PRESIDENT_APARTMENT = 35;

            int days = int.Parse(Console.ReadLine());
            string roomType = Console.ReadLine();
            string review = Console.ReadLine();
            double total = 0.0;

            if (roomType == "room for one person") {
                total = (days - 1) * ONE_PERSON_ROON;
                if (review == "positive") {
                    total *= 1.25;
                } else if (review == "negative") {
                    total *= 0.90;
                }
            } else if (roomType == "apartment") {
                total = (days - 1) * APARTMENT;
                if ((days - 1) > 15) {
                    total *= 0.5;
                } else if ((days - 1) >= 10 && (days - 1) <= 15) {
                    total *= 0.65;
                } else if ((days - 1) < 10) {
                    total *= 0.7;
                }
                if (review == "positive") {
                    total *= 1.25;
                } else if (review == "negative") {
                    total *= 0.90;
                }
            } else if (roomType == "president apartment") {
                total = (days - 1) * PRESIDENT_APARTMENT;
                if ((days - 1) > 15) {
                    total *= 0.8;
                } else if ((days - 1) >= 10 && (days - 1) <= 15) {
                    total *= 0.85;
                } else if ((days - 1) < 10) {
                    total *= 0.9;
                }
                if (review == "positive") {
                    total *= 1.25;
                } else if (review == "negative") {
                    total *= 0.90;
                }
            }

            Console.WriteLine($"{total:f2}");
        }
    }
}
