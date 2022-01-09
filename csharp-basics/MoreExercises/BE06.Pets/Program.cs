using System;

namespace BE06.Pets {
    class Program {
        static void Main(string[] args) {
            const int GRAMS_KILOS = 1000;
            int daysGone = int.Parse(Console.ReadLine()); 
            int leftFood = int.Parse(Console.ReadLine());
            double foodDogDayKilos = double.Parse(Console.ReadLine());
            double foodCatDayKilos = double.Parse(Console.ReadLine());
            double foodTurtleDayGrams = double.Parse(Console.ReadLine());

            double foodDogTotalKilos = foodDogDayKilos * daysGone;
            double foodCatTotalKilos = foodCatDayKilos * daysGone;
            double foodTurtleTotalKilos = (foodTurtleDayGrams * daysGone) / GRAMS_KILOS;
            double totalFood = foodDogTotalKilos + foodCatTotalKilos + foodTurtleTotalKilos;

            if (leftFood >= totalFood) {
                double foodRemainder = Math.Floor(leftFood - totalFood);
                Console.WriteLine($"{foodRemainder} kilos of food left.");
            } else {
                double foodNeeded = Math.Ceiling(totalFood - leftFood);
                Console.WriteLine($"{foodNeeded} more kilos of food are needed.");
            }
        }
    }
}
