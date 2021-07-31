using System;

namespace L09.Moving {
    class Program {
        static void Main(string[] args) {
            int avaliableWidth = int.Parse(Console.ReadLine());
            int avaliableLength = int.Parse(Console.ReadLine());
            int avaliableHeight = int.Parse(Console.ReadLine());

            int cubicMetersHouse = avaliableHeight
                * avaliableLength
                * avaliableWidth;

            string input = Console.ReadLine();

            while (input != "Done") {
                int boxesToMove = int.Parse(input);
                cubicMetersHouse -= boxesToMove;
                if (cubicMetersHouse <= 0) { break; }
                input = Console.ReadLine();
            }

            if (cubicMetersHouse > 0) {
                Console.WriteLine($"{cubicMetersHouse} Cubic meters left.");
            } else {
                Console.WriteLine($"No more free space! You need {Math.Abs(cubicMetersHouse)} Cubic meters more.");
            }
        }
    }
}
