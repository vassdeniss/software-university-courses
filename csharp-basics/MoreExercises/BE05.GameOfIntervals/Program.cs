using System;

namespace BE05.GameOfIntervals {
    class Program {
        static void Main(string[] args) {
            int gameTurns = int.Parse(Console.ReadLine());
            double score = 0;

            double percentOne = 0;
            double percentTwo = 0;
            double percentThree = 0;
            double percentFour = 0;
            double percentFive = 0;
            double percentSix = 0;

            for (int i = 0; i < gameTurns; i++) {
                double turnScore = int.Parse(Console.ReadLine()); 
                if (turnScore >= 0 && turnScore <= 9) {
                    percentOne++;
                    score += turnScore * 0.2;
                } else if (turnScore >= 10 && turnScore <= 19) {
                    percentTwo++;
                    score += turnScore * 0.3;
                } else if (turnScore >= 20 && turnScore <= 29) {
                    percentThree++;
                    score += turnScore * 0.4;
                } else if (turnScore >= 30 && turnScore <= 39) {
                    percentFour++;
                    score += 50;
                } else if (turnScore >= 40 && turnScore <= 50) {
                    percentFive++;
                    score += 100;
                } else {
                    percentSix++;
                    score /= 2;
                }
            }

            percentOne = (percentOne / gameTurns) * 100;
            percentTwo = (percentTwo / gameTurns) * 100;
            percentThree = (percentThree / gameTurns) * 100;
            percentFour = (percentFour / gameTurns) * 100;
            percentFive = (percentFive / gameTurns) * 100;
            percentSix = (percentSix / gameTurns) * 100;

            Console.WriteLine($"{score:f2}");
            Console.WriteLine($"From 0 to 9: {percentOne:f2}%");
            Console.WriteLine($"From 10 to 19: {percentTwo:f2}%");
            Console.WriteLine($"From 20 to 29: {percentThree:f2}%");
            Console.WriteLine($"From 30 to 39: {percentFour:f2}%");
            Console.WriteLine($"From 40 to 50: {percentFive:f2}%");
            Console.WriteLine($"Invalid numbers: {percentSix:f2}%");
        }
    }
}
