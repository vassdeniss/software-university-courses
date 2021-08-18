using System;

namespace EP05.Renovation {
    class Program {
        static void Main(string[] args) {
            int wallHeight = int.Parse(Console.ReadLine());
            int wallWidth = int.Parse(Console.ReadLine());
            int percent = int.Parse(Console.ReadLine());
            
            string input = Console.ReadLine();

            double totalArea = wallHeight * wallWidth * 4;
            totalArea -= totalArea * (percent / 100.00);
            totalArea = Math.Ceiling(totalArea);

            while (input != "Tired!") {
                int liters = int.Parse(input);
                totalArea -= liters;
                if (totalArea == 0) {
                    Console.WriteLine("All walls are painted! Great job, Pesho!");
                    return;
                } else if (totalArea < 0) {
                    Console.WriteLine($"All walls are painted and you have {Math.Abs(totalArea)} l paint left!");
                    return;
                }
                input = Console.ReadLine();
            }

            Console.WriteLine($"{totalArea} quadratic m left.");
        }
    }
}
