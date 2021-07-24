using System;

namespace E08.FishTank {
    class Program {
        static void Main(string[] args) {
            int lenght = int.Parse(Console.ReadLine()); 
            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            double percent = double.Parse(Console.ReadLine());

            double volume = lenght * width * height;
            double waterVolume = (volume - (volume * (percent * 0.01))) / 1000;

            Console.WriteLine(waterVolume);
        }
    }
}
