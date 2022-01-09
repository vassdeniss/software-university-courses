using System;

namespace L11.FruitShop {
    class Program {
        static void Main(string[] args) {
            const double BANANA_PRICE = 2.50;
            const double APPLE_PRICE = 1.20;
            const double ORANGE_PRICE = 0.85;
            const double GRAPEFRUIT_PRICE = 1.45;
            const double KIWI_PRICE = 2.70;
            const double PINEAPPLE_PRICE = 5.50;
            const double GRAPE_PRICE = 3.85;

            string fruit = Console.ReadLine();
            string day = Console.ReadLine();
            double quantity = double.Parse(Console.ReadLine());

            double total = 0.0;

            switch (day) {
                case "Monday":
                case "Tuesday":
                case "Wednesday":
                case "Thursday":
                case "Friday":
                    switch (fruit) {
                        case "banana": total += BANANA_PRICE * quantity; break;
                        case "apple": total += APPLE_PRICE * quantity; break;
                        case "orange": total += ORANGE_PRICE * quantity; break;
                        case "grapefruit": total += GRAPEFRUIT_PRICE * quantity; break;
                        case "kiwi": total += KIWI_PRICE * quantity; break;
                        case "pineapple": total += PINEAPPLE_PRICE * quantity; break;
                        case "grapes": total += GRAPE_PRICE * quantity; break;
                        default: Console.WriteLine("error"); break;
                    }
                    break;
                case "Saturday":
                case "Sunday":
                    switch (fruit) {
                        case "banana": total += (BANANA_PRICE + 0.20) * quantity; break;
                        case "apple": total += (APPLE_PRICE + 0.05) * quantity; break;
                        case "orange": total += (ORANGE_PRICE + 0.05) * quantity; break;
                        case "grapefruit": total += (GRAPEFRUIT_PRICE + 0.15) * quantity; break;
                        case "kiwi": total += (KIWI_PRICE + 0.30) * quantity; break;
                        case "pineapple": total += (PINEAPPLE_PRICE + 0.10) * quantity; break;
                        case "grapes": total += (GRAPE_PRICE + 0.35) * quantity; break;
                        default: Console.WriteLine("error"); break;
                    }
                    break;
                default: Console.WriteLine("error"); break;
            }

            if (total != 0.0) { Console.WriteLine($"{total:f2}"); }
        }
    }
}
