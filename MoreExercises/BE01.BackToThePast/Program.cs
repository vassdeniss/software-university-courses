using System;

namespace BE01.BackToThePast {
    class Program {
        static void Main(string[] args) {
            double heritage = double.Parse(Console.ReadLine());
            int yearToSurvive = int.Parse(Console.ReadLine());
            int age = 18;

            double total = 0.0; 

            for (int i = 1800; i <= yearToSurvive; i++) {
                if (i % 2 == 0) {
                    total += 12000;
                } else {
                    total += 12000 + 50 * age;
                }
                age++;
            }

            if (heritage >= total) {
                Console.WriteLine($"Yes! He will live a carefree " +
                    $"life and will have {(heritage - total):f2} dollars left.");
            } else {
                Console.WriteLine($"He will need {(total - heritage):f2} dollars to survive.");
            }
        }
    }
}
