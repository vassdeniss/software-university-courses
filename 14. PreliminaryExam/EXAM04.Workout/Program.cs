using System;

namespace EXAM04.Workout {
    class Program {
        static void Main(string[] args) {
            int exerciseDays = int.Parse(Console.ReadLine());
            double kilometersDayOne = double.Parse(Console.ReadLine());

            double totalKilometers = kilometersDayOne;
            double kilometersToIncrease = kilometersDayOne;

            while (exerciseDays > 0) {
                double percent = double.Parse(Console.ReadLine());
                percent /= 100;
                kilometersToIncrease *= 1 + percent;
                totalKilometers += kilometersToIncrease;
                exerciseDays--;
            }

            if (totalKilometers >= 1000) {
                Console.WriteLine($"You've done a great job running " +
                    $"{Math.Ceiling(totalKilometers - 1000)} more kilometers!");
            } else {
                Console.WriteLine($"Sorry Mrs. Ivanova, you need to run " +
                    $"{Math.Ceiling(1000 - totalKilometers)} more kilometers");
            }
        }
    }
}
