using System;

namespace L06.NumberInRange {
    class Program {
        static void Main(string[] args) {
            int number = int.Parse(Console.ReadLine()); 

            if (number >= -100 && number <= 100 && number != 0) {
                Console.WriteLine("Yes");
            } else {
                Console.WriteLine("No");
            }
        }
    }
}
