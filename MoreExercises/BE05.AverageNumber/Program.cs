using System;

namespace BE05.AverageNumber {
    class Program {
        static void Main(string[] args) {
            int numberQty = int.Parse(Console.ReadLine());
            int counter = 0;
            double sum = 0;
            while (counter < numberQty) {
                sum += int.Parse(Console.ReadLine());
                counter++;
            }
            double average = sum / numberQty;
            Console.WriteLine($"{average:f2}");
        }
    }
}
