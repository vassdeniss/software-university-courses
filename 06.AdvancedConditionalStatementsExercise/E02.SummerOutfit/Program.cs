using System;

namespace E02.SummerOutfit {
    class Program {
        static void Main(string[] args) {
            int degrees = int.Parse(Console.ReadLine());
            string timeOfDay = Console.ReadLine();

            string shirt = "";
            string shoes = ""; 

            switch (timeOfDay) {
                case "Morning": 
                    if (degrees >= 10 && degrees <= 18) {
                        shirt = "Sweatshirt";
                        shoes = "Sneakers";
                    } else if (degrees > 18 && degrees <= 24) {
                        shirt = "Shirt";
                        shoes = "Moccasins"; 
                    } else if (degrees >= 25) {
                        shirt = "T-Shirt";
                        shoes = "Sandals";
                    }
                    break;
                case "Afternoon":
                    if (degrees >= 10 && degrees <= 18) {
                        shirt = "Shirt";
                        shoes = "Moccasins";
                    } else if (degrees > 18 && degrees <= 24) {
                        shirt = "T-Shirt";
                        shoes = "Sandals";
                    } else if (degrees >= 25) {
                        shirt = "Swim Suit";
                        shoes = "Barefoot";
                    }
                    break;
                case "Evening":
                    shirt = "Shirt";
                    shoes = "Moccasins";
                    break;
            }

            Console.WriteLine($"It's {degrees} degrees, get your {shirt} and {shoes}.");
        }
    }
}
