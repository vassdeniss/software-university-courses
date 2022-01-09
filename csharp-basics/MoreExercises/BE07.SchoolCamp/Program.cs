using System;

namespace BE07.SchoolCamp {
    class Program {
        static void Main(string[] args) {
            string season = Console.ReadLine();
            string groupType = Console.ReadLine();
            int studentQty = int.Parse(Console.ReadLine());
            int nightQty = int.Parse(Console.ReadLine());

            string sportType = "";
            double total = 0.0;

            if (season == "Winter") {
                if (groupType == "boys") {
                    total += 9.6 * nightQty * studentQty;
                    sportType = "Judo";
                } else if (groupType == "girls") {
                    total += 9.6 * nightQty * studentQty;
                    sportType = "Gymnastics";
                } else if (groupType == "mixed") {
                    total += 10 * nightQty * studentQty;
                    sportType = "Ski";
                }
            } else if (season == "Spring") {
                if (groupType == "boys") {
                    total += 7.2 * nightQty * studentQty;
                    sportType = "Tennis";
                } else if (groupType == "girls") {
                    total += 7.2 * nightQty * studentQty;
                    sportType = "Athletics";
                } else if (groupType == "mixed") {
                    total += 9.5 * nightQty * studentQty;
                    sportType = "Cycling";
                }
            } else if (season == "Summer") {
                if (groupType == "boys") {
                    total += 15 * nightQty * studentQty;
                    sportType = "Football";
                } else if (groupType == "girls") {
                    total += 15 * nightQty * studentQty;
                    sportType = "Volleyball";
                } else if (groupType == "mixed") {
                    total += 20 * nightQty * studentQty;
                    sportType = "Swimming";
                }
            }

            if (studentQty >= 50) { total /= 2; }
            else if (studentQty < 50 && studentQty >= 20) { total *= 0.85; }
            else if (studentQty < 20 && studentQty >= 10) { total *= 0.95; }

            Console.WriteLine($"{sportType} {total:f2} lv.");
        }
    }
}
